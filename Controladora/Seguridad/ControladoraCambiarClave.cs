using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora.Seguridad
{
    public class ControladoraCambiarClave
    {
        private static ControladoraCambiarClave instancia; 
        public static ControladoraCambiarClave ObtenerInstancia()
        {
            if (instancia == null) instancia = new ControladoraCambiarClave();
            return instancia;
        }

        private ControladoraCambiarClave() { }

        public bool CambiarClave(Entidades.Seguridad.Usuario usuario, string claveActual, string claveNueva)
        {
            bool resultado;
            string claveActualEncriptada = Servicios.Encriptacion.EncriptarPassword(claveActual);
            string claveNuevaEncriptada = Servicios.Encriptacion.EncriptarPassword(claveNueva);
            resultado = usuario.CambiarClave(claveActualEncriptada, claveNuevaEncriptada);
            Modelo.Seguridad.Facade.Modificar(usuario);
            return resultado;
        }
    }
}

