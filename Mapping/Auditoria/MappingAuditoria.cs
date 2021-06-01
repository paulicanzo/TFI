using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Mapping.Auditoria
{
    public static class MappingAuditoria
    {
        public static List<Entidades.Auditoria.AuditoriaPerfil> RecuperarAuditoriaPerfil()
        {
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("AUDITORIADolcePasta");
            List<Entidades.Auditoria.AuditoriaPerfil> coleccionAuditoriaPerfil = new List<Entidades.Auditoria.AuditoriaPerfil>();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "sp_RecuperarAuditoriaPerfil";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = conexion.RetornarConexion();

                SqlDataReader reader;
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Entidades.Auditoria.AuditoriaPerfil oPerfil = new Entidades.Auditoria.AuditoriaPerfil();
                    oPerfil.Formulario = reader[0].ToString();
                    oPerfil.Grupo = reader[1].ToString();
                    oPerfil.Permiso = reader[2].ToString();
                    oPerfil.Usuario = reader[3].ToString();
                    oPerfil.Operacion = reader[4].ToString();
                    oPerfil.Fecha = Convert.ToDateTime(reader[5]);
                    oPerfil.Equipo = reader[6].ToString();
                    coleccionAuditoriaPerfil.Add(oPerfil); 
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
            return coleccionAuditoriaPerfil; 
        }

        public static void AgregarAuditoriaPerfil(Entidades.Auditoria.AuditoriaPerfil oAuditoria)
        {
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("AUDITORIADolcePasta");

            try
            {
                conexion.ComenzarTransaccion();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_AgregarAuditoriaPerfil";
                cmd.Transaction = conexion.RetornarSqlTransaccion();
                cmd.Connection = conexion.RetornarConexion();
                cmd.Parameters.Add("@Formulario", System.Data.SqlDbType.VarChar, 20).Value = oAuditoria.Formulario;
                cmd.Parameters.Add("@Grupo", System.Data.SqlDbType.VarChar, 20).Value = oAuditoria.Grupo;
                cmd.Parameters.Add("@Permiso", System.Data.SqlDbType.VarChar, 20).Value = oAuditoria.Permiso;
                cmd.Parameters.Add("@Usuario", System.Data.SqlDbType.NVarChar, 15).Value = oAuditoria.Usuario;
                cmd.Parameters.Add("@Operacion", System.Data.SqlDbType.NVarChar, 15).Value = oAuditoria.Operacion;
                cmd.Parameters.Add("@Fecha", System.Data.SqlDbType.DateTime).Value = oAuditoria.Fecha;
                cmd.Parameters.Add("@Equipo", System.Data.SqlDbType.NVarChar, 20).Value = oAuditoria.Equipo;
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

        public static List<Entidades.Auditoria.Auditoria> RecuperarAuditoriaLog()
        {
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("AUDITORIADolcePasta");
            List<Entidades.Auditoria.Auditoria> coleccionAuditoriaLog = new List<Entidades.Auditoria.Auditoria>();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "sp_RecuperarAuditoriaLog";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = conexion.RetornarConexion();

                SqlDataReader reader;
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Entidades.Auditoria.Auditoria log = new Entidades.Auditoria.Auditoria();
                    log.Usuario = reader[3].ToString();
                    log.Operacion = reader[2].ToString();
                    log.Fecha = Convert.ToDateTime(reader[0]);
                    log.Equipo = reader[1].ToString();
                    coleccionAuditoriaLog.Add(log);
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
            return coleccionAuditoriaLog;
        }

        public static void AgregarAuditoria(Entidades.Auditoria.Auditoria oAuditoria)
        {
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("AUDITORIADolcePasta");

            try
            {
                conexion.ComenzarTransaccion();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_AgregarAuditoria";
                cmd.Transaction = conexion.RetornarSqlTransaccion();
                cmd.Connection = conexion.RetornarConexion();
                cmd.Parameters.Add("@Usuario", System.Data.SqlDbType.VarChar, 15).Value = oAuditoria.Usuario;
                cmd.Parameters.Add("@Operacion", System.Data.SqlDbType.VarChar, 15).Value = oAuditoria.Operacion;
                cmd.Parameters.Add("@Fecha", System.Data.SqlDbType.DateTime).Value = oAuditoria.Fecha;
                cmd.Parameters.Add("@Equipo", System.Data.SqlDbType.VarChar, 20).Value = oAuditoria.Equipo;
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

        public static List<Entidades.Auditoria.AuditoriaOrdenCompra> RecuperarAuditoriaOrdenCompra()
        {
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("AUDIORIADolcePasta");
            List<Entidades.Auditoria.AuditoriaOrdenCompra> coleccionAuditoriaOrdenCompra = new List<Entidades.Auditoria.AuditoriaOrdenCompra>();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "sp_RecuperarAuditoriaOrdenCompra";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = conexion.RetornarConexion();

                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Entidades.Auditoria.AuditoriaOrdenCompra ordenCompra = new Entidades.Auditoria.AuditoriaOrdenCompra();
                    ordenCompra.NroOrdenCompra = Convert.ToInt32(reader[0]);
                    ordenCompra.Proveedor = reader[1].ToString();
                    ordenCompra.CondicionesPago = reader[2].ToString();
                    ordenCompra.FechaEmision = Convert.ToDateTime(reader[3]);
                    ordenCompra.FechaRecepcionMercaderia = Convert.ToDateTime(reader[4]);
                    ordenCompra.PrecioTotal = Convert.ToDecimal(reader[5]);
                    ordenCompra.Estado = reader[6].ToString();
                    ordenCompra.Usuario = reader[7].ToString();
                    ordenCompra.Operacion = reader[8].ToString();
                    ordenCompra.Fecha = Convert.ToDateTime(reader[9]);
                    ordenCompra.Equipo = reader[10].ToString();

                    SqlCommand cmdLOC = new SqlCommand();
                    cmdLOC.CommandText = "sp_RecuperarAuditoriaLineaOrdenCompra";
                    cmdLOC.CommandType = System.Data.CommandType.StoredProcedure;
                    cmdLOC.Parameters.Add("@id_OrdenCompra", System.Data.SqlDbType.BigInt).Value = ordenCompra.NroOrdenCompra;
                    cmdLOC.Connection = conexion.RetornarConexion();

                    SqlDataReader readers;
                    readers = cmdLOC.ExecuteReader();

                    while (readers.Read())
                    {
                        Entidades.Sistema.Proveedor oProveedor = new Entidades.Sistema.Proveedor();
                        Entidades.Sistema.CategoriaProducto oCategoria = new Entidades.Sistema.CategoriaProducto(); 
                        ordenCompra.NroOrdenCompra = Convert.ToInt32(readers[0]);
                        string producto = readers[1].ToString();
                        int cantidad = Convert.ToInt32(readers[2]);
                        decimal precio = Convert.ToDecimal(readers[3]);
                        Entidades.Auditoria.AuditoriaLineaOrdenCompra oLinea = new Entidades.Auditoria.AuditoriaLineaOrdenCompra();
                        oLinea.CargarDatos(producto, precio, cantidad);
                        ordenCompra.AgregarLineaOrdenCompra(oLinea);
                    }
                    coleccionAuditoriaOrdenCompra.Add(ordenCompra);
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
            return coleccionAuditoriaOrdenCompra; 
        }

        public static void AgregarAuditoriaOrdenCompra(Entidades.Auditoria.AuditoriaOrdenCompra oAuditoriaOC)
        {
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("AUDITORIADolcePasta");

            try
            {
                conexion.ComenzarTransaccion();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_AgregarAuditoriaOrdenCompra";
                cmd.Transaction = conexion.RetornarSqlTransaccion();
                cmd.Connection = conexion.RetornarConexion();
                cmd.Parameters.Add("@Usuario", System.Data.SqlDbType.VarChar, 15).Value = oAuditoriaOC.Usuario;
                cmd.Parameters.Add("@Operacion", System.Data.SqlDbType.VarChar, 15).Value = oAuditoriaOC.Operacion;
                cmd.Parameters.Add("@Fecha", System.Data.SqlDbType.DateTime).Value = oAuditoriaOC.Fecha;
                cmd.Parameters.Add("@Equipo", System.Data.SqlDbType.VarChar, 20).Value = oAuditoriaOC.Equipo;
                cmd.Parameters.Add("@NroOrdenCompra", System.Data.SqlDbType.Int).Value = oAuditoriaOC.NroOrdenCompra;
                cmd.Parameters.Add("@Proveedor", System.Data.SqlDbType.NVarChar, 30).Value = oAuditoriaOC.Proveedor;
                cmd.Parameters.Add("@CondicionesPago", System.Data.SqlDbType.NVarChar, 20).Value = oAuditoriaOC.CondicionesPago;
                cmd.Parameters.Add("@FechaEmision", System.Data.SqlDbType.DateTime).Value = oAuditoriaOC.FechaEmision;
                cmd.Parameters.Add("@FechaRecepcionMercaderia", System.Data.SqlDbType.DateTime).Value = oAuditoriaOC.FechaRecepcionMercaderia;
                cmd.Parameters.Add("@PrecioTotal", System.Data.SqlDbType.Decimal).Value = oAuditoriaOC.PrecioTotal;
                cmd.Parameters.Add("@Estado", System.Data.SqlDbType.NVarChar, 20).Value = oAuditoriaOC.Estado;
                int nroOC = Convert.ToInt32(cmd.ExecuteScalar());
                oAuditoriaOC.NroOrdenCompra = nroOC;

                SqlCommand cmdLOC = new SqlCommand();
                cmdLOC.CommandText = "sp_AgregarAuditoriaLineaOrdendeCompra";
                cmdLOC.CommandType = System.Data.CommandType.StoredProcedure;
                cmdLOC.Connection = conexion.RetornarConexion();
                cmdLOC.Transaction = conexion.RetornarSqlTransaccion();
                cmdLOC.Parameters.Add("@OrdenCompra", System.Data.SqlDbType.Int).Value = nroOC;
                cmdLOC.Parameters.Add("@Producto", System.Data.SqlDbType.NVarChar, 50);
                cmdLOC.Parameters.Add("@Cantidad", System.Data.SqlDbType.Int);
                cmdLOC.Parameters.Add("@Precio", System.Data.SqlDbType.Decimal);

                foreach (Entidades.Auditoria.AuditoriaLineaOrdenCompra item in oAuditoriaOC.AuditoriaLineaOrdenCompra)
                {
                    cmdLOC.Parameters["@Producto"].Value = item.Producto;
                    cmdLOC.Parameters["@Cantidad"].Value = item.Cantidad;
                    cmdLOC.Parameters["@Precio"].Value = item.PrecioUnitario;
                    cmdLOC.ExecuteNonQuery();
                }
                conexion.RetornarSqlTransaccion().Commit();
            }
            catch (SqlException ex)
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

