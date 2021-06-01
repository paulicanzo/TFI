using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Mapping.Sistema
{
    public class MappingProveedores
    {
        private static MappingProveedores instancia; 
        public static MappingProveedores ObtenerInstancia()
        {
            if (instancia == null) instancia = new MappingProveedores();
            return instancia;
        }

        private List<Entidades.Sistema.Proveedor> listaProveedor; 
        private MappingProveedores()
        {
            listaProveedor = new List<Entidades.Sistema.Proveedor>();
            listaProveedor = RecuperarProveedores(); 
        }

        public List<Entidades.Sistema.Proveedor> Recuperar()
        {
            return listaProveedor;
        }

        private static List<Entidades.Sistema.Proveedor> RecuperarProveedores()
        {
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("DolcePasta");
            List<Entidades.Sistema.Proveedor> coleccionProveedores = new List<Entidades.Sistema.Proveedor>();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "sp_RecuperarProveedores";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = conexion.RetornarConexion();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Entidades.Sistema.Proveedor oProveedor = new Entidades.Sistema.Proveedor();
                    oProveedor.DenominacionLegal = reader[0].ToString();

                    Entidades.Sistema.Localidad oLocalidad = new Entidades.Sistema.Localidad();
                    oLocalidad.Nombre = reader[9].ToString();

                    Entidades.Sistema.Provinicia oProvincia = new Entidades.Sistema.Provinicia();
                    oProvincia.Nombre = reader[12].ToString();

                    Entidades.Sistema.CategoriaIVA oCategoria = new Entidades.Sistema.CategoriaIVA();
                    oCategoria.Nombre = reader[10].ToString();

                    oProveedor.Telefono = reader[1].ToString();
                    oProveedor.Titular = reader[2].ToString();
                    oProveedor.CorreoElectronico = reader[3].ToString();
                    oProveedor.CodigoPostal = Convert.ToInt32(reader[4]);
                    oProveedor.Encargado = reader[5].ToString();
                    oProveedor.Cuit = Convert.ToInt32(reader[6]);
                    oProveedor.IngresosBrutos = Convert.ToInt32(reader[7]);
                    bool estado = Convert.ToBoolean(reader[8]);
                    if (!estado) oProveedor.CambiarEstado();
                    oProveedor.Direccion = reader[11].ToString();

                    SqlCommand cmdProveedorCondiciones = new SqlCommand();
                    cmdProveedorCondiciones.CommandText = "sp_RecuperarProveedorCondiciones";
                    cmdProveedorCondiciones.CommandType = System.Data.CommandType.StoredProcedure;
                    cmdProveedorCondiciones.Parameters.Add("@Cuit", System.Data.SqlDbType.BigInt).Value = oProveedor.Cuit;
                    cmdProveedorCondiciones.Connection = conexion.RetornarConexion();

                    SqlDataReader readerCondiciones;
                    readerCondiciones = cmdProveedorCondiciones.ExecuteReader();
                    while (readerCondiciones.Read())
                    {
                        Entidades.Sistema.CondicionesPago oCondiciones = new Entidades.Sistema.CondicionesPago();
                        oCondiciones.Nombre = readerCondiciones[0].ToString();
                        oCondiciones.Descripcion = readerCondiciones[1].ToString();
                        oProveedor.AgregarCondicionPago(oCondiciones);
                    }
                    coleccionProveedores.Add(oProveedor);
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
            return coleccionProveedores;
        }

        public static void AgregarProveedor (Entidades.Sistema.Proveedor oProveedor)
        {
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("DolcePasta");

            try
            {
                conexion.ComenzarTransaccion();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_AgregarProveedor";
                cmd.Transaction = conexion.RetornarSqlTransaccion();
                cmd.Connection = conexion.RetornarConexion();
                cmd.Parameters.Add("@DenominacionLegal", System.Data.SqlDbType.NVarChar, 30).Value = oProveedor.DenominacionLegal;
                cmd.Parameters.Add("@Localidad", System.Data.SqlDbType.NVarChar, 30).Value = oProveedor.Localidad.Nombre;
                cmd.Parameters.Add("@CategoriaIva", System.Data.SqlDbType.NVarChar, 20).Value = oProveedor.CategoriaIVA.Nombre;
                cmd.Parameters.Add("@Telefono", System.Data.SqlDbType.Int).Value = oProveedor.Telefono;
                cmd.Parameters.Add("@Titular", System.Data.SqlDbType.NVarChar, 30).Value = oProveedor.Titular;
                cmd.Parameters.Add("@CorreoElectronico", System.Data.SqlDbType.NVarChar, 100).Value = oProveedor.CorreoElectronico;
                cmd.Parameters.Add("@CodigoPostal", System.Data.SqlDbType.Int).Value = oProveedor.CodigoPostal;
                cmd.Parameters.Add("@Encargado", System.Data.SqlDbType.NVarChar, 30).Value = oProveedor.Encargado;
                cmd.Parameters.Add("@CUIT", System.Data.SqlDbType.Int).Value = oProveedor.Cuit;
                cmd.Parameters.Add("@IngresosBrutos", System.Data.SqlDbType.Decimal).Value = oProveedor.IngresosBrutos;
                cmd.Parameters.Add("@Estado", System.Data.SqlDbType.Bit).Value = oProveedor.Estado;
                cmd.Parameters.Add("@Provincia", System.Data.SqlDbType.NVarChar, 30).Value = oProveedor.Localidad.Provincia.Nombre;
                cmd.Parameters.Add("@Direccion", System.Data.SqlDbType.NVarChar, 30).Value = oProveedor.Direccion;
                cmd.ExecuteNonQuery();

                SqlCommand cmdEliminarCondicion = new SqlCommand();
                cmdEliminarCondicion.CommandType = System.Data.CommandType.StoredProcedure;
                cmdEliminarCondicion.CommandText = "sp_EliminarProveedorCondiciones";
                cmdEliminarCondicion.Transaction = conexion.RetornarSqlTransaccion();
                cmdEliminarCondicion.Connection = conexion.RetornarConexion();
                cmdEliminarCondicion.Parameters.Add("@cuit", System.Data.SqlDbType.Int).Value = oProveedor.Cuit;
                cmdEliminarCondicion.ExecuteNonQuery();

                SqlCommand cmdAgregarCondicion = new SqlCommand();
                cmdAgregarCondicion.CommandText = "sp_AgregarProveedorCondiciones";
                cmdAgregarCondicion.CommandType = System.Data.CommandType.StoredProcedure;
                cmdAgregarCondicion.Parameters.Add("@cuit", System.Data.SqlDbType.Int).Value = oProveedor.Cuit;
                cmdAgregarCondicion.Parameters.Add("@NombreCondicionesPago", System.Data.SqlDbType.VarChar, 20);

                foreach (Entidades.Sistema.CondicionesPago item in oProveedor.CondicionesPago)
                {
                    cmdAgregarCondicion.Parameters["@NombreCondicionesPago"].Value = item.Nombre;
                    cmdAgregarCondicion.ExecuteNonQuery();
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

        public static void ModificarProveedor(Entidades.Sistema.Proveedor oProveedor)
        {
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("DolcePasta");
            try
            {
                conexion.ComenzarTransaccion();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_ModificarProveedor";
                cmd.Transaction = conexion.RetornarSqlTransaccion();
                cmd.Connection = conexion.RetornarConexion();
                cmd.Parameters.Add("@DenominacionLegal", System.Data.SqlDbType.NVarChar, 30).Value = oProveedor.DenominacionLegal;
                cmd.Parameters.Add("@Localidad", System.Data.SqlDbType.NVarChar, 30).Value = oProveedor.Localidad.Nombre;
                cmd.Parameters.Add("@Telefono", System.Data.SqlDbType.Int).Value = oProveedor.Telefono;
                cmd.Parameters.Add("@Titular", System.Data.SqlDbType.NVarChar, 30).Value = oProveedor.Titular;
                cmd.Parameters.Add("@CorreoElectronico", System.Data.SqlDbType.NVarChar, 100).Value = oProveedor.CorreoElectronico;
                cmd.Parameters.Add("@CodigoPostal", System.Data.SqlDbType.Int).Value = oProveedor.CodigoPostal;
                cmd.Parameters.Add("@Encargado", System.Data.SqlDbType.NVarChar, 20).Value = oProveedor.Encargado;
                cmd.Parameters.Add("@CUIT", System.Data.SqlDbType.Int).Value = oProveedor.Cuit;
                cmd.Parameters.Add("@IngresosBrutos", System.Data.SqlDbType.Int).Value = oProveedor.IngresosBrutos;
                cmd.Parameters.Add("@Estado", System.Data.SqlDbType.Bit).Value = oProveedor.Estado;
                cmd.Parameters.Add("@CategoriaIva", System.Data.SqlDbType.NVarChar, 20).Value = oProveedor.CategoriaIVA.Nombre;
                cmd.Parameters.Add("@Direccion", System.Data.SqlDbType.NVarChar, 30).Value = oProveedor.Direccion;
                cmd.Parameters.Add("@Provincia", System.Data.SqlDbType.NVarChar, 30).Value = oProveedor.Localidad.Provincia.Nombre;
                cmd.ExecuteNonQuery();

                SqlCommand cmdEliminarCondicion = new SqlCommand();
                cmdEliminarCondicion.CommandType = System.Data.CommandType.StoredProcedure;
                cmdEliminarCondicion.CommandText = "sp_EliminarProveedorCondiciones";
                cmdEliminarCondicion.Transaction = conexion.RetornarSqlTransaccion();
                cmdEliminarCondicion.Connection = conexion.RetornarConexion();
                cmdEliminarCondicion.Parameters.Add("@cuit", System.Data.SqlDbType.Int).Value = oProveedor.Cuit;
                cmdEliminarCondicion.ExecuteNonQuery();

                SqlCommand cmdAgregarCondicion = new SqlCommand();
                cmdAgregarCondicion.CommandText = "sp_AgregarProveedorCondiciones";
                cmdAgregarCondicion.CommandType = System.Data.CommandType.StoredProcedure;
                cmdAgregarCondicion.Connection = conexion.RetornarConexion();
                cmdAgregarCondicion.Transaction = conexion.RetornarSqlTransaccion();
                cmdAgregarCondicion.Parameters.Add("@cuit", System.Data.SqlDbType.Int).Value = oProveedor.Cuit;
                cmdAgregarCondicion.Parameters.Add("@NombreCondicionesPago", System.Data.SqlDbType.VarChar, 20);

                foreach (Entidades.Sistema.CondicionesPago item in oProveedor.CondicionesPago)
                {
                    cmdAgregarCondicion.Parameters["@NombreCondicionesPago"].Value = item.Nombre;
                    cmdAgregarCondicion.ExecuteNonQuery();
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
