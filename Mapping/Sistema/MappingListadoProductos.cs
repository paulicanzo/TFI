using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Mapping.Sistema
{
    public static class MappingListadoProductos
    {
        public static List<Entidades.Sistema.ListadoProductos> RecuperarListadoProductos(DateTime desde, DateTime hasta)
        {
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("DolcePasta");
            List<Entidades.Sistema.ListadoProductos> coleccionListadoProductos = new List<Entidades.Sistema.ListadoProductos>();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "sp_ListadoProductos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = conexion.RetornarConexion();

                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Entidades.Sistema.ListadoProductos oListadoProductos = new Entidades.Sistema.ListadoProductos();
                    oListadoProductos.NombreProducto = reader[0].ToString();
                    oListadoProductos.Cantidad = Convert.ToInt32(reader[1]);
                    coleccionListadoProductos.Add(oListadoProductos);
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
            return coleccionListadoProductos;
        }
    }
}
