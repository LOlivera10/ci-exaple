using Domain.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IClienteQueries
    {
        public object FindOneByDni(string Dni);
        public object findOneById(int Id);
        public List<Cliente> GetByName(string nombre);
        public List<Cliente> GetByApellido(string apellido);
    }
}
