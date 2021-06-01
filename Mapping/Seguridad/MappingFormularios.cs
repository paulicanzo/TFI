using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Mapping.Seguridad
{
    public static class MappingFormularios
    {
        public static List<Entidades.Seguridad.Formulario> RecuperarFormulario()
        {
            List<Entidades.Seguridad.Formulario> coleccionFormularios = new List<Entidades.Seguridad.Formulario>();
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("SEGURIDADDolcePasta");

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "sp_RecuperarFormularios";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = conexion.RetornarConexion();

                SqlDataReader reader;
                reader = cmd.ExecuteReader(); 
                while (reader.Read())
                {
                    Entidades.Seguridad.Formulario oFormulario = new Entidades.Seguridad.Formulario();
                    oFormulario.Nombre = reader[0].ToString();
                    coleccionFormularios.Add(oFormulario);
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
            return coleccionFormularios;
        }
    }
}
