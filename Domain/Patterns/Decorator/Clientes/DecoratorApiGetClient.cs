using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Patterns.Decorator.Clientes
{
    public abstract class DecoratorApiGetClient : IApiGetClient
    {
        protected IApiGetClient _apigeClient;
        public DecoratorApiGetClient(IApiGetClient api)
        {
            this._apigeClient = api;
        }
        public virtual ArrayList getClient(string nombre)
        {
            return _apigeClient.getClient(nombre);
        }
    }
}
