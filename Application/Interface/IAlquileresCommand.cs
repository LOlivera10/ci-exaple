using Domain.model;

namespace Application.Interface
{
    public interface IAlquileresCommand
    {
        public void create(Cliente cliente, Libros ISBN, EstadoDeAlquileres estado, DateTime? fechaReserva, DateTime? fechaAlquieler, DateTime? fechaDevolucion);
        public void updateToAlquilado(int id,DateTime fechaDeAlquiler);
    }
}
