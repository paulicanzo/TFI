using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora.Seguridad
{
    public class ControladoraRecuperarClave
    {
        private static ControladoraRecuperarClave instancia; 
        public static ControladoraRecuperarClave ObtenerInstancia()
        {
            if (instancia == null) instancia = new ControladoraRecuperarClave();
            return instancia;
        }
        private ControladoraRecuperarClave() { }

        public bool RecuperarClave(string NombreUsuario)
        {
            Entidades.Seguridad.Usuario usuario = (Entidades.Seguridad.Usuario)Modelo.Seguridad.Facade.Buscar(NombreUsuario, "Usuarios");
            if (usuario == null) return false;
            else
            {
                string clave = Servicios.Encriptacion.DesencriptarPassword(usuario.Clave);
                Servicios.MailSender.EnviarMail(usuario.CorreoElectronico, "Su clave es: " + clave, "Clave de acceso");
                return true;
            }
        }
    }
}

