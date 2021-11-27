using Application.InterfaceService;
using Domain.DTOs;
using Domain.DTOs.FuncionDTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace TPIndividualCine.Controllers
{
    [Route("api/funcion")]
    [ApiController]
    public class FuncionController : ControllerBase
    {
        private readonly IFuncionService _service;

        public FuncionController(IFuncionService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAllFunciones([FromQuery] string fecha, [FromQuery] string titulo)
        {
            var response = _service.ValidadorFuncionFechaTitulo(fecha, titulo);

            if (response.IsValid)
            {
                return new JsonResult(_service.GetAllFunciones(fecha, titulo)) { StatusCode = 200 };
            }
            else
            {
                string DevolverErrores = "";
                foreach (var error in response.Errors)
                {
                    DevolverErrores += error;
                }
                return new JsonResult(DevolverErrores) { StatusCode = 400 };
            }
        }

        [HttpPost]
        public IActionResult Post(FuncionDto funcion)
        {
            var response = _service.ValidadorFuncion(funcion);

            if (response.IsValid)
            {
                return new JsonResult(_service.CreateFuncion(funcion)) { StatusCode = 201 };
            }
            else
            {
                string DevolverErrores = "";
                foreach (var error in response.Errors)
                {
                    DevolverErrores += error;
                }
                return new JsonResult(DevolverErrores) { StatusCode = 400 };
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var response = _service.ValidadorDelete(id);
            if (response.IsValid)
            {
                return new JsonResult(_service.DeleteFuncion(int.Parse(id)));
            }
            else
            {
                string DevolverErrores = "";
                foreach (var error in response.Errors)
                {
                    DevolverErrores += error;
                }
                return new JsonResult(DevolverErrores) { StatusCode = 400 };
            }
        }

        [Route("pelicula/{peliculaId}")]
        [HttpGet]
        public IActionResult GetFuncionesByPeliculaId(string peliculaId)
        {
            var response = _service.ValidadorFuncionByPeliculaId(peliculaId);

            if (response.IsValid)
            {
                return new JsonResult(_service.GetFuncionesByPeliculaId(int.Parse(peliculaId))) { StatusCode = 200 };
            }
            else
            {
                string DevolverErrores = "";
                foreach (var error in response.Errors)
                {
                    DevolverErrores += error;
                }
                return new JsonResult(DevolverErrores) { StatusCode = 400 };
            }

        }

        [Route("{id}/tickets")]
        [HttpGet]
        public IActionResult GetTicketsAvailabilityByFuncionId(string id)
        {
            var response = _service.ValidadorFuncionById(id);

            if (response.IsValid)
            {
                return new JsonResult(_service.GetTicketsAvailabilityByFuncionId(int.Parse(id))) { StatusCode = 200 };
            }
            else
            {
                string DevolverErrores = "";
                foreach (var error in response.Errors)
                {
                    DevolverErrores += error;
                }
                return new JsonResult(DevolverErrores) { StatusCode = 400 };
            }

        }

    }
}
