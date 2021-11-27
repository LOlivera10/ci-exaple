using Application.InterfaceService;
using Domain.DTOs.TicketDTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPIndividualCine.Controllers
{
    [Route("api/ticket")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _service;

        public TicketController(ITicketService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Post(ResponseTickets ticket)
        {
            var response = _service.ValidadorTicket(ticket);

            if (response.IsValid)
            {
                var lista = new List<TicketDto>();

                for (int i = 0; i < ticket.Cantidad; i++)
                {
                    lista.Add(_service.CreateTicket(ticket));
                }

                return new JsonResult(lista) { StatusCode = 201 };
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
