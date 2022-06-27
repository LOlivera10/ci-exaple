using Application.Interface;
using Domain.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Queries
{
    public class AlquileresQueries: IAlquileresQueries
    {
        DbContext _db;
        public AlquileresQueries(DbContext context)
        {
            _db = context;
        }
        public List<Alquileres> Find(int estado )
        {   
            var listReservas = _db.Alquileres.Where(x => x.estadoId == estado).ToList();
            return listReservas;
        }

        public List<Alquileres> FindAll()
        {
            var listReservas = _db.Alquileres.ToList();
            return listReservas;
        }

        public List<Alquileres> FindByClient(int cliente)
        {
            return _db.Alquileres.Where(x => x.clienteId == cliente).ToList();
        }

        public Alquileres FindByIsbnAndClient(int cliente, string ISBN)
        {
            var alquiler = _db.Alquileres.FirstOrDefault(x => x.clienteId == cliente && x.isbnId == ISBN);
            return alquiler;
        }
    }
}
