using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Mapping.Seguridad
{
    public static class MappingPerfiles
    {
        public static List<Entidades.Seguridad.Perfil> RecuperarPerfiles()
        {
            List<Entidades.Seguridad.Perfil> coleccionPerfiles = new List<Entidades.Seguridad.Perfil>();
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("SEGURIDADDolcePasta");

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "sp_RecuperarPerfiles";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = conexion.RetornarConexion();

                SqlDataReader reader;
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Entidades.Seguridad.Perfil oPerfil = new Entidades.Seguridad.Perfil();
                    Entidades.Seguridad.Formulario oFormulario = new Entidades.Seguridad.Formulario();
                    Entidades.Seguridad.Permiso oPermiso = new Entidades.Seguridad.Permiso();
                    Entidades.Seguridad.Grupo oGrupo = new Entidades.Seguridad.Grupo();

                    oPermiso.Nombre = reader[0].ToString();
                    oGrupo.Nombre = reader[1].ToString();
                    oGrupo.Descripcion = reader[2].ToString();
                    bool estado = Convert.ToBoolean(reader[3]);
                    if (!estado) oGrupo.CambiarEstado();

                    oFormulario.Nombre = reader[4].ToString();
                    oPerfil.Usuario = reader[5].ToString();
                    oPerfil.Equipo = reader[6].ToString();
                    oPerfil.Fecha = Convert.ToDateTime(reader[7]);
                    oPerfil.Operacion = reader[8].ToString();

                    oPerfil.Formulario = oFormulario;
                    oPerfil.Grupo = oGrupo;
                    oPerfil.Permiso = oPermiso;
                    coleccionPerfiles.Add(oPerfil);
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
            return coleccionPerfiles; 
        }

        public static void AgregarPerfiles(Entidades.Seguridad.Perfil oPerfil)
        {
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("SEGURIDADDolcePasta");

            try
            {
                conexion.ComenzarTransaccion();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_AgregarPerfil";
                cmd.Transaction = conexion.RetornarSqlTransaccion();
                cmd.Connection = conexion.RetornarConexion();
                cmd.Parameters.Add("@nombre_grupo", System.Data.SqlDbType.VarChar, 20).Value = oPerfil.Grupo.Nombre;
                cmd.Parameters.Add("@nombre_formulario", System.Data.SqlDbType.VarChar, 20).Value = oPerfil.Formulario.Nombre;
                cmd.Parameters.Add("@nombre_permiso", System.Data.SqlDbType.VarChar, 20).Value = oPerfil.Permiso.Nombre;
                cmd.Parameters.Add("@usuario", System.Data.SqlDbType.NVarChar, 15).Value = oPerfil.Usuario;
                cmd.Parameters.Add("@operacion", System.Data.SqlDbType.NVarChar, 15).Value = oPerfil.Operacion;
                cmd.Parameters.Add("@fecha", System.Data.SqlDbType.DateTime).Value = oPerfil.Fecha;
                cmd.Parameters.Add("@equipo", System.Data.SqlDbType.NVarChar, 20).Value = oPerfil.Equipo;
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

        public static void EliminarPerfil(Entidades.Seguridad.Perfil oPerfil)
        {
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("SEGURIDADDolcePasta");

            try
            {
                conexion.ComenzarTransaccion();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_EliminarPerfil";
                cmd.Transaction = conexion.RetornarSqlTransaccion();
                cmd.Connection = conexion.RetornarConexion();
                cmd.Parameters.Add("@nombre_grupo", System.Data.SqlDbType.VarChar, 20).Value = oPerfil.Grupo.Nombre;
                cmd.Parameters.Add("@nombre_formulario", System.Data.SqlDbType.VarChar, 20).Value = oPerfil.Formulario.Nombre;
                cmd.Parameters.Add("@nombre_permiso", System.Data.SqlDbType.VarChar, 20).Value = oPerfil.Permiso.Nombre;
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
