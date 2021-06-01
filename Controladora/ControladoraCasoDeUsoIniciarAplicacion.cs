using System;
using System.Configuration;
using System.Reflection;

namespace Controladora
{
    public static class ControladoraCasoDeUsoIniciarAplicacion
    {
        public static void EncriptarCS()
        {
            Servicios.Encriptacion.EncriptarConnectionStrings();
        }

        public static void DesencriptarCS()
        {
            Servicios.Encriptacion.DesencriptarConnectionStrings();
        }

        public static void EncriptarAPP()
        {
            Servicios.Encriptacion.EncriptarAppSettings(); 
        }

        public static void DesencriptarAPP()
        {
            Servicios.Encriptacion.DesencriptarAppSettings();
        }

        public static string ObtenerEncryptionString()
        {
            return ConfigurationManager.AppSettings["EncryptionString"].ToString(); 
        }

        public static bool VerificarCierreSesionCorrecto()
        {
            bool operacion = false;
            bool CierreCorrecto = Convert.ToBoolean(Servicios.AppHandler.ObtenerStringDeAppConfig("GoodClose"));
            if (CierreCorrecto) operacion = true;
            else
            {
                string usuario = Servicios.AppHandler.ObtenerStringDeAppConfig("LastUserLogged");
                string fechaHora = Servicios.AppHandler.ObtenerStringDeAppConfig("LastUserLoggedDateTime");
                Entidades.Auditoria.Auditoria oAudit = new Entidades.Auditoria.Auditoria();
                if (fechaHora == "") fechaHora = DateTime.Now.ToString();
                if (usuario == "") usuario = "_";
                oAudit.Usuario = usuario;
                oAudit.Fecha = Convert.ToDateTime(fechaHora);
                oAudit.Equipo = Environment.MachineName;
                oAudit.Operacion = "Error";
                Entidades.Seguridad.Usuario usuarioYaLogueado = (Entidades.Seguridad.Usuario)Modelo.Seguridad.Facade.Buscar(usuario, "Usuarios");
                Modelo.Auditoria.catAuditoria.ObtenerInstancia().AgregrarAuditoria(oAudit);
                operacion = false;
            }
            return operacion;
        }
    }
}
