using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace Mapping.Sistema
{
    public static class MappingMayoresCompradores
    {
        public static List<Entidades.Sistema.MayoresCompradores> RecuperarMayoresCompradores()
        {
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("DolcePasta");
            List<Entidades.Sistema.MayoresCompradores> coleccionMayoresCompradores = new List<Entidades.Sistema.MayoresCompradores>();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "sp_LIstarMayoresCompradores";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = conexion.RetornarConexion();

                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Entidades.Sistema.MayoresCompradores oMayoresCompradores = new Entidades.Sistema.MayoresCompradores();
                    oMayoresCompradores.Cantidad = Convert.ToInt32(reader[0]);
                    oMayoresCompradores.Total = Convert.ToDecimal(reader[1]);
                    oMayoresCompradores.RazonSocial = reader[2].ToString();
                    oMayoresCompradores.Cuit = Convert.ToInt32(reader[3]);
                    coleccionMayoresCompradores.Add(oMayoresCompradores);
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
            return coleccionMayoresCompradores;
        }
    }
}
