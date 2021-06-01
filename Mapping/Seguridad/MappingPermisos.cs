using System.Collections.Generic;
using System.Data.SqlClient;

namespace Mapping.Seguridad
{
    public static class MappingPermisos
    {
        public static List<Entidades.Seguridad.Permiso> RecuperarPermiso()
        {
            List<Entidades.Seguridad.Permiso> coleccionPermisos = new List<Entidades.Seguridad.Permiso>();
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("SEGURIDADDolcePasta");

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "sp_RecuperarPermisos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = conexion.RetornarConexion();

                SqlDataReader reader;
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Entidades.Seguridad.Permiso oPermiso = new Entidades.Seguridad.Permiso();
                    oPermiso.Nombre = reader[0].ToString();
                    coleccionPermisos.Add(oPermiso);
                }
            }
            catch(SqlException ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
            }
            finally
            {
                conexion.Desconectar();
            }
            return coleccionPermisos;
        }
    }
}
