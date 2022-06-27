using Application.utils;
using Domain.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IClienteService
    {
        public Response verifyFields(string Dni, string Nombre, string Apellido, string Email);
        public Response findOneClient(string Dni);
        public Response findOneClientById(int Id);
        public Response CreateClient(Cliente client);
        public Response CreateModelClient(int Dni, string Nombre, string Apellido, string Email);
        public Response GetClienteByParams(string nombre, string Apellido, string dni);

    }
}
