using Domain.DTOs;
using Domain.DTOs.FuncionDTOs;
using Domain.DTOs.PeliculaDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Queries
{
    public interface IQueryFuncion
    {
        ResponseAllFunciones GetFuncionByIdQuery(int funcionId);
        List<ResponseAllFunciones> GetFuncionesByFechaActual(string fecha);
        List<ResponseAllFunciones> GetFuncionesByFecha(string fecha);
        List<ResponseAllFunciones> GetAllFuncionesByPeliculaTitulo(string titulo);
    }
}
