using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Mapping.Sistema
{
    public static class MappingProductosMasVendidos
    {
        public static List<Entidades.Sistema.ProductosMasVendidos> RecuperarProductosMasVendidos(string Categoria)
        {
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("DolcePasta");
            List<Entidades.Sistema.ProductosMasVendidos> coleccionProductosMasVendidos = new List<Entidades.Sistema.ProductosMasVendidos>();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "sp_ListarProductosMasVendidos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@Categoia", System.Data.SqlDbType.NVarChar, 20).Value = Categoria;
                cmd.Connection = conexion.RetornarConexion();

                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Entidades.Sistema.ProductosMasVendidos oProductoMasVendido = new Entidades.Sistema.ProductosMasVendidos();
                    oProductoMasVendido.Cantidad = Convert.ToInt32(reader[0]);
                    oProductoMasVendido.Producto = reader[2].ToString();
                    oProductoMasVendido.Categoria = reader[3].ToString();
                    coleccionProductosMasVendidos.Add(oProductoMasVendido);
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
            return coleccionProductosMasVendidos;
        }
    }
}

