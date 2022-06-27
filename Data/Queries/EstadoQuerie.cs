using Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Queries
{
    public class EstadoQuerie:IEstadoQuerie
    {
        DbContext _db;
        public EstadoQuerie(DbContext context)
        {
            _db = context;
        }
        public object Find(int estadoOption)
        {
            var estado = _db.EstadoDeAlquileres.Find(estadoOption);
            return estado;
        }
    }
}
