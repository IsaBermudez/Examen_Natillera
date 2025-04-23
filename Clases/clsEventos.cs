using Examen_Natillera.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Examen_Natillera.Clases
{
    public class clsEventos
    {
        private dbNatilleraEntities dbExamen = new dbNatilleraEntities();
        public Evento evento { get; set; }

        public List<Evento> ConsultarTodos()
        {

            return dbExamen.Eventos.OrderBy(t => t.idAdministrador).ToList();
        }
        public Evento Consultar(int id)
        {
            return dbExamen.Eventos.FirstOrDefault(t => t.idEventos == id);
        }
        public List<Evento> ConsultarXTipo(string tipo)
        {
            return dbExamen.Eventos
                .Where(t => t.TipoEvento == tipo).ToList();
        }

        public Evento ConsultarXNombre(string nombre)
        {
            return dbExamen.Eventos.FirstOrDefault(t => t.NombreEvento == nombre);
        }

        public List<Evento> ConsultarEventosPorFecha(DateTime fecha)
        {
            return dbExamen.Eventos
                           .Where(e => e.FechaEvento == fecha)
                           .ToList();
        }
        public String Insertar()
        {
            try
            {
                dbExamen.Eventos.Add(evento);
                dbExamen.SaveChanges();
                return "Se grabo el evento: " + evento.NombreEvento + " en la base de datos ";
            }
            catch (Exception ex)
            {
                return "El evento no se pudo insertar" + ex.Message;
            }
        }
        public String Actualizar()
        {
            try
            {
                Evento eve = Consultar(evento.idEventos);
                if (eve == null)
                {
                    return "El evento no existe";
                }
                dbExamen.Eventos.AddOrUpdate(evento);
                dbExamen.SaveChanges();//guarda los cambios a la base de datos
                return "Evento actualizado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al actualizar el evento " + ex.Message;
            }
        }



        public String Eliminar(int id)
        {
            try
            {
                Evento eve = Consultar(id);
                if (eve == null)
                {
                    return "El evento no existe";
                }
                dbExamen.Eventos.Remove(eve);
                dbExamen.SaveChanges();//guarda los cambios a la base de datos
                return "Evento eliminado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al eliminar el evento " + ex.Message;
            }
        }

      
    }
}