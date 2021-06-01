using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Mapping.Sistema
{
    public static class MappingNotaVenta
    {
        public static List<Entidades.Sistema.NotaVenta> RecuperarNotaVenta()
        {
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("Sistema");
            List<Entidades.Sistema.NotaVenta> coleccionNotaVenta = new List<Entidades.Sistema.NotaVenta>();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "sp_RecuperarNotasVentas";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = conexion.RetornarConexion();

                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Entidades.Sistema.NotaVenta oNotaVenta = new Entidades.Sistema.NotaVenta();
                    Entidades.Sistema.Cliente oCliente = new Entidades.Sistema.Cliente();

                    oNotaVenta.NroNotaVenta = Convert.ToInt32(reader[0]);
                    oCliente.RazonSocial = reader[1].ToString();
                    oNotaVenta.Fecha = Convert.ToDateTime(reader[2]);
                    oNotaVenta.Cantidad = Convert.ToInt32(reader[4]);
                    oNotaVenta.Estado = reader[5].ToString();
                    oNotaVenta.Cliente = oCliente;

                    SqlCommand cmdLinea = new SqlCommand();
                    cmdLinea.CommandText = "sp_RecuperarLineasNotasVentas";
                    cmdLinea.CommandType = System.Data.CommandType.StoredProcedure;
                    cmdLinea.Parameters.Add("@id_NotaVenta", System.Data.SqlDbType.BigInt).Value = oNotaVenta.NroNotaVenta;
                    cmdLinea.Connection = conexion.RetornarConexion();

                    SqlDataReader readerLinea;
                    readerLinea = cmdLinea.ExecuteReader();
                    while (readerLinea.Read())
                    {
                        Entidades.Sistema.Producto oProducto = new Entidades.Sistema.Producto();
                        Entidades.Sistema.Cliente cliente = new Entidades.Sistema.Cliente();
                        oProducto.Nombre = readerLinea[1].ToString();
                        int cantidad = Convert.ToInt32(readerLinea[0]);
                        decimal precioUnitario = Convert.ToDecimal(readerLinea[2]);
                        Entidades.Sistema.LineaNotaVenta oLineaNotaVenta = new Entidades.Sistema.LineaNotaVenta();
                        oLineaNotaVenta.CargarDatos(oProducto, precioUnitario, cantidad);
                        oNotaVenta.AgregarLineaNotaVenta(oLineaNotaVenta);
                    }
                    coleccionNotaVenta.Add(oNotaVenta);
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
            return coleccionNotaVenta;
        }

        public static void AgregarNotaVenta(Entidades.Sistema.NotaVenta oNotaVenta)
        {
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("DolcePasta");

            try
            {
                conexion.ComenzarTransaccion();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_AgregarNotaVenta";
                cmd.Transaction = conexion.RetornarSqlTransaccion();
                cmd.Connection = conexion.RetornarConexion();
                cmd.Parameters.Add("@Cliente", System.Data.SqlDbType.NVarChar, 30).Value = oNotaVenta.Cliente.RazonSocial;
                cmd.Parameters.Add("@Fecha", System.Data.SqlDbType.DateTime).Value = oNotaVenta.Fecha;
                cmd.Parameters.Add("@PrecioTotal", System.Data.SqlDbType.Decimal).Value = oNotaVenta.PrecioTotal;
                cmd.Parameters.Add("@Cantidad", System.Data.SqlDbType.Decimal).Value = oNotaVenta.Cantidad;
                cmd.Parameters.Add("@Estado", System.Data.SqlDbType.NVarChar, 20).Value = oNotaVenta.Estado;
                int nroNotaVenta = Convert.ToInt32(cmd.ExecuteScalar());
                oNotaVenta.NroNotaVenta = nroNotaVenta;

                SqlCommand cmdLinea = new SqlCommand();
                cmdLinea.CommandText = "sp_AgregarLineaNotaVenta";
                cmdLinea.CommandType = System.Data.CommandType.StoredProcedure;
                cmdLinea.Connection = conexion.RetornarConexion();
                cmdLinea.Transaction = conexion.RetornarSqlTransaccion();
                cmdLinea.Parameters.Add("@NotaVenta", System.Data.SqlDbType.Int).Value = nroNotaVenta;
                cmdLinea.Parameters.Add("@Producto", System.Data.SqlDbType.NVarChar, 30);
                cmdLinea.Parameters.Add("@Cantidad", System.Data.SqlDbType.Int);
                cmdLinea.Parameters.Add("@PrecioUnitario", System.Data.SqlDbType.Decimal);

                foreach (Entidades.Sistema.LineaNotaVenta item in oNotaVenta.LineaNotaVenta)
                {
                    cmdLinea.Parameters["@Producto"].Value = item.Producto.Nombre;
                    cmdLinea.Parameters["@Cantidad"].Value = item.Cantidad;
                    cmdLinea.Parameters["@PrecioUnitario"].Value = item.PrecioUnitario;
                    cmdLinea.ExecuteNonQuery();
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

        public static void AnularNotaVenta(Entidades.Sistema.NotaVenta oNotaVenta)
        {
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("DolcePasta");

            try
            {
                conexion.ComenzarTransaccion();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_AnularNotaVenta";
                cmd.Transaction = conexion.RetornarSqlTransaccion();
                cmd.Connection = conexion.RetornarConexion();
                cmd.Parameters.Add("@NroNotaVenta", System.Data.SqlDbType.Int).Value = oNotaVenta.NroNotaVenta;
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

        public static void FinalizarNotaVenta(Entidades.Sistema.NotaVenta oNotaVenta)
        {
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("DolcePasta");

            try
            {
                conexion.ComenzarTransaccion();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_FinalizarNotaVenta";
                cmd.Transaction = conexion.RetornarSqlTransaccion();
                cmd.Connection = conexion.RetornarConexion();
                cmd.Parameters.Add("@NroNotaVenta", System.Data.SqlDbType.Int).Value = oNotaVenta.NroNotaVenta;
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

