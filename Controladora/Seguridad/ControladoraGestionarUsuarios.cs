using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora.Seguridad
{
    public class ControladoraGestionarUsuarios
    {
        private static ControladoraGestionarUsuarios instancia; 
        public static ControladoraGestionarUsuarios ObtenerInstancia()
        {
            if (instancia == null) instancia = new ControladoraGestionarUsuarios();
            return instancia; 
        }

        public List<Entidades.Seguridad.Usuario> RecuperarUsuario()
        {
            List<Entidades.Seguridad.Usuario> usuarios = new List<Entidades.Seguridad.Usuario>();
            try
            {
                usuarios = (List<Entidades.Seguridad.Usuario>)Modelo.Seguridad.Facade.Consultar("Usuarios");
            }
            catch (Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
            }
            return usuarios;
        }

        public bool AgregarUsuario(Entidades.Seguridad.Usuario usuario)
        {
            try
            {
                Entidades.Seguridad.Usuario noEncontrado = (Entidades.Seguridad.Usuario)Modelo.Seguridad.Facade.Buscar(usuario.NombreUsuario, "Usuarios");
                if(noEncontrado == null)
                {
                    string randompass = Servicios.GenerarPassword.CrearContraseñaAleatoria(8);
                    string passencriptado = Servicios.Encriptacion.EncriptarPassword(randompass);
                    usuario.CambiarClave(usuario.Clave, passencriptado);
                    Modelo.Seguridad.Facade.Agregar(usuario);
                    Servicios.MailSender.EnviarMail(usuario.CorreoElectronico, randompass, "Password de usuario");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex); 
            }
            return false;
        }

        public bool ModificarUsuario(Entidades.Seguridad.Usuario usuario)
        {
            try
            {
                Modelo.Seguridad.Facade.Modificar(usuario);
                return true;
            }
            catch (Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
                return false;
            }
        }

        public bool ResetearClave(Entidades.Seguridad.Usuario usuario)
        {
            try
            {
                string clave;
                clave = Servicios.GenerarPassword.CrearContraseñaAleatoria(8);
                string claveEncriptada;
                claveEncriptada = Servicios.Encriptacion.EncriptarPassword(clave);
                usuario.CambiarClave(usuario.Clave, claveEncriptada);
                Servicios.MailSender.EnviarMail(usuario.CorreoElectronico, "Su clave es: " + clave, "Reseteo de clave");
                return true;
            }
            catch (Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
            }
            return false;
        }

        public void EliminarUsuario(Entidades.Seguridad.Usuario usuario)
        {
            try
            {
                Modelo.Seguridad.Facade.Eliminar(usuario);
            }
            catch (Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
            }
        }

        public void HabilitarDeshabilitar(Entidades.Seguridad.Usuario Usuario)
        {
            try
            {
                Usuario.CambiarEstado();
                Modelo.Seguridad.Facade.Modificar(Usuario);
            }
            catch (Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
            }
        }

        public List<Entidades.Seguridad.Usuario> FiltrarUsuarios(string criterio)
        {
            List<Entidades.Seguridad.Usuario> usuario = new List<Entidades.Seguridad.Usuario>();
            try
            {
                usuario = (List<Entidades.Seguridad.Usuario>)Modelo.Seguridad.Facade.Filtrar(criterio, "Usuarios"); 
            }
            catch (Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
            }
            return usuario;
        }
    }
}
