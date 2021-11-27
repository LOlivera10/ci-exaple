using Domain;
using Domain.DTOs;
using Domain.DTOs.FuncionDTOs;
using Domain.DTOs.PeliculaDTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.InterfaceService
{
    public interface IFuncionService
    {
        FuncionDto CreateFuncion(FuncionDto funcion);
        ResponseAllFunciones DeleteFuncion(int id);
        CustomResponse<ResponseAllFunciones> ValidadorDelete(string funcionId);
        List<FuncionDto> GetFuncionesByPeliculaId(int PeliculaId);
        int GetTicketsAvailabilityByFuncionId(int Id);
        List<ResponseAllFunciones> GetAllFunciones(string Fecha, string Titulo);
        CustomResponse<ResponseAllFunciones> ValidadorFuncionFechaTitulo(string fecha, string titulo);
        CustomResponse<FuncionDto> ValidadorFuncion(FuncionDto funcion);
        CustomResponse<ResponseGetPeliculas> ValidadorFuncionByPeliculaId(string peliculaId);
        CustomResponse<ResponseAllFunciones> ValidadorFuncionById(string funcionId);
    }
}
