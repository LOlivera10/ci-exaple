using Application.Interface;
using Application.utils;
using Domain.model;
using Domain.Patterns.Decorator.Clientes;
using System.Collections;
using Domain.Patterns.Decorator.Clientes.ConcreteDecorator;

namespace Application.service
{
    public class ClienteService: IClienteService
    {
        private IClienteQueries _clienteQueries;
        private IClientCommand _clientCommand;
        private IApiGetClient _apiGetClient;
      public ClienteService(IClienteQueries clienteQueri,IClientCommand clientCommand, IApiGetClient api)
        {
            _clienteQueries= clienteQueri;
            _clientCommand= clientCommand;
            _apiGetClient= api;
        }
        public Response verifyFields(string Dni,string Nombre,string Apellido,string Email)
        {
            var response = new Response(true,"se ha validado correctamente los campos");

            if(Dni == null || Nombre == null || Apellido == null || Email == null)
            {
                response.succes = false;
                response.content = "No se pueden guardar campos con valor null";
                return response;
            }
            if(Dni == "" || Nombre == "" || Apellido == "" || Email == "")
            {
                response.succes = false;
                response.content = "No se pueden guardar campos con valor vacio";
                return response;
            }
            return response;
        }
        public Response findOneClient(string Dni)
        {
            var response = new Response(true, "se ha encontrado el cliente correctamente");
            try
            {
                Cliente client = (Cliente)_clienteQueries.FindOneByDni(Dni);
                if(client == null)
                {
                    response.succes = false;
                    response.content = "No se ha encontrado a ningun usuario con este dni";
                }
                else
                {
                    response.content = client.Nombre+" "+ client.Apellido+" "+ client.Dni ;
                response.objects = client;
                }
                return response;
            }catch 
            {
                response.succes = false;
                response.content="Internal Server Error";
                return response;
            }
            
        }
        public Response findOneClientById(int Id)
        {
            var response = new Response(true, "se ha encontrado el cliente correctamente");
            try
            {
                Cliente client = (Cliente)_clienteQueries.findOneById(Id);

                    if (client == null)
                    {
                        response.succes = false;
                        response.content = "No se ha encontrado a ningun usuario con este id";
                    }
                    else
                    {
                        response.content = client.Nombre + " " + client.Apellido + " " + client.Dni;
                        response.objects = client;
                    }
                return response;
            }
            catch
            {
                response.succes = false;
                response.content = "Internal Server Error";
                return response;
            }

        }
        public Response CreateClient(Cliente client)
        {
            var response = new Response(true, "se ha creado correctamente al cliente");
            try
            {
                    _clientCommand.Create(client);
                    response.content = "Se ha guardado correctamente al Cliente";
                    return response;
            }
            catch
            {
                response.succes=false;
                response.content="internal server error: no se ah podido crear al cliente";
                return response;
            }
        }

        public Response CreateModelClient(int dni,string Nombre,string Apellido,string Email)
        {
            
            var response = new Response(true, "se ha creado correctamente al cliente");
            try
                {
                    string Dni = dni.ToString();
                    var clientExist = this.findOneClient(Dni);
                    if (!clientExist.succes)
                    {
                      
                        var verify = this.verifyFields(Dni, Nombre, Apellido, Email);
                        if (!verify.succes)
                        {
                            response.succes = false;
                            response.content = verify.content;
                    }
                        else
                        {
                            response.objects = new Cliente(Dni, Nombre, Apellido, Email);
                            response.succes = true;
                            response.content=verify.content;
                            
                        }
                        return response;
                    }
                    else
                    {
                        response.succes = false;
                        response.content = "ya existe un cliente registrado con este dni";
                        return response;
                }
                }
                catch
                {
                    response.succes = false;
                    response.content = "El Campo Dni no puede contener letras";
                    return response;
            }
            
        }
        public Response GetClienteByParams(string nombre, string apellido, string dni)
        {
            var response = new Response(true, "se ha encontrado el o los cliente correctamente");
            ArrayList arr = new ArrayList();
            IApiGetClient result;
            if (nombre==null && apellido == null &&  dni == null)
            {
                response.succes = false;
                response.content = "error, se requiere llenar almenos 1 campo para poder hacer la busqueda";
                return response;
            }
            try
            {
                if (dni != null)
                {
                    var responseClient = this.findOneClient(dni);
                    if (!responseClient.succes)
                    {
                        response.succes= responseClient.succes;
                        response.content = responseClient.content;
                        return response;
                    }
                    
                    arr.Add(responseClient.objects);
                    response.arrList = arr;
                    return response;
                }
                if (nombre != null)
                {
                    arr = _apiGetClient.getClient(nombre);
                    if(apellido != null)
                    {
                        result = new FilterWhitApellido(_apiGetClient, apellido);
                        response.arrList = result.getClient(nombre);
                        return response;
                    }
                    response.arrList = arr;
                    return response;
                }
                var clientByApelldio = _clienteQueries.GetByApellido(apellido);
                foreach (var item in clientByApelldio)
                {
                    arr.Add(item);
                }
                response.arrList = arr;
                return response;
            }
            catch
            {
                response.succes=false;
                response.content = "internal server error";
                return response;
            }
           
        }
    }
}
