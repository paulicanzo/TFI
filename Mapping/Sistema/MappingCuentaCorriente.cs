using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Mapping.Sistema
{
    public static class MappingCuentaCorriente
    {
        public static List<Entidades.Sistema.CuentaCorriente> RecuperarCuentaCorriente()
        {
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("DolcePasta");
            List<Entidades.Sistema.CuentaCorriente> coleccionCuentaCorriente = new List<Entidades.Sistema.CuentaCorriente>();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "sp_RecuperarCuentasCorrientes";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = conexion.RetornarConexion();

                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Entidades.Sistema.CuentaCorriente oCuentaCorriente = new Entidades.Sistema.CuentaCorriente();
                    oCuentaCorriente.Codigo = Convert.ToInt32(reader[0]);
                    oCuentaCorriente.Saldo = Convert.ToDecimal(reader[1]);

                    Entidades.Sistema.Cliente cliente = new Entidades.Sistema.Cliente();
                    cliente.Codigo = Convert.ToInt32(reader[2]);
                    cliente.RazonSocial = reader[3].ToString();
                    cliente.Telefono = reader[4].ToString();
                    cliente.Titular = reader[5].ToString();
                    cliente.CorreoElectronico = reader[6].ToString();
                    cliente.CodigoPostal = Convert.ToInt32(reader[7]);
                    cliente.TipoCliente = reader[8].ToString();
                    cliente.Cuit = Convert.ToInt32(reader[9]);
                    bool estado = Convert.ToBoolean(reader[10]);
                    if (estado) cliente.CambiarEstado();

                    Entidades.Sistema.Localidad oLocalidad = new Entidades.Sistema.Localidad();
                    oLocalidad.Nombre = reader[11].ToString();
                    cliente.Localidad = oLocalidad;

                    Entidades.Sistema.CategoriaIVA oCategoriaIVA = new Entidades.Sistema.CategoriaIVA();
                    oCategoriaIVA.Nombre = reader[12].ToString();
                    cliente.SituacionFiscal = oCategoriaIVA;
                    cliente.Direccion = reader[13].ToString();

                    SqlCommand cmdMovimiento = new SqlCommand();
                    cmdMovimiento.CommandText = "sp_RecuperarMovimientos";
                    cmdMovimiento.CommandType = System.Data.CommandType.StoredProcedure;
                    cmdMovimiento.Parameters.Add("@CtaCte", System.Data.SqlDbType.Int).Value = oCuentaCorriente.Codigo;
                    oCuentaCorriente.Cliente = cliente;
                    cmdMovimiento.Connection = conexion.RetornarConexion();

                    SqlDataReader readerMovimiento;
                    readerMovimiento = cmdMovimiento.ExecuteReader();
                    while (readerMovimiento.Read())
                    {
                        Entidades.Sistema.Movimiento movimiento = new Entidades.Sistema.Movimiento();
                        movimiento.Fecha = Convert.ToDateTime(readerMovimiento[0]);
                        movimiento.Concepto = readerMovimiento[1].ToString();
                        movimiento.Monto = Convert.ToDecimal(readerMovimiento[2]);
                        string tipo = readerMovimiento[3].ToString();

                        if (tipo == Entidades.Sistema.Movimiento.MovimientoTipo.Ingreso.ToString())
                            movimiento.Tipo = Entidades.Sistema.Movimiento.MovimientoTipo.Ingreso;
                        else movimiento.Tipo = Entidades.Sistema.Movimiento.MovimientoTipo.Egreso;
                        movimiento.ComprobanteAbonado = Convert.ToInt32(readerMovimiento[4]);

                        Entidades.Sistema.CondicionesPago pago = new Entidades.Sistema.CondicionesPago();
                        pago.Nombre = readerMovimiento[5].ToString();
                        movimiento.FormaPago = pago;

                        oCuentaCorriente.AgregarMovimiento(movimiento);
                    }
                    coleccionCuentaCorriente.Add(oCuentaCorriente); 
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
            return coleccionCuentaCorriente;
        }

        public static void ModificarCuentaCorriente(Entidades.Sistema.CuentaCorriente CtaCte)
        {
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("DolcePasta");

            try
            {
                conexion.ComenzarTransaccion();
                SqlCommand cmdEliminarMovimiento = new SqlCommand();
                cmdEliminarMovimiento.CommandType = System.Data.CommandType.StoredProcedure;
                cmdEliminarMovimiento.CommandText = "sp_EliminarMovimiento";
                cmdEliminarMovimiento.Transaction = conexion.RetornarSqlTransaccion();
                cmdEliminarMovimiento.Connection = conexion.RetornarConexion();
                cmdEliminarMovimiento.Parameters.Add("@CtaCte", System.Data.SqlDbType.Int).Value = CtaCte.Codigo;
                cmdEliminarMovimiento.ExecuteNonQuery();

                SqlCommand cmdAgregarMovimiento = new SqlCommand();
                cmdAgregarMovimiento.CommandText = "sp_AgregarMovimiento";
                cmdAgregarMovimiento.CommandType = System.Data.CommandType.StoredProcedure;
                cmdAgregarMovimiento.Connection = conexion.RetornarConexion();
                cmdAgregarMovimiento.Transaction = conexion.RetornarSqlTransaccion();
                cmdAgregarMovimiento.Parameters.Add("@CtaCte", System.Data.SqlDbType.Int).Value = CtaCte.Codigo;
                cmdAgregarMovimiento.Parameters.Add("@CondidionPago", System.Data.SqlDbType.NVarChar, 20);
                cmdAgregarMovimiento.Parameters.Add("@ComprobanteAbonado", System.Data.SqlDbType.Int);
                cmdAgregarMovimiento.Parameters.Add("@Monto", System.Data.SqlDbType.Decimal);
                cmdAgregarMovimiento.Parameters.Add("@Concepto", System.Data.SqlDbType.NVarChar, 100);
                cmdAgregarMovimiento.Parameters.Add("@Fecha", System.Data.SqlDbType.DateTime);
                cmdAgregarMovimiento.Parameters.Add("@Tipo", System.Data.SqlDbType.NVarChar, 20);

                foreach (Entidades.Sistema.Movimiento item in CtaCte.Movimiento)
                {
                    cmdAgregarMovimiento.Parameters["@CtaCte"].Value = CtaCte.Codigo;
                    cmdAgregarMovimiento.Parameters["@CondidionPago"].Value = item.FormaPago.Nombre;
                    cmdAgregarMovimiento.Parameters["@ComprobanteAbonado"].Value = item.ComprobanteAbonado;
                    cmdAgregarMovimiento.Parameters["@Monto"].Value = item.Monto;
                    cmdAgregarMovimiento.Parameters["@Concepto"].Value = item.Concepto;
                    cmdAgregarMovimiento.Parameters["@Fecha"].Value = item.Fecha;
                    cmdAgregarMovimiento.Parameters["@Tipo"].Value = item.Tipo;
                    cmdAgregarMovimiento.ExecuteNonQuery();
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
