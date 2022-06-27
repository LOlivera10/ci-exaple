using Application.utils;
using Domain.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface ILibroService
    {
        public Response findLibroWhitStock();
        public Response haveStock(Libros lib);
        public Response findOneLibro(string isbn);
        public Response GetLibrosFilters(bool stock, string nombre, string titulo);

    }
}
