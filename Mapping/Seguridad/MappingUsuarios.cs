using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Mapping.Seguridad
{
    public static class MappingUsuarios
    {
        public static List<Entidades.Seguridad.Usuario> RecuperarUsuarios()
        {
            List<Entidades.Seguridad.Usuario> coleccionUsuarios = new List<Entidades.Seguridad.Usuario>();
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("SEGURIDADDolcePasta");

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "sp_RecuperarUsuarios";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = conexion.RetornarConexion();

                SqlDataReader reader;
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Entidades.Seguridad.Usuario oUsuario = new Entidades.Seguridad.Usuario(); 
                    int nroUsuario = Convert.ToInt32(reader[0]);
                    oUsuario.NombreUsuario = reader[1].ToString();
                    oUsuario.Nombre = reader[2].ToString();
                    oUsuario.Apellido = reader[3].ToString();
                    oUsuario.CambiarClave(null, reader[4].ToString());
                    bool resultado = Convert.ToBoolean(reader[5]);
                    if (!resultado) oUsuario.CambiarEstado();
                    oUsuario.CorreoElectronico = reader[6].ToString();

                    SqlCommand cmdGrupo = new SqlCommand();
                    cmdGrupo.CommandText = "sp_RecuperarGruposUsuario";
                    cmdGrupo.CommandType = System.Data.CommandType.StoredProcedure;
                    cmdGrupo.Parameters.Add("@id_usuario", System.Data.SqlDbType.Int).Value = nroUsuario;
                    cmdGrupo.Connection = conexion.RetornarConexion();

                    SqlDataReader readerGrupo;
                    readerGrupo = cmdGrupo.ExecuteReader();

                    while (readerGrupo.Read())
                    {
                        Entidades.Seguridad.Grupo oGrupo = new Entidades.Seguridad.Grupo();
                        oGrupo.Nombre = readerGrupo[0].ToString();
                        oGrupo.Descripcion = readerGrupo[1].ToString();
                        bool resultadoGrupo = Convert.ToBoolean(readerGrupo[2].ToString());
                        if (!resultadoGrupo) oGrupo.CambiarEstado();
                        oUsuario.AgregarGrupo(oGrupo);
                    }
                    coleccionUsuarios.Add(oUsuario);
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
            return coleccionUsuarios;
        }

        public static bool AgregarUsuario(Entidades.Seguridad.Usuario oUsuario)
        {
            bool operacion = false;
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("SEGURIDADDolcePasta");

            try
            {
                conexion.ComenzarTransaccion();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_AgregarUsuario";
                cmd.Transaction = conexion.RetornarSqlTransaccion();
                cmd.Connection = conexion.RetornarConexion();
                cmd.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar, 20).Value = oUsuario.Nombre;
                cmd.Parameters.Add("@Apellido", System.Data.SqlDbType.VarChar, 20).Value = oUsuario.Apellido;
                cmd.Parameters.Add("@Estado", System.Data.SqlDbType.Bit).Value = oUsuario.Estado;
                cmd.Parameters.Add("@Nombre_Usuario", System.Data.SqlDbType.VarChar, 15).Value = oUsuario.NombreUsuario;
                cmd.Parameters.Add("@Clave", System.Data.SqlDbType.VarChar, 30).Value = oUsuario.Clave;
                cmd.Parameters.Add("@Correo_Electronico", System.Data.SqlDbType.VarChar, 100).Value = oUsuario.CorreoElectronico;
                cmd.ExecuteNonQuery();
                conexion.RetornarSqlTransaccion().Commit();
                operacion = true; 
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
            return operacion;
        }

        public static void EliminarUsuario(Entidades.Seguridad.Usuario oUsuario)
        {
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("SEGURIDADDolcePasta");

            try
            {
                conexion.ComenzarTransaccion();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_EliminarUsuario";
                cmd.Transaction = conexion.RetornarSqlTransaccion();
                cmd.Connection = conexion.RetornarConexion();
                cmd.Parameters.Add("@Nombre_usuario", System.Data.SqlDbType.VarChar, 15).Value = oUsuario.NombreUsuario;
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

        public static void ModificarUsuario(Entidades.Seguridad.Usuario oUsuario)
        {
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("SEGURIDADDolcePasta");

            try
            {
                conexion.ComenzarTransaccion();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_ModificarUsuario";
                cmd.Transaction = conexion.RetornarSqlTransaccion();
                cmd.Connection = conexion.RetornarConexion();
                cmd.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar, 20).Value = oUsuario.Nombre;
                cmd.Parameters.Add("@Apellido", System.Data.SqlDbType.VarChar, 50).Value = oUsuario.Apellido;
                cmd.Parameters.Add("@Estado", System.Data.SqlDbType.Bit).Value = oUsuario.Estado;
                cmd.Parameters.Add("@Nombre_Usuario", System.Data.SqlDbType.VarChar, 15).Value = oUsuario.NombreUsuario;
                cmd.Parameters.Add("@Clave", System.Data.SqlDbType.VarChar, 30).Value = oUsuario.Clave;
                cmd.Parameters.Add("@Correo_Electronico", System.Data.SqlDbType.VarChar, 100).Value = oUsuario.CorreoElectronico;
                cmd.ExecuteNonQuery();

                SqlCommand cmdEliminarGrupo = new SqlCommand();
                cmdEliminarGrupo.CommandType = System.Data.CommandType.StoredProcedure;
                cmdEliminarGrupo.CommandText = "sp_EliminarGrupoUsuario";
                cmdEliminarGrupo.Transaction = conexion.RetornarSqlTransaccion();
                cmdEliminarGrupo.Connection = conexion.RetornarConexion();
                cmdEliminarGrupo.Parameters.Add("@nombre_usuario", System.Data.SqlDbType.VarChar, 15).Value = oUsuario.NombreUsuario;
                cmdEliminarGrupo.ExecuteNonQuery();

                SqlCommand cmdGrupo = new SqlCommand();
                cmdGrupo.CommandText = "sp_AgregarGrupoUsuario";
                cmdGrupo.CommandType = System.Data.CommandType.StoredProcedure;
                cmdGrupo.Connection = conexion.RetornarConexion();
                cmdGrupo.Transaction = conexion.RetornarSqlTransaccion();
                cmdGrupo.Parameters.Add("@Nombre_Usuario", System.Data.SqlDbType.VarChar, 30).Value = oUsuario.NombreUsuario;
                cmdGrupo.Parameters.Add("@nombre_Grupo", System.Data.SqlDbType.VarChar, 20);

                foreach (Entidades.Seguridad.Grupo item in oUsuario.Grupos)
                {
                    cmdGrupo.Parameters["@nombre_grupo"].Value = item.Nombre;
                    cmdGrupo.ExecuteNonQuery();
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
    }
}
