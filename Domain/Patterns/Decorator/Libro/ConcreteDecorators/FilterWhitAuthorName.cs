using Domain.model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Patterns.Decorator.Libro.ConcreteDecorators
{
    public class FilterWhitAuthorName:DecoratorApiGetLibros
    {
        protected string author;
        public FilterWhitAuthorName(IApiGetLibros api, string author) : base(api)
        {
            this.author = author;
        }
        public override ArrayList GetLibros()
        {
            ArrayList listFilter = new ArrayList();
            ArrayList libros = this.api.GetLibros();
            foreach (Libros libro in libros)
            {
                if (libro.Autor == author)
                {
                    listFilter.Add(libro);
                }
            }
            return listFilter;
        }
    }
}
