using Application.Interface;
using Domain.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Queries
{
    public class ClienteQueries: IClienteQueries
    {
        DbContext _db;
        public ClienteQueries(DbContext context)
        {
            _db = context;
        }

        public object FindOneByDni(string Dni)
        {
            return _db.Clientes.FirstOrDefault(x => x.Dni==Dni);
        }
        public object findOneById(int id) { 
            return _db.Clientes.Find(id); 
        }

        public List<Cliente> GetByApellido(string apellido)
        {
            return _db.Clientes.Where(x => x.Apellido == apellido).ToList();
        }

        public List<Cliente> GetByName(string nombre)
        {
            return _db.Clientes.Where(x => x.Nombre == nombre).ToList();
        }
    }
}
