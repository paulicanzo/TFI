using System;
using System.Diagnostics;
using System.Data.SqlClient;

namespace Servicios
{
    public static class EventManager
    {
        public static void RegistrarErrores(Exception ex)
        {
            string encabezado = "La aplicacion finalizo abruptamente, el detalle de error se describe a continuacion: ";
            ex.HelpLink = "Para mas ayuda, por favor ingrese al siguiente website: http://develop.cetcom.com.ar/support";
            string sSource = "GestionAir";
            Type tipo = ex.GetType(); 

            if(tipo.Name == "SqlException")
            {
                SqlException error = (SqlException)ex;
                short a = 10;
                EventLog.WriteEntry(sSource, encabezado + tipo.Name + ":" + ex.Message + ex.HelpLink, EventLogEntryType.Error, a); 
            }
            if(tipo.Name == "ArgumentException")
            {
                ArgumentException error = (ArgumentException)ex; 
            }
        }

        public static void RegistrarErrores(System.Reflection.Assembly ensamblado, Exception error)
        {
            System.Reflection.AssemblyName nom = ensamblado.GetName();
        }

    }
}
