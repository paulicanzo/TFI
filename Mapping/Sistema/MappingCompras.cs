using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Mapping.Sistema
{
    public static class MappingCompras
    {
        public static List<Entidades.Sistema.CompraMensual> RecuperarComprasMensual(DateTime desde, DateTime hasta)
        {
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("DolcePasta");
            List<Entidades.Sistema.CompraMensual> coleccionCompraMensual = new List<Entidades.Sistema.CompraMensual>();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "spcompras";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@desde", System.Data.SqlDbType.DateTime).Value = desde;
                cmd.Parameters.Add("@hasta", System.Data.SqlDbType.DateTime).Value = hasta;
                cmd.Connection = conexion.RetornarConexion();

                SqlDataReader reader;
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Entidades.Sistema.CompraMensual compra = new Entidades.Sistema.CompraMensual();
                    compra.DenominacionLegal = reader[0].ToString();
                    compra.Monto = Convert.ToDecimal(reader[1]);
                    coleccionCompraMensual.Add(compra); 
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
            return coleccionCompraMensual;
        }
    }
}
