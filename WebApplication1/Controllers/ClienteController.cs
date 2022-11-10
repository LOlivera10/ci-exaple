using Application.Interface;
using BibliotecaAPI.Dto;
using Domain.model;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private IClienteService _clienteService;
        public ClienteController(IClienteService cli)
        {
            _clienteService = cli;
        }
        [HttpPost]
        public async Task<IActionResult> postUser(ClienteDto cli)
        {

            var response = _clienteService.CreateModelClient(cli.Dni, cli.Nombre, cli.Apellido, cli.Email);
            if (!response.succes)
            {
                return BadRequest(new { error = response.content });
            }
            var creation = _clienteService.CreateClient((Cliente)response.objects);
            if (!creation.succes)
            {
                return BadRequest(new { error = creation.content });
            }
            return new JsonResult(new { message = creation.content }) { StatusCode = 201 };
        }
        [HttpGet]
        public async Task<IActionResult> getCliente(string? nombre, string? apellido, string? dni)
        {
            var response = _clienteService.GetClienteByParams(nombre, apellido, dni);
            if (!response.succes)
            {
                return BadRequest(new { error = response.content });
            }
            return Ok(response.arrList);
        }
    }
}
