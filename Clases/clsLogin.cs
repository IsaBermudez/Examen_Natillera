using Examen_Natillera.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen_Natillera.Clases
{
    public class clsLogin
    {
        public clsLogin()
        {
            loginRespuesta = new LoginRespuesta();
        }
        public Login login { get; set; }
        public LoginRespuesta loginRespuesta { get; set; }
        private dbNatilleraEntities dbExamen = new dbNatilleraEntities();



        public bool ValidarUsuario()
        {
            try
            {
                Administrador admi = dbExamen.Administradors.FirstOrDefault(u => u.Usuario == login.Usuario);
                if (admi == null)
                {
                    // el usuario no existe, se retorna un error 
                    loginRespuesta.Autenticado = false;
                    loginRespuesta.Mensaje = "El administrador no existe";
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                loginRespuesta.Autenticado = false;
                loginRespuesta.Mensaje = ex.Message;
                return false;
            }
        }
        private bool ValidarClave()
        {
            try
            {
                Administrador admi = dbExamen.Administradors.FirstOrDefault(u => u.Usuario == login.Usuario && u.Clave == login.Clave);
                if (admi == null)
                {
                    // la clave no es igual 
                    loginRespuesta.Autenticado = false;
                    loginRespuesta.Mensaje = "La clave no coincide";
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                loginRespuesta.Autenticado = false;
                loginRespuesta.Mensaje = ex.Message;
                return false;
            }
        }

        public IQueryable<LoginRespuesta> Ingresar()
        {
            if (ValidarUsuario() && ValidarClave())
            {
                string token = TokenGenerator.GenerateTokenJwt(login.Usuario);
                return from U in dbExamen.Set<Administrador>()
                       where U.Usuario == login.Usuario &&
                               U.Clave == login.Clave
                       select new LoginRespuesta
                       {
                           Usuario = U.Usuario,
                           Autenticado = true,
                           Token = token,
                           Mensaje = ""
                       };
            }
            else
            {
                List<LoginRespuesta> List = new List<LoginRespuesta>();
                List.Add(loginRespuesta);
                return List.AsQueryable();
            }
        }
    }
}
