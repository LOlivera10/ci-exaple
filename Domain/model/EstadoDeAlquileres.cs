using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain.model
{
    public class EstadoDeAlquileres
    {
        [Key]
        public int EstadoId { get; set; }
        public string Descripcion { get; set; }
        public ICollection<Alquileres> Alquileres { get; set; }
       
    }
}
