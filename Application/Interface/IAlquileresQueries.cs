using Domain.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IAlquileresQueries
    {
        public List<Alquileres> Find(int estado);
        public Alquileres FindByIsbnAndClient(int cliente, string ISBN);
        public List<Alquileres> FindAll();
        public List<Alquileres> FindByClient(int cliente);
    }
}
