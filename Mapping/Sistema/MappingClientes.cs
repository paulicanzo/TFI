using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Mapping.Sistema
{
    public static class MappingClientes
    {
        public static List<Entidades.Sistema.Cliente> RecuperarCliente()
        {
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("Sistema");
            List<Entidades.Sistema.Cliente> coleccionClientes = new List<Entidades.Sistema.Cliente>();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "sp_RecuperarClientes";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = conexion.RetornarConexion();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Entidades.Sistema.Cliente oCliente = new Entidades.Sistema.Cliente();
                    oCliente.Codigo = Convert.ToInt32(reader[0]); 
                    oCliente.RazonSocial = reader[1].ToString();
                    oCliente.Telefono = reader[2].ToString();
                    oCliente.Titular = reader[3].ToString();
                    oCliente.CorreoElectronico = reader[4].ToString();
                    oCliente.CodigoPostal = Convert.ToInt32(reader[5]);
                    oCliente.TipoCliente = reader[6].ToString();
                    oCliente.Cuit = Convert.ToInt32(reader[7]);
                    bool estado = Convert.ToBoolean(reader[8]);
                    if (!estado) oCliente.CambiarEstado();
                    Entidades.Sistema.Localidad oLocalidad = new Entidades.Sistema.Localidad();
                    oLocalidad.Nombre = reader[9].ToString();
                    Entidades.Sistema.CategoriaIVA oCategoriaIVA = new Entidades.Sistema.CategoriaIVA();
                    oCategoriaIVA.Nombre = reader[10].ToString();
                    oCliente.Direccion = reader[11].ToString();
                    Entidades.Sistema.Provinicia oProvincia = new Entidades.Sistema.Provinicia();
                    oProvincia.Nombre = reader[12].ToString();
                    coleccionClientes.Add(oCliente);
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
            return coleccionClientes; 
        }

        public static void AgregarCliente(Entidades.Sistema.Cliente oCliente)
        {
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("DolcePasta");

            try
            {
                conexion.ComenzarTransaccion();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_AgregarCliente";
                cmd.Transaction = conexion.RetornarSqlTransaccion();
                cmd.Connection = conexion.RetornarConexion();
                cmd.Parameters.Add("@RazonSocial", System.Data.SqlDbType.NVarChar, 30).Value = oCliente.RazonSocial;
                cmd.Parameters.Add("@Localidad", System.Data.SqlDbType.NVarChar, 30).Value = oCliente.Localidad.Nombre;
                cmd.Parameters.Add("@SituacionFiscal", System.Data.SqlDbType.NVarChar, 20).Value = oCliente.SituacionFiscal.Nombre;
                cmd.Parameters.Add("@Telefono", System.Data.SqlDbType.Int).Value = oCliente.Telefono;
                cmd.Parameters.Add("@Titular", System.Data.SqlDbType.NVarChar, 30).Value = oCliente.Titular;
                cmd.Parameters.Add("@CorreoElectronico", System.Data.SqlDbType.NVarChar, 100).Value = oCliente.CorreoElectronico;
                cmd.Parameters.Add("@CodigoPostal", System.Data.SqlDbType.Int).Value = oCliente.CodigoPostal;
                cmd.Parameters.Add("@TipoCliente", System.Data.SqlDbType.NVarChar, 30).Value = oCliente.TipoCliente;
                cmd.Parameters.Add("@CUIT", System.Data.SqlDbType.Int).Value = oCliente.Cuit;
                cmd.Parameters.Add("@Estado", System.Data.SqlDbType.Bit).Value = oCliente.Estado;
                cmd.Parameters.Add("@Direccion", System.Data.SqlDbType.NVarChar, 30).Value = oCliente.Direccion;
                cmd.Parameters.Add("@Provincia", System.Data.SqlDbType.NVarChar, 30).Value = oCliente.Localidad.Provincia.Nombre;
                oCliente.Codigo = Convert.ToInt32(cmd.ExecuteScalar());

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

        public static void ModificarCliente(Entidades.Sistema.Cliente oCliente)
        {
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("DolcePasta");

            try
            {
                conexion.ComenzarTransaccion();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_ModificarCliente";
                cmd.Transaction = conexion.RetornarSqlTransaccion();
                cmd.Connection = conexion.RetornarConexion();

                cmd.Parameters.Add("@RazonSocial", System.Data.SqlDbType.NVarChar, 30).Value = oCliente.RazonSocial;
                cmd.Parameters.Add("@Localidad", System.Data.SqlDbType.NVarChar, 30).Value = oCliente.Localidad.Nombre;
                cmd.Parameters.Add("@CategoriaIva", System.Data.SqlDbType.NVarChar, 20).Value = oCliente.SituacionFiscal.Nombre;
                cmd.Parameters.Add("@Telefono", System.Data.SqlDbType.Int).Value = oCliente.Telefono;
                cmd.Parameters.Add("@Titular", System.Data.SqlDbType.NVarChar, 30).Value = oCliente.Titular;
                cmd.Parameters.Add("@CorreoElectronico", System.Data.SqlDbType.NVarChar, 100).Value = oCliente.CorreoElectronico;
                cmd.Parameters.Add("@CodigoPostal", System.Data.SqlDbType.Int).Value = oCliente.CodigoPostal;
                cmd.Parameters.Add("@TipoCliente", System.Data.SqlDbType.NVarChar, 30).Value = oCliente.TipoCliente;
                cmd.Parameters.Add("@CUIT", System.Data.SqlDbType.Int).Value = oCliente.Cuit;
                cmd.Parameters.Add("@Estado", System.Data.SqlDbType.Bit).Value = oCliente.Estado;
                cmd.Parameters.Add("@Direccion", System.Data.SqlDbType.NVarChar, 30).Value = oCliente.Direccion;
                cmd.Parameters.Add("@Provincia", System.Data.SqlDbType.NVarChar, 30).Value = oCliente.Localidad.Provincia.Nombre;

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

