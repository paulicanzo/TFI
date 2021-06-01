using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Mapping.Seguridad
{
    public static class MappingGrupos
    {
        public static List<Entidades.Seguridad.Grupo> RecuperarGrupos()
        {
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("SEGURIDADDolcePasta");
            List<Entidades.Seguridad.Grupo> coleciconGrupos = new List<Entidades.Seguridad.Grupo>();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "sp_RecuperarGrupos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = conexion.RetornarConexion();

                SqlDataReader reader;
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Entidades.Seguridad.Grupo oGrupo = new Entidades.Seguridad.Grupo();
                    oGrupo.Nombre = reader[1].ToString();
                    oGrupo.Descripcion = reader[2].ToString();
                    bool estado = Convert.ToBoolean(reader[3]);
                    if (!estado) oGrupo.CambiarEstado();

                    coleciconGrupos.Add(oGrupo);
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
            return coleciconGrupos;
        }

        public static void AgregarGrupo(Entidades.Seguridad.Grupo oGrupo)
        {
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("SEGURIDADDolcePasta");

            try
            {
                conexion.ComenzarTransaccion();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_AgregarGrupo";
                cmd.Transaction = conexion.RetornarSqlTransaccion();
                cmd.Connection = conexion.RetornarConexion();
                cmd.Connection = conexion.RetornarConexion();
                cmd.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar, 20).Value = oGrupo.Nombre;
                cmd.Parameters.Add("@Descripcion", System.Data.SqlDbType.VarChar, 50).Value = oGrupo.Descripcion;
                cmd.Parameters.Add("@Estado", System.Data.SqlDbType.Bit).Value = oGrupo.Estado;
                cmd.Transaction = conexion.RetornarSqlTransaccion();
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

        public static void ModificarGrupo(Entidades.Seguridad.Grupo oGrupo)
        {
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("SEGURIDADDolcePasta");

            try
            {
                conexion.ComenzarTransaccion();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_ModificarGrupo";
                cmd.Transaction = conexion.RetornarSqlTransaccion();
                cmd.Connection = conexion.RetornarConexion();
                cmd.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar, 20).Value = oGrupo.Nombre;
                cmd.Parameters.Add("@Descripcion", System.Data.SqlDbType.VarChar, 50).Value = oGrupo.Descripcion;
                cmd.Parameters.Add("@Estado", System.Data.SqlDbType.Bit).Value = oGrupo.Estado;
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

        public static void EliminarGrupo(Entidades.Seguridad.Grupo oGrupo)
        {
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("SEGURIDADDolcePasta");

            try
            {
                conexion.ComenzarTransaccion();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_EliminarGrupo";
                cmd.Transaction = conexion.RetornarSqlTransaccion();
                cmd.Connection = conexion.RetornarConexion();
                cmd.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar, 20).Value = oGrupo.Nombre;
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
