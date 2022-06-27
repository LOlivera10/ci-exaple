using Domain.model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Patterns.Decorator.Libro
{
    public abstract class DecoratorApiGetLibros : IApiGetLibros
    {
        protected IApiGetLibros api;
        public DecoratorApiGetLibros(IApiGetLibros api)
        {
            this.api = api;
        }
        public virtual ArrayList GetLibros()
        {
            return api.GetLibros();
        }
       
    }
}
