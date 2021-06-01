using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Mapping.Sistema
{
    public class MappingProductos
    {
        private static MappingProductos instancia; 
        public static MappingProductos ObtenerInstancia()
        {
            if (instancia == null) instancia = new MappingProductos();
            return instancia; 
        }

        private List<Entidades.Sistema.Producto> listaproductos; 
        private MappingProductos()
        {
            listaproductos = new List<Entidades.Sistema.Producto>();
            listaproductos = RecuperarProductos();
        }

        public List<Entidades.Sistema.Producto> Recuperar()
        {
            return listaproductos; 
        }

        private static List<Entidades.Sistema.Producto> RecuperarProductos()
        {
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("DolcePasta");
            List<Entidades.Sistema.Producto> coleccionProductos = new List<Entidades.Sistema.Producto>();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "sp_RecuperarProductos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = conexion.RetornarConexion();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Entidades.Sistema.Producto oProducto = new Entidades.Sistema.Producto();
                    oProducto.Nombre = reader[0].ToString();
                    oProducto.Precio = Convert.ToDecimal(reader[1].ToString());
                    oProducto.Cantidad = Convert.ToInt32(reader[2].ToString());
                    bool estado = Convert.ToBoolean(reader[3]);
                    if (!estado) oProducto.CambiarEstado();
                    oProducto.PuntoPedido = Convert.ToInt32(reader[4].ToString());
                    string categoria = reader[5].ToString();
                    oProducto.CategoriaProducto = MappingCategoriasProductos.ObtenerInstancia().Recuperar().Find(x => x.Nombre == categoria);
                    string cuit = reader[6].ToString();
                    oProducto.Proveedor = Mapping.Sistema.MappingProveedores.ObtenerInstancia().Recuperar().Find(x => x.Cuit.ToString() == cuit);
                    coleccionProductos.Add(oProducto);
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
            return coleccionProductos;
        }

        public static void AgregarProducto(Entidades.Sistema.Producto oProducto)
        {
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("DolcePasta");

            try
            {
                conexion.ComenzarTransaccion();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_AgregarProducto";
                cmd.Transaction = conexion.RetornarSqlTransaccion();
                cmd.Parameters.Add("@NombreProducto", System.Data.SqlDbType.NVarChar, 30).Value = oProducto.Nombre;
                cmd.Parameters.Add("@NombreCategoriaProducto", System.Data.SqlDbType.NVarChar, 30).Value = oProducto.CategoriaProducto.Nombre;
                cmd.Parameters.Add("@DenominacionLegal_Proveedor", System.Data.SqlDbType.NVarChar, 30).Value = oProducto.Proveedor.DenominacionLegal;
                cmd.Parameters.Add("@Precio", System.Data.SqlDbType.Decimal).Value = oProducto.Precio;
                cmd.Parameters.Add("@Cantidad", System.Data.SqlDbType.Int).Value = oProducto.Cantidad;
                cmd.Parameters.Add("@Estado", System.Data.SqlDbType.Bit).Value = oProducto.Estado;
                cmd.Parameters.Add("@PuntoPedido", System.Data.SqlDbType.Int).Value = oProducto.PuntoPedido;
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

        public static void ModificarProducto(Entidades.Sistema.Producto oProducto)
        {
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("DolcePasta");

            try
            {
                conexion.ComenzarTransaccion();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_ModificarProducto";
                cmd.Transaction = conexion.RetornarSqlTransaccion();
                cmd.Connection = conexion.RetornarConexion();
                cmd.Parameters.Add("@NombreProducto", System.Data.SqlDbType.NVarChar, 30).Value = oProducto.Nombre;
                cmd.Parameters.Add("@DenominacionLegal_Proveedor", System.Data.SqlDbType.NVarChar, 30).Value = oProducto.Proveedor.DenominacionLegal;
                cmd.Parameters.Add("@Precio", System.Data.SqlDbType.Decimal, 10).Value = oProducto.Precio;
                cmd.Parameters.Add("@Cantidad", System.Data.SqlDbType.Int, 5).Value = oProducto.Cantidad;
                cmd.Parameters.Add("@Estado", System.Data.SqlDbType.Bit).Value = oProducto.Estado;
                cmd.Parameters.Add("@PuntoPedido", System.Data.SqlDbType.Int, 5).Value = oProducto.PuntoPedido;
                cmd.Parameters.Add("@NombreCategoriaProducto", System.Data.SqlDbType.VarChar, 20).Value = oProducto.CategoriaProducto.Nombre;
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

