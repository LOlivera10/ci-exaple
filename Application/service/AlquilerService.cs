using System.Collections;
using Application.utils;
using Domain.model;
using Application.Interface;

namespace Application.service
{
    public class AlquilerService: IAlquilerService
    {
        private IAlquileresCommand _command;
        private IAlquileresQueries _alquileresQueries;
        private IEstadoQuerie _estadoQuerie;
        private ILibroQueries _libroQueries;
        private IClienteQueries _queriCliente;
        public AlquilerService(IAlquileresCommand command, IEstadoQuerie estadoQuerie, IAlquileresQueries alquileresQueries, ILibroQueries libroQueries, IClienteQueries cliente)
        {
            _command = command;
            _estadoQuerie = estadoQuerie;
            _alquileresQueries = alquileresQueries;
            _libroQueries = libroQueries;
            _queriCliente = cliente;
        }
        public Response createAlquiler(Cliente Cliente, string ISBN, int est)
        {
            var response = new Response(true, "se ha creado el alquiler correctamente");
            var estado = (EstadoDeAlquileres)_estadoQuerie.Find(est);
            if (estado == null) { 
                response.succes = false;
                response.content = "error al buscar el Estado";
                return response;
            }
            var isbnLibro = (Libros)_libroQueries.findOneLibro(ISBN);
            if (isbnLibro == null) {
                response.succes = false;
                response.content = "error al buscar el Libro";
                return response;
            }

                DateTime ?FechaReserva = DateTime.Now;
                DateTime ? FechaAlquieler = DateTime.Now;
                DateTime ? FechaDevolucion = DateTime.Now;
                if (estado.Descripcion == "Reservado")
                {
                    FechaReserva = DateTime.Now;
                    FechaAlquieler = null;
                    FechaDevolucion = DateTime.Now.AddDays(7);
            }
                if (estado.Descripcion == "Alquilado")
                {
                    FechaAlquieler = DateTime.Now;
                    FechaReserva = null;
                    FechaDevolucion = DateTime.Now.AddDays(7);
            }
                if (estado.Descripcion == "Cancelado")
                {
                    FechaDevolucion = DateTime.Now;
                    FechaAlquieler = null;
                    FechaReserva = null;
                }
            try
            {
                _command.create(Cliente, isbnLibro, estado, FechaReserva, FechaAlquieler, FechaDevolucion);
                response.content = "Se ha guardado correctamente El Alquiler o Reserva";
                return response;
            }
            catch
            {
                response.succes = false;
                response.content = "Internal Server Error";
                return response;
            }        
        }
        public Response findAlquileres(int estado)
        {
            var response = new Response(true, "se ha traido los alquileres correctamente");
            if (estado > 3 || estado<0)
            {
                response.succes = false;
                response.content = "Error, numero ingresado fuera de rango, solo se admite 1,2,3";
                return response;
            }
            
            ArrayList list = new ArrayList();
            List<Alquileres> listaAlquileres; 
            try
            {  
                if(estado == 0)
                {
                    listaAlquileres = _alquileresQueries.FindAll();
                }
                else
                {
                    listaAlquileres = _alquileresQueries.Find(estado);
                }
                    
                if (listaAlquileres.Count == 0)
                {
                    response.content = "no se ha encontrado ninguna Alquileres o reservas ";
                    response.succes = false;

                }
                else
                {
                    foreach (var alquiler in listaAlquileres)
                    {
                        list.Add(alquiler);
                    }
                    response.content = "se ha encontrado correctamente los alquilerers";
                    response.succes = true;
                    response.arrList = list;
                }
                
                return response;
            }
            catch
            {
                response.content = "internal server Error: no se ha podido traer a los Alquileres";
                response.succes = false;
                return response;
            }

        }
        public Response putAlquiler(int client , string ISBN)
        {
            var response = new Response(true, "se ha cambiado el estado del alquiler correctamente");
            try
            {
                if(client==0||ISBN==""|| ISBN == null)
                {
                    response.succes = false;
                    response.content = "Todos los campos son obligatiorios";
                    return response;
                }
                
                var alquiler = _alquileresQueries.FindByIsbnAndClient(client, ISBN);
                if (alquiler == null)
                {
                    response.succes = false;
                    response.content = "error, no se ha encontrado un alquiler con ese cliente e isbn";
                    return response;
                }
                if (alquiler.estadoId == 2)
                {
                    response.succes = false;
                    response.content = "Este libro ya esta alquilado";
                    return response;
                }
                var fechaDeAlquiler = DateTime.Now;
                _command.updateToAlquilado(alquiler.Id, fechaDeAlquiler);
                return response;
            }
            catch
            {
               response.succes=false;
                response.content = "internal server error";
                return response;
            }
            
        }

        public Response FinByClient(int cliente)
        {
            var response = new Response(true, "se ha encontrado el cliente correctamente");
            ArrayList lista = new ArrayList();  
            try
            {
                if (cliente == 0)
                {
                    response.content = "error, Es dni es necesario";
                    response.succes = false;
                    return response;
                }
                List<Alquileres> alquileres = _alquileresQueries.FindByClient(cliente);
                if (alquileres.Count == 0)
                {
                    response.content = "No se ha encontrado ningun Alquiler o reserva para este cliente";
                    response.succes= false;
                    return response;
                }   
                foreach (Alquileres alquiler in alquileres)
                {
                    EstadoDeAlquileres estado = (EstadoDeAlquileres)_estadoQuerie.Find(alquiler.estadoId);
                    Libros libro = (Libros)_libroQueries.findOneLibro(alquiler.isbnId);
                    lista.Add(new
                    {
                        Titulo = libro.Titulo,
                        Estado = estado.Descripcion
                    });
                }
                response.arrList = lista;
                return response; 
            }
            catch
            {
                response.succes = false;
                response.content = "Internal server Error";
                return response; 
            }
        }
        public Response concatToLibros(Response ResAlquileres)
        {
            try
            {
                var array = new ArrayList();
                foreach (Alquileres alquiler in ResAlquileres.arrList)
                {
                    Libros libro = (Libros)_libroQueries.findOneLibro(alquiler.isbnId);
                    if (libro == null)
                    {
                        ResAlquileres.succes = false;
                        ResAlquileres.content = "Error al buscar el libro";
                        return ResAlquileres;
                    }
                    EstadoDeAlquileres estado = (EstadoDeAlquileres)_estadoQuerie.Find(alquiler.estadoId);
                    if (estado == null)
                    {
                        ResAlquileres.succes = false;
                        ResAlquileres.content = "Error al buscar el Estado";
                        return ResAlquileres;
                    }
                    Cliente cliente = (Cliente)_queriCliente.findOneById(alquiler.clienteId);
                    array.Add(
                        new
                        {
                            Cliente =new { 
                                Nombre= cliente.Nombre,
                                Apellido=cliente.Apellido,
                            }, 
                            libro = new {
                                    Isbn=libro.ISBN,
                                    Titulo=libro.Titulo,
                                    Edicion=libro.Edicion,
                                    Editorial=libro.Editorial,
                                    Img=libro.Imagen
                                },
                            estado = estado.Descripcion,
                            fechaDeAlquiler = alquiler.FechaAlquieler.ToString(),
                            fechaDeReserva = alquiler.FechaReserva.ToString(),
                            fechaDeDevolucion = alquiler.FechaDevolucion.ToString(),
                        });
                }
                ResAlquileres.arrList = array;
                return ResAlquileres;
            }
            catch
            {
                ResAlquileres.succes = false;
                ResAlquileres.content = "internal server error";
                return ResAlquileres;
            }
        }
    }

}
