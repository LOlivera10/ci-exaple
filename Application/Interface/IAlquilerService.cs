using Application.utils;
using Domain.model;

namespace Application.Interface
{
    public interface IAlquilerService
    {
        public Response createAlquiler(Cliente Cliente, string ISBN, int estado);
        public Response findAlquileres(int estado);
        public Response putAlquiler(int client, string ISBN);
        public Response concatToLibros(Response ResAlquileres);
        public Response FinByClient(int cliente);
    }
}
