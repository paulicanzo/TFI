using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace Mapping.Sistema
{
    public static class MappingCategoriasIVA
    {
        public static List<Entidades.Sistema.CategoriaIVA> RecuperarCategoriaIVA()
        {
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("DolcePasta");
            List<Entidades.Sistema.CategoriaIVA> coleccionCategoriaIVA = new List<Entidades.Sistema.CategoriaIVA>();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "sp_RecuperarCategoriaIva";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = conexion.RetornarConexion();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Entidades.Sistema.CategoriaIVA oCategoriaIVA = new Entidades.Sistema.CategoriaIVA();
                    oCategoriaIVA.Nombre = reader[0].ToString();
                    coleccionCategoriaIVA.Add(oCategoriaIVA);
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
            return coleccionCategoriaIVA;
        }
    }
}
