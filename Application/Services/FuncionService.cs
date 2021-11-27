using Application.InterfaceService;
using Domain;
using Domain.Commands;
using Domain.DTOs;
using Domain.DTOs.FuncionDTOs;
using Domain.DTOs.PeliculaDTOs;
using Domain.Entities;
using Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Services
{
    public class FuncionService : IFuncionService
    {
        private readonly IGenericsRepository _repository;
        private readonly IQueryGeneric _queryGeneric;
        private readonly IQueryFuncion _queryFuncion;
        private readonly IQuerySala _querySala;
        private readonly IQueryPelicula _queryPelicula;
        private readonly ITicketService _ticketService;

        public FuncionService(IGenericsRepository repository, IQueryGeneric queryGeneric, IQueryFuncion queryFuncion, IQuerySala querySala, IQueryPelicula queryPelicula, ITicketService ticketService)
        {
            _repository = repository;
            _queryGeneric = queryGeneric;
            _queryFuncion = queryFuncion;
            _querySala = querySala;
            _queryPelicula = queryPelicula;
            _ticketService = ticketService;
        }
        
        public List<ResponseAllFunciones> GetAllFunciones(string fecha, string titulo)
        {
            List<ResponseAllFunciones> ListaResponseFunciones = new List<ResponseAllFunciones>();
            var funciones = _queryFuncion.GetFuncionesByFechaActual(fecha);
            var peliculas = _queryPelicula.GetPeliculasByTitulo(titulo);
            var fechaFunciones = _queryFuncion.GetFuncionesByFecha(fecha);

            if (fecha != null || titulo != null){
                foreach (var pelicula in peliculas)
                {
                    foreach (var funcion in fechaFunciones)
                    {
                        if (funcion.PeliculaId == pelicula.PeliculaId)
                        {
                            ListaResponseFunciones.Add(funcion);
                        }
                    }
                }
            }
            else
                return funciones;

            return ListaResponseFunciones;
        }
        
        public FuncionDto CreateFuncion(FuncionDto funcion)
        {
            string[] FechaString = funcion.Fecha.Split('/');
            DateTime FechaDateTime = new DateTime(int.Parse(FechaString[0]), int.Parse(FechaString[1]), int.Parse(FechaString[2]));

            string[] HoraString = funcion.Horario.Split(':');
            TimeSpan HoraTimeSpan = new TimeSpan(int.Parse(HoraString[0]), int.Parse(HoraString[1]), 0);

            var entity = new Funcion
            {
                Fecha = FechaDateTime,
                Horario = HoraTimeSpan,
                PeliculaId = funcion.PeliculaId,
                SalaId = funcion.SalaId
            };

            _repository.Add(entity);

            return new FuncionDto { Fecha = entity.Fecha.ToShortDateString().ToString(), Horario = entity.Horario.ToString(), PeliculaId = entity.PeliculaId, SalaId = entity.SalaId };
        }
        
        public ResponseAllFunciones DeleteFuncion(int id)
        {
            var funcionDelete = _queryFuncion.GetFuncionByIdQuery(id);
            _repository.Delete<Funcion>(id);
            return funcionDelete;
        }
        
        public CustomResponse<ResponseAllFunciones> ValidadorDelete(string funcionId)
        {
            var response = new CustomResponse<ResponseAllFunciones>();
            int fId;
            bool resultado = int.TryParse(funcionId, out fId);

            if (resultado)
            {
                var listaFunciones = _queryGeneric.GetAll<Funcion>();
                listaFunciones.ForEach(funcion =>
                {
                    if (fId == funcion.FuncionId)
                    {
                        resultado = false;
                    }
                });

                if (!resultado)
                {
                    var funcion = _queryFuncion.GetFuncionByIdQuery(fId);
                    response.Data = funcion;
                }
                else
                    response.Errors.Add("No hay una función registrada con ese id");
            }
            else
                response.Errors.Add("Ingresó un dato incorrecto, por favor ingrese un número de id de función");

            return response;
        }
        
        public List<FuncionDto> GetFuncionesByPeliculaId(int PeliculaId)
        {
            List<FuncionDto> ListaFuncionesResponse = new List<FuncionDto>();
            var ListaFunciones = _queryGeneric.GetAll<Funcion>();

            foreach (var funcion in ListaFunciones)
            {
                if (funcion.PeliculaId == PeliculaId)
                {
                    ListaFuncionesResponse.Add(new FuncionDto
                    {
                        PeliculaId = funcion.PeliculaId,
                        SalaId = funcion.SalaId,
                        Fecha = funcion.Fecha.ToShortDateString(),
                        Horario = funcion.Horario.ToString()
                    });
                }
            }
            return ListaFuncionesResponse;
        }
        
        public int GetTicketsAvailabilityByFuncionId(int funcionId)
        {
            return _ticketService.TicketsDisponibles(funcionId);
        }
        
        public CustomResponse<ResponseAllFunciones> ValidadorFuncionFechaTitulo(string fecha, string titulo)
        {
            var response = new CustomResponse<ResponseAllFunciones>();
            bool resultado = true;
            if (fecha != null)
            {
                DateTime dt;
                resultado = DateTime.TryParse(fecha, out dt);

                if (resultado)
                {
                    var listaFunciones = _queryGeneric.GetAll<Funcion>();
                    listaFunciones.ForEach(funcion =>
                    {
                        if (dt == funcion.Fecha)
                        {
                            resultado = false;
                        }
                    });

                    if (!resultado)
                    {
                        var funciones = GetAllFuncionesByTitulo(titulo);
                        if (funciones.Count != 0)
                        {
                            response.Data2 = funciones;
                        }
                        else
                            response.Errors.Add("No hay una función registrada con ese titulo de película");
                    }
                    else
                        response.Errors.Add("No hay una funcion registrada con esa fecha");
                }
                else
                    response.Errors.Add("Ingresó un formato de fecha incorrecta, por favor ingrese nuevamente con el formato correcto (YYYY/MM/DD)");
            }
            else
            {
                if(titulo != null)
                {
                    var funciones = GetAllFuncionesByTitulo(titulo);
                    if (funciones.Count != 0)
                    {
                        response.Data2 = funciones;
                    }
                    else
                        response.Errors.Add("No hay una función registrada con ese titulo de película");
                }
            }
            return response;
        }
        
        public List<ResponseAllFunciones> GetAllFuncionesByTitulo(string Titulo)
        {
            return _queryFuncion.GetAllFuncionesByPeliculaTitulo(Titulo);
        }
        
        public CustomResponse<FuncionDto> ValidadorFuncion(FuncionDto funcion)
        {
            var response = new CustomResponse<FuncionDto>();
            int pId, lId;
            bool resultado = int.TryParse(funcion.PeliculaId.ToString(), out pId);

            if (resultado)
            {
                var listaPeliculas = _queryGeneric.GetAll<Pelicula>();
                listaPeliculas.ForEach(pelicula =>
                {
                    if (pId == pelicula.PeliculaId)
                    {
                        resultado = false;
                    }
                });

                if (!resultado)
                {
                    resultado = int.TryParse(funcion.SalaId.ToString(), out lId);
                    if (resultado)
                    {
                        var listaSalas = _queryGeneric.GetAll<Sala>();
                        listaSalas.ForEach(sala =>
                        {
                            if (lId == sala.SalaId)
                            {
                                resultado = false;
                            }
                        });

                        if (!resultado)
                        {
                            DateTime dt;
                            resultado = DateTime.TryParse(funcion.Fecha, out dt);

                            if (resultado)
                            {
                                TimeSpan ts;
                                resultado = TimeSpan.TryParse(funcion.Horario, out ts);
                                if (resultado)
                                {
                                    response.Data = funcion;
                                }
                                else
                                    response.Errors.Add("Ingresó un formato de horario incorrecto, por favor ingrese nuevamente con el formato correcto (HH:MM)");
                            }
                            else
                                response.Errors.Add("Ingresó un formato de fecha incorrecta, por favor ingrese nuevamente con el formato correcto (YYYY/MM/DD)");

                        }
                        else
                            response.Errors.Add("No hay una sala registrada con ese id");

                    }
                    else
                        response.Errors.Add("Ingresó un dato incorrecto, por favor ingrese un número de id de sala");
                }
                else
                    response.Errors.Add("No hay una película registrada con ese id");
            }
            else
                response.Errors.Add("Ingresó un dato incorrecto, por favor ingrese un número de id de pelicula");

            return response;
        }
        
        public CustomResponse<ResponseGetPeliculas> ValidadorFuncionByPeliculaId(string peliculaId)
        {
            var response = new CustomResponse<ResponseGetPeliculas>();
            int pId;
            bool resultado = int.TryParse(peliculaId, out pId);

            if (resultado)
            {
                var listaPeliculas = _queryGeneric.GetAll<Pelicula>();
                listaPeliculas.ForEach(pelicula =>
                {
                    if (pId == pelicula.PeliculaId)
                    {
                        resultado = false;
                    }
                });

                if (!resultado)
                {
                    var pelicula = _queryPelicula.GetPeliculaByIdQuery(pId);
                    response.Data = pelicula;
                }
                else
                    response.Errors.Add("No hay una película registrada con ese id");
            }
            else
                response.Errors.Add("Ingresó un dato incorrecto, por favor ingrese un número de id de pelicula");

            return response;
        }
        
        public CustomResponse<ResponseAllFunciones> ValidadorFuncionById(string funcionId)
        {
            var response = new CustomResponse<ResponseAllFunciones>();
            int fId;
            bool resultado = int.TryParse(funcionId, out fId);

            if (resultado)
            {
                var listaFunciones = _queryGeneric.GetAll<Funcion>();
                listaFunciones.ForEach(funcion =>
                {
                    if (fId == funcion.FuncionId)
                    {
                        resultado = false;
                    }
                });

                if (!resultado)
                {
                    var funcion = _queryFuncion.GetFuncionByIdQuery(fId);
                    response.Data = funcion;
                }
                else
                    response.Errors.Add("No hay una función registrada con ese id");

            }
            else
                response.Errors.Add("Ingresó un dato incorrecto, por favor ingrese un número de id de función");
            return response;
        }

    }
}
