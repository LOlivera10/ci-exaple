using Application.Interface;
using Domain.model;

namespace Data.Comman
{
    public class ClientCommand : IClientCommand
    {
        private DbContext _dbContext;
        public ClientCommand(DbContext context)
        {
            _dbContext = context;
        }
        public void Create(Cliente client)
        {
            _dbContext.Clientes.Add(client);
            _dbContext.SaveChanges();
        }
    }
}
