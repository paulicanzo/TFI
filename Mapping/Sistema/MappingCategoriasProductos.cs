using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Mapping.Sistema
{
    public class MappingCategoriasProductos
    {
        private static MappingCategoriasProductos instancia; 
        public static MappingCategoriasProductos ObtenerInstancia()
        {
            if (instancia == null) instancia = new MappingCategoriasProductos();
            return instancia;
        }

        private List<Entidades.Sistema.CategoriaProducto> listaCategoriaProducto; 
        private MappingCategoriasProductos()
        {
            listaCategoriaProducto = new List<Entidades.Sistema.CategoriaProducto>();
            listaCategoriaProducto = RecuperarCategoriasProducto(); 
        }

        public List<Entidades.Sistema.CategoriaProducto> Recuperar()
        {
            return listaCategoriaProducto; 
        }

        private static List<Entidades.Sistema.CategoriaProducto> RecuperarCategoriasProducto()
        {
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("DolcePasta");
            List<Entidades.Sistema.CategoriaProducto> coleccionCategoriaProducto = new List<Entidades.Sistema.CategoriaProducto>();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "sp_RecuperarCategoriasProductos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = conexion.RetornarConexion();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Entidades.Sistema.CategoriaProducto oCategoriaProducto = new Entidades.Sistema.CategoriaProducto();
                    oCategoriaProducto.Nombre = reader[0].ToString();
                    oCategoriaProducto.Descripcion = reader[1].ToString();
                    coleccionCategoriaProducto.Add(oCategoriaProducto); 
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
            return coleccionCategoriaProducto; 
        }

        public static void AgregarCategoriaProducto(Entidades.Sistema.CategoriaProducto catProducto)
        {
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("DolcePasta");
            try
            {
                conexion.ComenzarTransaccion();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_AgregarCategoriaProducto";
                cmd.Transaction = conexion.RetornarSqlTransaccion();
                cmd.Connection = conexion.RetornarConexion();
                cmd.Parameters.Add("@NombreCategoriaProducto", System.Data.SqlDbType.NVarChar, 30).Value = catProducto.Nombre;
                cmd.Parameters.Add("@Descripcion", System.Data.SqlDbType.NVarChar, 30).Value = catProducto.Descripcion;
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

        public static bool EliminarCategoriaProducto(Entidades.Sistema.CategoriaProducto catProducto)
        {
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("DolcePasta");
            try
            {
                conexion.ComenzarTransaccion();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_EliminarCategoriaProducto";
                cmd.Transaction = conexion.RetornarSqlTransaccion();
                cmd.Connection = conexion.RetornarConexion();
                cmd.Parameters.Add("@NombreCategoriaProducto", System.Data.SqlDbType.NVarChar, 30).Value = catProducto.Nombre;
                cmd.ExecuteNonQuery();
                conexion.RetornarSqlTransaccion().Commit();
                return true;
            }
            catch(SqlException ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
                conexion.RetornarSqlTransaccion().Rollback();
                return false; 
            }
            finally
            {
                conexion.Desconectar();
            }
        }
    }
}
