using Application.Interface;
using Application.utils;

namespace Application.service
{
    internal class EstadoService: IEstadoService
    {
        private IEstadoQuerie _estadoQuerie;
        public EstadoService(IEstadoQuerie estadoQuerie)
        {
            _estadoQuerie = estadoQuerie;
        }
        public Response findOneEstado(int description)
        {
            var response = new Response(true, "Se ha encontrado el estado correctamente");
            try
            {
                var estado = _estadoQuerie.Find(description);
                if (estado == null)
                {
                    response.succes = false;
                    response.content = "No se ha encontrado a ningun Estado con esa Descripcion";
                }
                else
                {
                    response.objects = estado;
                }
                
                return response;
            }
            catch(Exception ex)
            {
                response.succes = false;
                response.content = "internal server Error";
                return response;
            }
        }
    }
}
