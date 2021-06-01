using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora.Seguridad
{
    public class ControladoraCerrarSesion
    {
        private static ControladoraCerrarSesion instancia; 
        public static ControladoraCerrarSesion ObtenerInstancia()
        {
            if (instancia == null) instancia = new ControladoraCerrarSesion();
            return instancia; 
        }

        private ControladoraCerrarSesion() { }

        public void CerrarSesion(string nombreUsuario)
        {
            try
            {
                Entidades.Auditoria.Auditoria oAuditoria = new Entidades.Auditoria.Auditoria();
                oAuditoria.Usuario = nombreUsuario;
                oAuditoria.Fecha = DateTime.Now;
                oAuditoria.Equipo = Environment.MachineName;
                oAuditoria.Operacion = "Logout";
                Modelo.Auditoria.catAuditoria.ObtenerInstancia().AgregrarAuditoria(oAuditoria);
                Servicios.AppHandler.GuardarValorDeAppConfig("GoodClose", "true");
            }
            catch (Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
            }
        }
    }
}
