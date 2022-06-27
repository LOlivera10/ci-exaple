using Domain.model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Patterns.Decorator.Libro.ConcreteDecorators
{
    public class FilterWithTitle : DecoratorApiGetLibros
    {
        protected string title;
        public FilterWithTitle(IApiGetLibros api,string title) : base(api)
        {
            this.title = title;
        }
        public override ArrayList GetLibros()
        {
            ArrayList listFilter = new ArrayList();
            ArrayList libros = this.api.GetLibros();
            foreach (Libros libro in libros)
            {
                if (libro.Titulo == title)
                {
                    listFilter.Add(libro);
                }
            }
            return listFilter;
        }
    }
}
