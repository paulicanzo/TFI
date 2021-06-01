using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace Mapping.Seguridad
{
    public class MappingMenu
    {
        public static List<Entidades.Seguridad.Menu> RecuperarMenu()
        {
            SqlCommand cmdMenu = new SqlCommand();
            cmdMenu.CommandText = "sp_ConsultarMenu";
            cmdMenu.CommandType = System.Data.CommandType.StoredProcedure;

            Servicios.Conexion conexion = new Servicios.Conexion();
            conexion.Conectar("SEGURIDADDolcePasta");

            cmdMenu.Connection = conexion.RetornarConexion();

            SqlDataReader drMenu = cmdMenu.ExecuteReader();
            List<Entidades.Seguridad.Menu> coleccionMenu = new List<Entidades.Seguridad.Menu>();
            while (drMenu.Read())
            {
                Entidades.Seguridad.Menu oMenu = new Entidades.Seguridad.Menu();
                oMenu.IdMenu = Convert.ToInt32(drMenu["id_menu"]);
                oMenu.Descripcion = drMenu["descripcion"].ToString();
                oMenu.IdParentMenu = Convert.ToInt32(drMenu["id_parent_menu"]);
                oMenu.Url = drMenu["url"].ToString();

                coleccionMenu.Add(oMenu);
            }
            conexion.Desconectar();
            return coleccionMenu;
        }
    }
}
