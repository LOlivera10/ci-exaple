using Application.Interface;
using Domain.Patterns.Decorator.Clientes;
using System.Collections;


namespace Application.ConcreteClassDecoratorPattern
{
    public class ApiGetClientByNombre: IApiGetClient
    {
        private IClienteQueries _clientService;
        public ApiGetClientByNombre(IClienteQueries querie)
        {
            this._clientService = querie;
        }

        public ArrayList getClient(string nombre)
        {
            ArrayList arr = new ArrayList();
            var list = _clientService.GetByName(nombre);
            foreach (var item in list)
            {
                arr.Add(item);
            }
            return arr;
        }
    }
}
