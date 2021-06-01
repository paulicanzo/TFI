using System;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace Mapping.Sistema
{
    public class MappingProvincias
    {
        public static List<Entidades.Sistema.Provinicia> RecuperarProvincias()
        {
            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("DolcePasta");
            List<Entidades.Sistema.Provinicia> coleccionProvincias = new List<Entidades.Sistema.Provinicia>();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "sp_RecuperarProvincias";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = conexion.RetornarConexion();
                
                SqlDataReader reader;
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Entidades.Sistema.Provinicia oProvincia = new Entidades.Sistema.Provinicia(); 
                    int id = Convert.ToInt32(reader[0]);
                    oProvincia.Nombre = reader[1].ToString();

                    SqlCommand cmdLocalidad = new SqlCommand();
                    cmdLocalidad.CommandText = "sp_RecuperarLocalidades";
                    cmdLocalidad.CommandType = System.Data.CommandType.StoredProcedure;
                    cmdLocalidad.Parameters.Add("@id_provincia", System.Data.SqlDbType.Int).Value = id;
                    cmdLocalidad.Connection = conexion.RetornarConexion();

                    SqlDataReader readerLocalidad;
                    readerLocalidad = cmdLocalidad.ExecuteReader();
                    while (readerLocalidad.Read())
                    {
                        Entidades.Sistema.Localidad oLocalidad = new Entidades.Sistema.Localidad();
                        oLocalidad.Nombre = readerLocalidad[0].ToString();
                        oProvincia.AgregarLocalidad(oLocalidad);
                    }
                    coleccionProvincias.Add(oProvincia); 
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
            return coleccionProvincias;
        }
    }
}
