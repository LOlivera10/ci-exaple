using Domain.model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Patterns.Decorator.Libro.ConcreteDecorators
{
    public class FilterWithStock : DecoratorApiGetLibros
    {
        public FilterWithStock(IApiGetLibros api) : base(api)
        {
        }
        public override ArrayList GetLibros()
        {
            ArrayList listFilter= new ArrayList();    
            ArrayList libros = this.api.GetLibros();
            foreach(Libros libro in libros)
            {
                if (libro.Stock != 0)
                {
                    listFilter.Add(libro);
                }
            }
           return listFilter;
        }
    }
}
