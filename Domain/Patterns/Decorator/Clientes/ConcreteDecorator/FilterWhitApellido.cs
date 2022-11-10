using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.model; 
namespace Domain.Patterns.Decorator.Clientes.ConcreteDecorator
{
    public class FilterWhitApellido : DecoratorApiGetClient
    {
        private string apellido;
        public FilterWhitApellido(IApiGetClient api, string apellido ) : base(api)
        {
            this.apellido = apellido;
        }
        public override ArrayList getClient(string nombre)
        {
            ArrayList arrayList = new ArrayList();
            var clientes = this._apigeClient.getClient(nombre);
            foreach (Cliente cliente in clientes)
            {
                if(cliente.Apellido== apellido)
                {
                    arrayList.Add(cliente);
                }
            }
            return arrayList;
        }
    }
}
