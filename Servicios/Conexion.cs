using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
[assembly: CLSCompliant(true)]

namespace Servicios
{
    public class Conexion
    {
        private SqlConnection conexion;
        private SqlTransaction transaccion; 

        public string ObtenerConnectionString(string valor)
        {
            string oConexion = null;
            foreach (System.Configuration.ConnectionStringSettings item in ConfigurationManager.ConnectionStrings) 
            {
                if(item.Name == valor)
                {
                    oConexion = item.ConnectionString;
                    break; 
                }
            }
            return oConexion; 
        }

        public Conexion()
        {
            conexion = new SqlConnection(); 
        }

        public void Conectar(string _conexion)
        {
            foreach (System.Configuration.ConnectionStringSettings item in ConfigurationManager.ConnectionStrings)
            {
                if(item.Name == _conexion)
                {
                    conexion.ConnectionString = item.ConnectionString; 
                    if(conexion.State == System.Data.ConnectionState.Closed)
                    {
                        conexion.Open(); 
                    }
                    break; 
                }
            }
        }

        public void Desconectar()
        {
            conexion.Close(); 
        }

        public SqlConnection RetornarConexion()
        {
            return conexion; 
        }

        public void ComenzarTransaccion()
        {
            transaccion = conexion.BeginTransaction(); 
        }

        public SqlTransaction RetornarSqlTransaccion()
        {
            return transaccion;
        }

    }
}
