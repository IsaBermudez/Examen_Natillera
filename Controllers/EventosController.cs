using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Examen_Natillera.Controllers
{
    public class EventosController : ApiController
    {
        [RoutePrefix("api/Eventos")]
        public class EventosController : ApiController
        {
            [HttpGet]
            [Route("ConsultarTodos")]
            public List<Evento> ConsultarTodos()
            {
                clsEventos Evento = new clsEventos();
                return Evento.ConsultarTodos();
            }

            [HttpGet]
            [Route("Consultar")]
            public Evento consultar(int id)
            {
                clsEventos Evento = new clsEventos();
                return Evento.Consultar(id);
            }

            [Route("ConsultarXTipo")]
            public List<Evento> ConsultarXTipo(string tipo)
            {
                clsEventos Evento = new clsEventos();
                return Evento.ConsultarXTipo(tipo);
            }


            [Route("ConsultarXNombre")]
            public Evento ConsultarXNombre(string nombre)
            {
                clsEventos Evento = new clsEventos();
                return Evento.ConsultarXNombre(nombre);
            }

            [Route("ConsultarPorFecha")]
            public List<Evento> ConsultarEventosPorFecha(DateTime fecha)
            {
                clsEventos Evento = new clsEventos();
                return Evento.ConsultarEventosPorFecha(fecha );
            }

            [HttpPost]
            [Route("Insertar")]
            public String Insertar([FromBody] Evento Even)
            {
                clsEventos Evento = new clsEventos();
                Evento.evento = Even;
                return Evento.Insertar();
            }

            [HttpPut]
            [Route("Actualizar")]
            public String Actualizar([FromBody] Evento Even)
            {
                clsEventos Evento = new clsEventos();
                Evento.evento = Even;
                return Evento.Actualizar();
            }

            [HttpDelete]
            [Route("Eliminar")]
            public String Eliminar(int id)
            {
                clsEventos Evento = new clsEventos();
                return Evento.Eliminar(id);
            }
        }
    }