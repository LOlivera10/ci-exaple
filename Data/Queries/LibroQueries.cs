using Application.Interface;
using Domain.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Queries
{
    public class LibroQueries : ILibroQueries
    {
        DbContext _db;
        public LibroQueries(DbContext context)
        {
            _db = context;
        }
        public object findOneLibro(string isbn)
        {
            var lib = _db.Libros.Find(isbn);
            return lib;
        }

        public List<Libros> findWhitStock()
        {
            var LibroList = _db.Libros.Where(x => x.Stock > 0).ToList();
            return LibroList;
        }

        public List<Libros> GetAll()
        {
            var LibroList = _db.Libros.ToList();
            return LibroList;
        }
    }
}
