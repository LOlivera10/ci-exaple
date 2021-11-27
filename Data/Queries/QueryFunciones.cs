using Domain.DTOs.FuncionDTOs;
using Domain.Entities;
using Domain.Queries;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Data.Queries
{
    public class QueryFunciones : IQueryFuncion
    {
        private readonly IDbConnection connection;
        private readonly Compiler sqlKataCompiler;

        public QueryFunciones(IDbConnection connection, Compiler sqlKataCompiler)
        {
            this.connection = connection;
            this.sqlKataCompiler = sqlKataCompiler;
        }

        public List<ResponseAllFunciones> GetFuncionesByFechaActual(string fecha)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);
            List<ResponseAllFunciones> ListaResponseFunciones = new List<ResponseAllFunciones>();

            var funciones = db.Query("Funciones")
                    .Select("Funciones.PeliculaId", "Funciones.SalaId", "Funciones.Fecha", "Funciones.Horario")
                    .When(!string.IsNullOrWhiteSpace(fecha), t => t.Where("Funciones.Fecha", "=", fecha))
                    .OrderBy("Fecha")
                    .Where("Funciones.Fecha", "=", DateTime.Today)
                    .Get<ResponseAllFunciones>().ToList();

            foreach (var item in funciones)
            {
                ListaResponseFunciones.Add(new ResponseAllFunciones
                {
                    PeliculaId = item.PeliculaId,
                    SalaId = item.SalaId,
                    Fecha = item.Fecha,
                    Horario = item.Horario
                });
            }

            return ListaResponseFunciones;
        }

        public List<ResponseAllFunciones> GetFuncionesByFecha(string fecha)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);
            List<ResponseAllFunciones> ListaResponseFunciones = new List<ResponseAllFunciones>();

            var funciones = db.Query("Funciones")
                    .Select("Funciones.PeliculaId", "Funciones.SalaId", "Funciones.Fecha", "Funciones.Horario")
                    .When(!string.IsNullOrWhiteSpace(fecha), t => t.Where("Funciones.Fecha", "=", fecha))
                    .OrderBy("Fecha")
                    .Get<ResponseAllFunciones>().ToList();

            foreach (var item in funciones)
            {
                ListaResponseFunciones.Add(new ResponseAllFunciones
                {
                    PeliculaId = item.PeliculaId,
                    SalaId = item.SalaId,
                    Fecha = item.Fecha,
                    Horario = item.Horario
                });
            }

            return ListaResponseFunciones;
        }

        public ResponseAllFunciones GetFuncionByIdQuery(int funcionId)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);
            var query = db.Query("Funciones")
                .Where("FuncionId", "=", funcionId)
                .FirstOrDefault<ResponseAllFunciones>();

            return new ResponseAllFunciones
            {
                Fecha = query.Fecha,
                Horario = query.Horario,
                PeliculaId = query.PeliculaId,
                SalaId = query.SalaId
            };
        }

        public List<ResponseAllFunciones> GetAllFuncionesByPeliculaTitulo(string titulo)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);
            List<ResponseAllFunciones> ListaResponseFunciones = new List<ResponseAllFunciones>();

            var peliculas = db.Query("Peliculas")
                .Select("Peliculas.PeliculaId", "Peliculas.Titulo", "Peliculas.Poster", "Peliculas.Sinopsis", "Peliculas.Trailer")
                .When(!string.IsNullOrWhiteSpace(titulo), t => t.Where("Peliculas.Titulo", "=", titulo)).Get<Pelicula>().ToList();

            foreach (var pelicula in peliculas)
            {
                var funcion = db.Query("Funciones")
                            .Select("PeliculaId", "SalaId", "Fecha", "Horario")
                            .Where("PeliculaId", "=", pelicula.PeliculaId)
                            .FirstOrDefault<ResponseAllFunciones>();

                if (funcion != null)
                {
                    ListaResponseFunciones.Add(new ResponseAllFunciones
                    {
                        PeliculaId = funcion.PeliculaId,
                        SalaId = funcion.SalaId,
                        Fecha = funcion.Fecha,
                        Horario = funcion.Horario
                    });
                }
            }
            return ListaResponseFunciones;
        }
    }
}
