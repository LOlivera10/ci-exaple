using Microsoft.EntityFrameworkCore;
using Domain.model;

namespace Data
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        

        public DbContext(DbContextOptions<DbContext> options) : base(options)
        {
        }
        public DbSet<EstadoDeAlquileres> EstadoDeAlquileres { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Libros> Libros { get; set; }
        public DbSet<Alquileres> Alquileres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Libros>().HasData(
                new Libros("9788466357913", "Saga dos Amigas", "Elena Ferrante", "Debolsillo", "001", 6, "https://images.cdn1.buscalibre.com/fit-in/360x360/e1/a9/e1a9cabdf6a6e77043d564ae91ce8f6a.jpg"),
                new Libros("9788418052187", "La Casta de los Metabarones", "Alejandro Jodorowsky", "Reservoir Books", "001", 2, "https://images.cdn2.buscalibre.com/fit-in/360x360/15/05/15051197af8f0a016247e1cc176738b8.jpg"),
                new Libros("9786287544079", "BRATVA", "Gleen Black", "Sin Fronteras Grupo Editorial", "001", 7, "https://images.cdn3.buscalibre.com/fit-in/360x360/9b/27/9b272c321c2616e64a855bf8c6034cbb.jpg"),
                new Libros("9786075277851", "El Arte de la Seduccion", "Robert Greene", "Oceano", "001", 4, "https://images.cdn3.buscalibre.com/fit-in/360x360/8c/40/8c40d2433efdea2ef6c91cf2f16c1135.jpg"),
                new Libros("9788424653491", "Don Quijote de la Mancha", "Miguel De Cervantes", "La Galera", "001", 3, "https://images.cdn1.buscalibre.com/fit-in/360x360/a5/35/a5359eb612f3f5b42fe8addbc0950f53.jpg"),
                new Libros("9789875809659", "Luna de Pluton", "Dross", "Booket", "001", 10, "https://images.cdn1.buscalibre.com/fit-in/360x360/93/1d/931d2a5a6c9ab4c117f34dd704c52749.jpg"),
                new Libros("9789508701695", "Escape", "Dross", "Martinez Roca", "001", 5, "https://images.cdn1.buscalibre.com/fit-in/360x360/a3/ad/a3ad3aa75860ff13996e6be80c3b0cbb.jpg"),
                new Libros("9789507301131", "El Festival de la Blasfemia", "Dross", "Temas De Hoy", "001", 30, "https://images.cdn2.buscalibre.com/fit-in/360x360/83/63/8363e7713727af1a04591376c1d9af50.jpg"),
                new Libros("9789584282613", "El Libro Negro", "Dross", "Grupo Planeta", "001", 7, "https://images.cdn1.buscalibre.com/fit-in/360x360/97/66/976684737c819ca0af8e67f75bf113ba.jpg"),
                new Libros("9875731994", "Perros de Nadie", "Valentino E.", "Sm", "001", 7, "https://images.cdn1.buscalibre.com/fit-in/360x360/cb/b7/cbb71b617b8030055f6d1c126154f08e.jpg"),
                new Libros("9871093225", "El diablo en la botella", "Robert Stevenson", "Gradifco", "001", 9, "https://image.cdn0.buscalibre.com/2817664.__RS360x360__.jpg")
                );
            modelBuilder.Entity<EstadoDeAlquileres>().HasData(
                 new EstadoDeAlquileres { EstadoId = 1, Descripcion = "Reservado" },
                 new EstadoDeAlquileres { EstadoId = 2, Descripcion = "Alquilado" },
                 new EstadoDeAlquileres { EstadoId = 3, Descripcion = "Cancelado" }
                );
        }
    }
}