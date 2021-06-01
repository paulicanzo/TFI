using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Mapping.Sistema
{
    public static class MappingFaltante
    {
        public static List<Entidades.Sistema.Faltante> RecuperarFaltante()
        {
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("Sistema");
            List<Entidades.Sistema.Faltante> coleccionFaltante = new List<Entidades.Sistema.Faltante>();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "sp_RecuperarFaltante";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = conexion.RetornarConexion();

                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Entidades.Sistema.Faltante oFaltante = new Entidades.Sistema.Faltante();
                    int idFaltante = Convert.ToInt32(reader[0]);
                    oFaltante.NroOrdenCompra = Convert.ToInt32(reader[1]);

                    SqlCommand cmdLineaFaltante = new SqlCommand();
                    cmdLineaFaltante.CommandText = "sp_RecuperarLineaFaltante";
                    cmdLineaFaltante.CommandType = System.Data.CommandType.StoredProcedure;
                    cmdLineaFaltante.Parameters.Add("@id_faltante", System.Data.SqlDbType.BigInt).Value = idFaltante;
                    cmdLineaFaltante.Connection = conexion.RetornarConexion();

                    SqlDataReader readerLineaFaltante = cmdLineaFaltante.ExecuteReader();
                    while (readerLineaFaltante.Read())
                    {
                        Entidades.Sistema.LineaFaltante lineaFaltante = new Entidades.Sistema.LineaFaltante();
                        lineaFaltante.CantidadFaltante = Convert.ToInt32(readerLineaFaltante[0]);

                        Entidades.Sistema.Producto oProducto = new Entidades.Sistema.Producto();
                        oProducto.Nombre = readerLineaFaltante[1].ToString();
                        lineaFaltante.Producto = oProducto;
                        oFaltante.AgregarLineaFaltante(lineaFaltante);
                    }
                    coleccionFaltante.Add(oFaltante);
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
            return coleccionFaltante;
        }

        public static void AgregarFaltante(Entidades.Sistema.Faltante oFaltante)
        {
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("DolcePasta");

            try
            {
                conexion.ComenzarTransaccion();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_AgregarFaltante";
                cmd.Transaction = conexion.RetornarSqlTransaccion();
                cmd.Connection = conexion.RetornarConexion();
                cmd.Parameters.Add("@NroOrdenCompra", System.Data.SqlDbType.Int).Value = oFaltante.NroOrdenCompra;
                int nroFaltante = Convert.ToInt32(cmd.ExecuteScalar());
                oFaltante.NroOrdenCompra = nroFaltante;

                SqlCommand cmdLineaFaltante = new SqlCommand();
                cmdLineaFaltante.CommandText = "sp_AgregarLineaFaltante";
                cmdLineaFaltante.CommandType = System.Data.CommandType.StoredProcedure;
                cmdLineaFaltante.Connection = conexion.RetornarConexion();
                cmdLineaFaltante.Transaction = conexion.RetornarSqlTransaccion();
                cmdLineaFaltante.Parameters.Add("@Faltante", System.Data.SqlDbType.Int);
                cmdLineaFaltante.Parameters.Add("@Producto", System.Data.SqlDbType.NVarChar, 30);
                cmdLineaFaltante.Parameters.Add("@CantidadFaltante", System.Data.SqlDbType.Int);
                foreach (Entidades.Sistema.LineaFaltante item in oFaltante.LineaFaltante)
                {
                    cmdLineaFaltante.Parameters["@Faltante"].Value = nroFaltante;
                    cmdLineaFaltante.Parameters["@Producto"].Value = item.Producto.Nombre;
                    cmdLineaFaltante.Parameters["@CantidadFaltante"].Value = item.CantidadFaltante;
                    cmdLineaFaltante.ExecuteNonQuery();
                }
                conexion.RetornarSqlTransaccion().Commit();
            }
            catch(SqlException ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
                conexion.RetornarSqlTransaccion().Rollback();
            }
            finally
            {
                conexion.Desconectar();
            }
        }

        public static void ModificarFaltante(Entidades.Sistema.Faltante oFaltante)
        {
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("DolcePasta");

            try
            {
                conexion.ComenzarTransaccion();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_ModificarFaltante";
                cmd.Transaction = conexion.RetornarSqlTransaccion();
                cmd.Connection = conexion.RetornarConexion();
                cmd.Parameters.Add("@Producto", System.Data.SqlDbType.NVarChar, 30);
                cmd.Parameters.Add("@CantidadFaltante", System.Data.SqlDbType.Int);
                foreach (Entidades.Sistema.LineaFaltante item in oFaltante.LineaFaltante)
                {
                    cmd.Parameters["@Producto"].Value = item.Producto.Nombre;
                    cmd.Parameters["@CantidadFaltante"].Value = item.CantidadFaltante;
                    cmd.ExecuteNonQuery();
                }
                cmd.ExecuteNonQuery();
                conexion.RetornarSqlTransaccion().Commit(); 
            }
            catch(SqlException ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
                conexion.RetornarSqlTransaccion().Rollback();
            }
            finally
            {
                conexion.Desconectar();
            }
        }
    }
}
