using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Mapping.Sistema
{
    public class MappingCondicionesPago
    {
        private static MappingCondicionesPago instancia; 
        public static MappingCondicionesPago ObtenerInstancia()
        {
            if (instancia == null) instancia = new MappingCondicionesPago();
            return instancia;
        }
        private List<Entidades.Sistema.CondicionesPago> listaCondicionesPago; 
        private MappingCondicionesPago()
        {
            listaCondicionesPago = new List<Entidades.Sistema.CondicionesPago>();
            listaCondicionesPago = RecuperarCondicionesPago();
        }

        public List<Entidades.Sistema.CondicionesPago> Recuperar()
        {
            return listaCondicionesPago;
        }

        private static List<Entidades.Sistema.CondicionesPago> RecuperarCondicionesPago()
        {
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("DolcePasta");
            List<Entidades.Sistema.CondicionesPago> coleccionCondicionPago = new List<Entidades.Sistema.CondicionesPago>();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "sp_RecuperarCondicionesPago";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = conexion.RetornarConexion();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Entidades.Sistema.CondicionesPago oCondicionPago = new Entidades.Sistema.CondicionesPago();
                    oCondicionPago.Nombre = reader[0].ToString();
                    oCondicionPago.Descripcion = reader[1].ToString();
                    coleccionCondicionPago.Add(oCondicionPago);
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
            return coleccionCondicionPago;
        }

        public static void AgregarCondicionesPago(Entidades.Sistema.CondicionesPago oCondicionesPago)
        {
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("DolcePasta");

            try
            {
                conexion.ComenzarTransaccion();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_AgregarCondicionesPago";
                cmd.Transaction = conexion.RetornarSqlTransaccion();
                cmd.Connection = conexion.RetornarConexion();
                cmd.Parameters.Add("@NombreCondicionesPago", System.Data.SqlDbType.NVarChar, 20).Value = oCondicionesPago.Nombre;
                cmd.Parameters.Add("@Descripcion", System.Data.SqlDbType.NVarChar, 20).Value = oCondicionesPago.Descripcion;
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

        public static bool EliminarCondicionesPago(Entidades.Sistema.CondicionesPago oCondicionesPago)
        {
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("DolcePasta");

            try
            {
                conexion.ComenzarTransaccion();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_EliminarCondicionesPago";
                cmd.Transaction = conexion.RetornarSqlTransaccion();
                cmd.Connection = conexion.RetornarConexion();
                cmd.Parameters.Add("@NombreCondicionesPago", System.Data.SqlDbType.NVarChar, 20).Value = oCondicionesPago.Nombre;
                cmd.ExecuteNonQuery();

                conexion.RetornarSqlTransaccion().Rollback();
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

