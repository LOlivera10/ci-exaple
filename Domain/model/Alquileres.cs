using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.model
{
    public class Alquileres
    {
        public int Id { get; set; }

        [ForeignKey("ClienteId")]
        [Required(ErrorMessage = "El campo ClienteId es Requerido")]
        public int clienteId { get; set; }
        public Cliente Cliente { get; set; }

        [ForeignKey("ISBN")]
        public string isbnId { get; set; } 
        public Libros Isbn { get; set; }

        [ForeignKey("EstadoId")]
        [Required(ErrorMessage = "El campo EstadoId es Requerido")]
        public int estadoId { get; set; }
        public EstadoDeAlquileres Estado { get; set; }

        public DateTime ? FechaAlquieler { get; set; } = null;
        public DateTime ? FechaReserva { get; set; } = null;
        public DateTime ? FechaDevolucion { get; set; } = null;

        public override string ToString()
        {
            return clienteId + " " + isbnId + " " + estadoId;
        }


    }
}
