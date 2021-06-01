using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Mapping.Sistema
{
    public static class MappingMayoresDeudores
    {
        public static List<Entidades.Sistema.MayoresDeudores> RecuperarMayoresDeudores()
        {
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("DolcePasta");
            List<Entidades.Sistema.MayoresDeudores> coleccionMayoresDeudores = new List<Entidades.Sistema.MayoresDeudores>();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "sp_MayoresDeudores";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = conexion.RetornarConexion();

                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Entidades.Sistema.MayoresDeudores oMayoresDeudores = new Entidades.Sistema.MayoresDeudores();
                    oMayoresDeudores.Total = Convert.ToInt32(reader[0]);
                    oMayoresDeudores.Cliente = reader[1].ToString();
                    coleccionMayoresDeudores.Add(oMayoresDeudores);
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
            return coleccionMayoresDeudores;
        }
    }
}

