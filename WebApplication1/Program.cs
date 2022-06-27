using Application.ConcreteClassDecoratorPattern;
using Application.Interface;
using Application.service;
using Data;
using Data.Comman;
using Data.Queries;
using Domain.Patterns.Decorator.Clientes;
using Domain.Patterns.Decorator.Libro;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddTransient<IAlquileresCommand, CommandAlquileres>();
builder.Services.AddTransient<IAlquileresQueries, AlquileresQueries>();
builder.Services.AddTransient<IEstadoQuerie, EstadoQuerie>();
builder.Services.AddTransient<IClienteQueries, ClienteQueries>();
builder.Services.AddTransient<IClientCommand, ClientCommand>();
builder.Services.AddTransient<ILibroQueries, LibroQueries>();
builder.Services.AddTransient<IClienteService, ClienteService>();
builder.Services.AddTransient<IAlquilerService, AlquilerService>();
builder.Services.AddTransient<IApiGetLibros, ApiGetLibros>();
builder.Services.AddTransient<ILibroService, LibroService>();
builder.Services.AddTransient<IApiGetClient, ApiGetClientByNombre>();


builder.Services.AddDbContext<Data.DbContext>((DbContextOptionsBuilder options) =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
