using Domain.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface ILibroQueries
    {
        public List<Libros> findWhitStock();
        public object findOneLibro(string isbn);
        public List<Libros> GetAll();

    }
}
