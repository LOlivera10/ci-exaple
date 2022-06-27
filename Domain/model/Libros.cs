using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.model
{
    public class Libros
    {
        [Key]
        [Column(TypeName = "varchar(50)")]
        public string ISBN { get; set; }

        [Column(TypeName = "varchar(45)")]
        public string Titulo { get; set; }
        [Column(TypeName = "varchar(45)")]
        public string Autor { get; set; }

        [Column(TypeName = "varchar(45)")]
        public string Editorial { get; set; }

        [Column(TypeName = "varchar(45)")]
        public string Edicion { get; set; }
        public int Stock { get; set; }
        public string Imagen { get; set; }
        public List<Alquileres> Alquileres { get; set; }
        public Libros(string ISBN, string Titulo,string Autor, string Editorial, string Edicion, int Stock, string Imagen)
        {
            this.ISBN = ISBN;
            this.Titulo = Titulo;
            this.Autor = Autor;
            this.Editorial = Editorial;
            this.Edicion = Edicion;
            this.Stock = Stock;
            this.Imagen = Imagen;
        }

    }
}
