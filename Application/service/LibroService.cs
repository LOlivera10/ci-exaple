using System.Collections;
using Application.utils;
using Domain.model;
using Application.Interface;
using Domain.Patterns.Decorator.Libro;
using Domain.Patterns.Decorator.Libro.ConcreteDecorators;

namespace Application.service
{
    public class LibroService: ILibroService
    {
        private ILibroQueries _libroQueries;
        private IApiGetLibros _apiLibros;
        public LibroService(ILibroQueries lib, IApiGetLibros apiLib)
        {
            _libroQueries = lib;
            _apiLibros = apiLib;
        }
        public Response findLibroWhitStock()
        {
            var response = new Response(true, "Se ha encontrado el libro correctamente");
            response.arrList = new ArrayList();
            try
            {

                var LibroList = _libroQueries.findWhitStock();
                if (LibroList.Count == 0)
                {
                    response.succes = false;
                    response.content = "No se ha encontrado ningun libro";
                }
                else
                {
                    foreach (var Libro in LibroList)
                    {
                        response.arrList.Add(Libro);
                    }
                }
                return response;
            }
            catch
            {
                response.succes = false;
                response.content = "internal server error";
                return response;
            }
        }
      public Response haveStock(Libros lib)
        {
            var response = new Response(true, "Este libro tiene "+lib.Stock+" stock");
            if(lib.Stock <= 0)
            {
                response.succes = false;
                response.content = "Este libro no tiene Stock";
            }
            return response;
        }
        public Response findOneLibro(string isbn)
        {
            var response = new Response(true, "Se ha encontrado el libro correctamente");
            try
            {
                var lib = _libroQueries.findOneLibro(isbn);
                if (lib == null)
                {
                    response.succes = false;
                    response.content = "No se ha encontrado ningun libro con ese isbn";
                }
                else
                {
                    response.objects = lib;
                }
                return response;
            }
            catch
            {
                response.succes = false;
                response.content = "internal server error";
                return response;
            }
        }
        public Response GetLibrosFilters(bool stock, string nombre, string titulo)
        {
            var response = new Response(true, "se han devuelto los libros correctamente");
            IApiGetLibros finalResult= _apiLibros;
            ArrayList arr = new ArrayList();
            try
            {
                if (stock)
                {
                    finalResult = new FilterWithStock(finalResult);
                }
                if (nombre != null && nombre != "")
                {
                    finalResult = new FilterWhitAuthorName(finalResult, nombre);
                }
                if (titulo != null && titulo != "") 
                {
                    finalResult = new FilterWithTitle(finalResult, titulo);
                }
                if (!stock && nombre== null && titulo==null )
                {
                    
                    response.arrList = _apiLibros.GetLibros();
                    return response;
                }
                var result = finalResult.GetLibros();
                response.arrList = result;
                if (response.arrList.Count == 0)
                {
                    response.content = "no se ha encontrado ningun resultado";
                    response.succes = false;
                    response.statusCode = 404;
                }
                return response;
            }
            catch
            {
                response.succes = false;
                response.content = "Internal server error";
                response.statusCode = 500;
                return response;
            }
            
        }
    }
}
