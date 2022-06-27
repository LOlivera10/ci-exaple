using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.model
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string Dni { get; set; }
        [Column(TypeName = "varchar(45)")]
        public string Nombre { get; set; }
        [Column(TypeName = "varchar(45)")]
        public string Apellido { get; set; }
        [Column(TypeName = "varchar(45)")]
        public string Email { get; set; }
        public ICollection<Alquileres> Alquileres { get; set; }

        public Cliente(string Dni, string Nombre, string Apellido, string Email)
        {
            this.Dni = Dni;
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.Email = Email;
        }

        public override string ToString()
        {
            return Nombre+" "+Apellido+" "+Dni;
        }

    }
}
