using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Home : System.Web.UI.MasterPage
    {
        Entidades.Seguridad.Usuario oUsuario;
        List<Entidades.Seguridad.Perfil> perfiles;

        public void AsignarPermisosAFormPrincipal(Entidades.Seguridad.Usuario oUsuario)
        {
            perfiles = Controladora.Seguridad.ControladoraIniciarSesion.ObtenerInstancia().RecuperarPerfil(oUsuario);
            foreach (Entidades.Seguridad.Perfil oPerfil in perfiles)
            {
                if("Acceso" == oPerfil.Permiso.Nombre)
                {
                    //foreach (ToolStripMenuItem item in menustrip1.Item)
                    //{
                    //    if (oPerfil.Formulario.Nombre == item.Text.ToString())
                    //    {
                    //        item.Enabled = true;
                    //        break;
                    //    }
                    //    foreach (ToolStripMenuItem item1 in item.DropDownItems)
                    //    {
                    //        if (oPerfil.Formulario.Nombre == item1.Text)
                    //        {
                    //            item1.Enabled = true;
                    //            break;
                    //        }
                    //    }
                    //}
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //public WebForm1(Entidades.Seguridad.Usuario usuario)
        //{
        //   InitializeComponent();
        //    oUsuario = new Entidades.Seguridad.Usuario();
        //    oUsuario = usuario;

        //    AsignarPermisosAFormPrincipal(oUsuario);            
        //}
    }
}