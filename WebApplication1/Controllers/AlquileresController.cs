using Application.Interface;
using BibliotecaAPI.Dto;
using Domain.model;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlquileresController : ControllerBase
    {
        private IAlquilerService _alquilerService;
        private IClienteService _clienteService;
        public AlquileresController(IAlquilerService alq, IClienteService cli)
        {
            _alquilerService = alq;
            _clienteService = cli;
        }
        [HttpPost]
        public async Task<IActionResult> PostAlquiler(AlquileresDto alqu)
        {
            var responseClient = _clienteService.findOneClientById(alqu.cliente);
            if (!responseClient.succes) return BadRequest(new { messaje = responseClient.content });
            var responseAlquiler = _alquilerService.createAlquiler((Cliente)responseClient.objects, alqu.isbn, alqu.estado);
            if (!responseAlquiler.succes) return BadRequest(new { messaje = responseAlquiler.content });
            return new JsonResult(new { messaje = responseAlquiler.content }) { StatusCode = 201 };
        }
        [HttpPut]
        public async Task<IActionResult> PutAlquiler(PutCAlquilerDto alqu)
        {
            var response = _alquilerService.putAlquiler(alqu.cliente, alqu.ISBN);
            if (!response.succes) return BadRequest(new { messaje = response.content });
            return Ok(new { messaje = response.content });
        }
        [HttpGet]
        public async Task<IActionResult> GetAlquiler(int estado)
        {
            var alquileres = _alquilerService.findAlquileres(estado);
            if (!alquileres.succes) return BadRequest(new { messaje = alquileres.content });
            var finalResult = _alquilerService.concatToLibros(alquileres);
            if (!finalResult.succes) return BadRequest(new { messaje = finalResult.content });
            return new JsonResult(finalResult.arrList) { StatusCode=200};
        }
        [HttpGet("cliente/{id}")]
        public async Task<IActionResult> GetAlquileres(int id)
        {
            var clienteExist = _clienteService.findOneClientById(id);
            if (!clienteExist.succes) return BadRequest(new { messaje = clienteExist.content });
            Cliente client = (Cliente)clienteExist.objects;
            var libroList = _alquilerService.FinByClient(id);
            if (!libroList.succes) return new JsonResult(new { error = libroList.content }) { StatusCode = 401 };
            return new JsonResult(new { 
                Cliente = client.Nombre,
                Libros = libroList.arrList
            }) { StatusCode = 200 };
        }
    }
}
