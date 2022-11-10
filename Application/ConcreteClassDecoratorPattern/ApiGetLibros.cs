using Domain.model;
using Application.Interface;
using Domain.Patterns.Decorator.Libro;
using System.Collections;

namespace Application.ConcreteClassDecoratorPattern
{
    public class ApiGetLibros : IApiGetLibros
    {
        private ILibroQueries _libroQueries;
        public ApiGetLibros(ILibroQueries querie)
        {
            this._libroQueries = querie;
        }
        public ArrayList GetLibros()
        {
            ArrayList arr = new ArrayList();
            List<Libros> libros = _libroQueries.GetAll();
            foreach (Libros libro in libros)
            {
                arr.Add(libro);
            }
            return arr;
        }
    }
}
