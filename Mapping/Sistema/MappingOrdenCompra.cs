using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Mapping.Sistema
{
    public class MappingOrdenCompra
    {
        private static MappingOrdenCompra instancia; 
        public static MappingOrdenCompra ObtenerInstancia()
        {
            if (instancia == null) instancia = new MappingOrdenCompra();
            return instancia;
        }

        private List<Entidades.Sistema.OrdenCompra> listaOrdenCompra; 
        private MappingOrdenCompra()
        {
            listaOrdenCompra = new List<Entidades.Sistema.OrdenCompra>();
            listaOrdenCompra = RecuperarOrdenCompra();
        }
        
        public List<Entidades.Sistema.OrdenCompra> Recuperar()
        {
            return listaOrdenCompra; 
        }

        private static List<Entidades.Sistema.OrdenCompra> RecuperarOrdenCompra()
        {
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("DolcePasta");
            List<Entidades.Sistema.OrdenCompra> coleccionOrdenCompra = new List<Entidades.Sistema.OrdenCompra>();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "sp_RecuperarOrdenesdeCompra";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = conexion.RetornarConexion();

                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Entidades.Sistema.OrdenCompra oOrdenCompra = new Entidades.Sistema.OrdenCompra();
                    oOrdenCompra.NroOrdenCompra = Convert.ToInt32(reader[0].ToString());
                    oOrdenCompra.FechaEmision = Convert.ToDateTime(reader[1].ToString());
                    oOrdenCompra.FechaRecepcionMercaderia = Convert.ToDateTime(reader[2].ToString());
                    oOrdenCompra.PrecioTotal = Convert.ToDecimal(reader[3].ToString());
                    oOrdenCompra.Estado = reader[4].ToString();
                    oOrdenCompra.Usuario = reader[5].ToString();
                    oOrdenCompra.Operacion = reader[6].ToString();
                    oOrdenCompra.Equipo = reader[7].ToString();
                    oOrdenCompra.Fecha = Convert.ToDateTime(reader[8].ToString());
                    string cuit = reader[9].ToString();
                    oOrdenCompra.Proveedor = Mapping.Sistema.MappingProveedores.ObtenerInstancia().Recuperar().Find(x => x.Cuit.ToString() == cuit);
                    string condiciones = reader[10].ToString();
                    oOrdenCompra.CondicionesPago = MappingCondicionesPago.ObtenerInstancia().Recuperar().Find(x => x.Nombre == condiciones);

                    SqlCommand cmdLinea = new SqlCommand();
                    cmdLinea.CommandText = "sp_RecuperarLineaOrdenCompra";
                    cmdLinea.CommandType = System.Data.CommandType.StoredProcedure;
                    cmdLinea.Parameters.Add("@id_OrdenCompra", System.Data.SqlDbType.BigInt).Value = oOrdenCompra.NroOrdenCompra;
                    cmdLinea.Connection = conexion.RetornarConexion();

                    SqlDataReader readerLinea;
                    readerLinea = cmdLinea.ExecuteReader();
                    while (readerLinea.Read())
                    {
                        Entidades.Sistema.Producto oProducto = new Entidades.Sistema.Producto();
                        Entidades.Sistema.Proveedor oProveedor = new Entidades.Sistema.Proveedor();
                        Entidades.Sistema.CategoriaProducto oCategoria = new Entidades.Sistema.CategoriaProducto();

                        oOrdenCompra.NroOrdenCompra = Convert.ToInt32(readerLinea[0]);
                        oProducto.Nombre = readerLinea[1].ToString();
                        int cantidad = Convert.ToInt32(readerLinea[2]);
                        decimal precio = Convert.ToDecimal(readerLinea[3]);
                        oProducto.CategoriaProducto = oCategoria;
                        oProducto.Proveedor = oProveedor;
                        oCategoria.Nombre = readerLinea[4].ToString();
                        oProveedor.DenominacionLegal = readerLinea[5].ToString();
                        Entidades.Sistema.LineaOrdenCompra oLinea = new Entidades.Sistema.LineaOrdenCompra();
                        oLinea.CargarDatos(oProducto, precio, cantidad);
                        oOrdenCompra.AgregarLineaOrdenCompra(oLinea);
                    }
                    coleccionOrdenCompra.Add(oOrdenCompra);
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
            return coleccionOrdenCompra;
        }

        public static void AgregarOrdenCompra(Entidades.Sistema.OrdenCompra oOrdenCompra)
        {
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("DolcePasta");

            try
            {
                conexion.ComenzarTransaccion();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_AgregarOrdendeCompra";
                cmd.Transaction = conexion.RetornarSqlTransaccion();
                cmd.Connection = conexion.RetornarConexion();
                cmd.Parameters.Add("@DenominacionLegal_Proveedor", System.Data.SqlDbType.NVarChar, 30).Value = oOrdenCompra.Proveedor.DenominacionLegal;
                cmd.Parameters.Add("@NombreCondicionesPago", System.Data.SqlDbType.NVarChar, 20).Value = oOrdenCompra.CondicionesPago.Nombre;
                cmd.Parameters.Add("@FechaEmision", System.Data.SqlDbType.DateTime, 8).Value = oOrdenCompra.FechaEmision;
                cmd.Parameters.Add("@FechaRecepcionMercaderia", System.Data.SqlDbType.DateTime, 8).Value = oOrdenCompra.FechaRecepcionMercaderia;
                cmd.Parameters.Add("@PrecioTotal", System.Data.SqlDbType.Decimal).Value = oOrdenCompra.PrecioTotal;
                cmd.Parameters.Add("@Estado", System.Data.SqlDbType.NVarChar, 20).Value = oOrdenCompra.Estado;
                cmd.Parameters.Add("@Usuario", System.Data.SqlDbType.VarChar, 15).Value = oOrdenCompra.Usuario;
                cmd.Parameters.Add("@Operacion", System.Data.SqlDbType.VarChar, 15).Value = oOrdenCompra.Operacion;
                cmd.Parameters.Add("@Equipo", System.Data.SqlDbType.VarChar, 20).Value = oOrdenCompra.Equipo;
                cmd.Parameters.Add("@Fecha", System.Data.SqlDbType.DateTime).Value = oOrdenCompra.Fecha;
                int nroOC = Convert.ToInt32(cmd.ExecuteScalar());
                oOrdenCompra.NroOrdenCompra = nroOC;

                SqlCommand cmdLinea = new SqlCommand();
                cmdLinea.CommandText = "sp_AgregarLineaOrdendeCompra";
                cmdLinea.CommandType = System.Data.CommandType.StoredProcedure;
                cmdLinea.Connection = conexion.RetornarConexion();
                cmdLinea.Transaction = conexion.RetornarSqlTransaccion();
                cmdLinea.Parameters.Add("@OrdenCompra", System.Data.SqlDbType.Int).Value = nroOC;
                cmdLinea.Parameters.Add("@Producto", System.Data.SqlDbType.NVarChar, 30);
                cmdLinea.Parameters.Add("@Cantidad", System.Data.SqlDbType.Int);
                cmdLinea.Parameters.Add("@Precio", System.Data.SqlDbType.Decimal);

                foreach (Entidades.Sistema.LineaOrdenCompra item in oOrdenCompra.LineaOrdenCompra)
                {
                    cmdLinea.Parameters["@Producto"].Value = item.Producto.Nombre;
                    cmdLinea.Parameters["@Cantidad"].Value = item.Cantidad;
                    cmdLinea.Parameters["@Precio"].Value = item.PrecioUnitario;
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

        public static void AnularCompra(Entidades.Sistema.OrdenCompra oOrdenCompra)
        {
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("DolcePasta");

            try
            {
                conexion.ComenzarTransaccion();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_AnularOrdenCompra";
                cmd.Transaction = conexion.RetornarSqlTransaccion();
                cmd.Connection = conexion.RetornarConexion();
                cmd.Parameters.Add("@NroOrdenCompra", System.Data.SqlDbType.Int).Value = oOrdenCompra.NroOrdenCompra;
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

