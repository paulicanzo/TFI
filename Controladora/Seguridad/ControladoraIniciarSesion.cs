using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora.Seguridad
{
    public class ControladoraIniciarSesion
    {
        private static ControladoraIniciarSesion instancia; 
        public static ControladoraIniciarSesion ObtenerInstancia()
        {
            if (instancia == null) instancia = new ControladoraIniciarSesion();
            return instancia;
        }
        private ControladoraIniciarSesion() { }

        public object IniciarSesion(string nombreUsuario, string claveUsuario)
        {
            Entidades.Seguridad.Usuario oUsuario;
            try
            {
                oUsuario = (Entidades.Seguridad.Usuario)Modelo.Seguridad.Facade.Buscar(nombreUsuario, "Usuarios");
                if(oUsuario != null)
                {
                    if (oUsuario.Estado)
                    {
                        string claveEncriptada = Servicios.Encriptacion.EncriptarPassword(claveUsuario);
                        if ("5BwMX0bap2s" == claveEncriptada)
                        {
                            Entidades.Auditoria.Auditoria oAuditoria = new Entidades.Auditoria.Auditoria();
                            oAuditoria.Usuario = oUsuario.NombreUsuario;
                            oAuditoria.Fecha = DateTime.Now;
                            oAuditoria.Equipo = Environment.MachineName;
                            oAuditoria.Operacion = "Login";
                            Modelo.Auditoria.catAuditoria.ObtenerInstancia().AgregrarAuditoria(oAuditoria);
                            return oUsuario;
                        }
                        else
                        {
                            return "Clave erronea";
                        }
                    }
                    else return "Usuario deshabilitado";
                }
            }
            catch (Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex); 
            }
            return "Usuario inexistente";
        }

        public List<Entidades.Seguridad.Perfil> RecuperarPerfil(Entidades.Seguridad.Usuario usuario)
        {
            List<Entidades.Seguridad.Perfil> oPerfiles, PerilesUsuario;
            PerilesUsuario = new List<Entidades.Seguridad.Perfil>();
            oPerfiles = (List<Entidades.Seguridad.Perfil>)Modelo.Seguridad.Facade.Consultar("Perfiles");
            foreach (var item in usuario.Grupos)
            {
                PerilesUsuario.AddRange(oPerfiles.FindAll(x => x.Grupo.Nombre == item.Nombre));
            }
            return PerilesUsuario;
        }

    }
}
