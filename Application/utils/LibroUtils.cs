using Domain.model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.utils
{
    public class LibroUtils
    {
        public ArrayList ClearBookAnswer(ArrayList arr)
        {
            ArrayList responseArray = new ArrayList();
            foreach (Libros lib in arr)
            {
                responseArray.Add(new
                {
                    ISBN = lib.ISBN,
                    Titulo = lib.Titulo,
                    Autor = lib.Autor,
                    Editorial = lib.Editorial,
                    Edicion = lib.Edicion,
                    Stock = lib.Stock,
                    Img = lib.Imagen
                });   
            }
            return responseArray;
        }
    }
}
