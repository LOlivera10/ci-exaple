using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dni = table.Column<string>(type: "varchar(10)", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(45)", nullable: false),
                    Apellido = table.Column<string>(type: "varchar(45)", nullable: false),
                    Email = table.Column<string>(type: "varchar(45)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "EstadoDeAlquileres",
                columns: table => new
                {
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoDeAlquileres", x => x.EstadoId);
                });

            migrationBuilder.CreateTable(
                name: "Libros",
                columns: table => new
                {
                    ISBN = table.Column<string>(type: "varchar(50)", nullable: false),
                    Titulo = table.Column<string>(type: "varchar(45)", nullable: false),
                    Autor = table.Column<string>(type: "varchar(45)", nullable: false),
                    Editorial = table.Column<string>(type: "varchar(45)", nullable: false),
                    Edicion = table.Column<string>(type: "varchar(45)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libros", x => x.ISBN);
                });

            migrationBuilder.CreateTable(
                name: "Alquileres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clienteId = table.Column<int>(type: "int", nullable: false),
                    isbnId = table.Column<string>(type: "varchar(50)", nullable: false),
                    estadoId = table.Column<int>(type: "int", nullable: false),
                    FechaAlquieler = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaReserva = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaDevolucion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alquileres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alquileres_Clientes_clienteId",
                        column: x => x.clienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alquileres_EstadoDeAlquileres_estadoId",
                        column: x => x.estadoId,
                        principalTable: "EstadoDeAlquileres",
                        principalColumn: "EstadoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alquileres_Libros_isbnId",
                        column: x => x.isbnId,
                        principalTable: "Libros",
                        principalColumn: "ISBN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EstadoDeAlquileres",
                columns: new[] { "EstadoId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Reservado" },
                    { 2, "Alquilado" },
                    { 3, "Cancelado" }
                });

            migrationBuilder.InsertData(
                table: "Libros",
                columns: new[] { "ISBN", "Autor", "Edicion", "Editorial", "Imagen", "Stock", "Titulo" },
                values: new object[,]
                {
                    { "9786075277851", "Robert Greene", "001", "Oceano", "https://images.cdn3.buscalibre.com/fit-in/360x360/8c/40/8c40d2433efdea2ef6c91cf2f16c1135.jpg", 4, "El Arte de la Seduccion" },
                    { "9786287544079", "Gleen Black", "001", "Sin Fronteras Grupo Editorial", "https://images.cdn3.buscalibre.com/fit-in/360x360/9b/27/9b272c321c2616e64a855bf8c6034cbb.jpg", 7, "BRATVA" },
                    { "9788418052187", "Alejandro Jodorowsky", "001", "Reservoir Books", "https://images.cdn2.buscalibre.com/fit-in/360x360/15/05/15051197af8f0a016247e1cc176738b8.jpg", 2, "La Casta de los Metabarones" },
                    { "9788424653491", "Miguel De Cervantes", "001", "La Galera", "https://images.cdn1.buscalibre.com/fit-in/360x360/a5/35/a5359eb612f3f5b42fe8addbc0950f53.jpg", 3, "Don Quijote de la Mancha" },
                    { "9788466357913", "Elena Ferrante", "001", "Debolsillo", "https://images.cdn1.buscalibre.com/fit-in/360x360/e1/a9/e1a9cabdf6a6e77043d564ae91ce8f6a.jpg", 6, "Saga dos Amigas" },
                    { "9789507301131", "Dross", "001", "Temas De Hoy", "https://images.cdn2.buscalibre.com/fit-in/360x360/83/63/8363e7713727af1a04591376c1d9af50.jpg", 30, "El Festival de la Blasfemia" },
                    { "9789508701695", "Dross", "001", "Martinez Roca", "https://images.cdn1.buscalibre.com/fit-in/360x360/a3/ad/a3ad3aa75860ff13996e6be80c3b0cbb.jpg", 5, "Escape" },
                    { "9789584282613", "Dross", "001", "Grupo Planeta", "https://images.cdn1.buscalibre.com/fit-in/360x360/97/66/976684737c819ca0af8e67f75bf113ba.jpg", 7, "El Libro Negro" },
                    { "9789875809659", "Dross", "001", "Booket", "https://images.cdn1.buscalibre.com/fit-in/360x360/93/1d/931d2a5a6c9ab4c117f34dd704c52749.jpg", 10, "Luna de Pluton" },
                    { "9871093225", "Robert Stevenson", "001", "Gradifco", "https://image.cdn0.buscalibre.com/2817664.__RS360x360__.jpg", 9, "El diablo en la botella" },
                    { "9875731994", "Valentino E.", "001", "Sm", "https://images.cdn1.buscalibre.com/fit-in/360x360/cb/b7/cbb71b617b8030055f6d1c126154f08e.jpg", 7, "Perros de Nadie" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alquileres_clienteId",
                table: "Alquileres",
                column: "clienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Alquileres_estadoId",
                table: "Alquileres",
                column: "estadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Alquileres_isbnId",
                table: "Alquileres",
                column: "isbnId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alquileres");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "EstadoDeAlquileres");

            migrationBuilder.DropTable(
                name: "Libros");
        }
    }
}
