using Domain.model;
using Application.Interface;

namespace Data.Comman
{
    public class CommandAlquileres: IAlquileresCommand
    {
        private DbContext _dbContext;
        public CommandAlquileres(DbContext context)
        {
            _dbContext = context;
        }
        public void create(Cliente cliente, Libros ISBN, EstadoDeAlquileres estado, DateTime? fechaReserva, DateTime? fechaAlquieler, DateTime? fechaDevolucion)
        {
            var lib = _dbContext.Libros.Find(ISBN.ISBN);
            lib.Stock--;
            var Alquiler = new Alquileres()
            {
                clienteId = cliente.ClienteId,
                isbnId = ISBN.ISBN,
                estadoId = estado.EstadoId,
                FechaReserva = fechaReserva,
                FechaAlquieler = fechaAlquieler,
                FechaDevolucion = fechaDevolucion,

            };
            _dbContext.Alquileres.Add(Alquiler);
            _dbContext.SaveChanges();
        }

        public void updateToAlquilado(int id,DateTime fechaDeAlquiler)
        {
            var alquiler = _dbContext.Alquileres.Find(id);
            alquiler.estadoId = 2;
            alquiler.FechaAlquieler = fechaDeAlquiler;
            _dbContext.SaveChanges();
        }
    }
}
