using Domain.DTOs.PeliculaDTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Queries
{
    public interface IQueryPelicula
    {
        ResponseGetPeliculas GetPeliculaByIdQuery(int Id);
        public List<Pelicula> GetPeliculasByTitulo(string titulo);
        ResponseGetPeliculas GetPeliculaByIdQuery2(int Id);
    }
}
