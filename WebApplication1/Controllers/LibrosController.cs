using Application.Interface;
using Domain.model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using Application.utils;

namespace BibliotecaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private ILibroService _libroService;
        public LibrosController(ILibroService lib)
        {
            _libroService=lib;
        }
        [HttpGet]
        public async Task<IActionResult> GetLibros(bool stock,string? autor,string? titulo )
        {
            var response = _libroService.GetLibrosFilters(stock, autor, titulo);
            if (!response.succes) return new JsonResult(new { messaje = response.content }) { StatusCode=response.statusCode};
            var clearRespuesta = new LibroUtils().ClearBookAnswer(response.arrList);           
            return new JsonResult(clearRespuesta) { StatusCode = 200 };
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLibros(string id)
        {
            var responseLibro = _libroService.findOneLibro(id);
            if (!responseLibro.succes) return new JsonResult(responseLibro.content){ StatusCode = 404};
            var response = _libroService.haveStock((Libros)responseLibro.objects);
            return new JsonResult(response.content) { StatusCode=200};
        }
    }
}
