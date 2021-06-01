using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Seguridad
{
    public partial class MDSCambiarClave : System.Web.UI.Page
    {
        Entidades.Seguridad.Usuario oUsuarioLogueado;
        private Entidades.Seguridad.Usuario oUsuario;
        List<Entidades.Seguridad.Perfil> Perfiles; 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.Aceptar.Visible = true;
                this.Cancelar.Visible = true;
                oUsuario = (Entidades.Seguridad.Usuario)Session["Usuario"];

                oUsuarioLogueado = (Entidades.Seguridad.Usuario)Session["Usuario"];
                txtUsuario.Text = oUsuarioLogueado.NombreUsuario;
                txtUsuario.Enabled = false;
                txtPassActual.Focus();
            }
            else
            {
                this.Aceptar.Visible = true;
                this.Cancelar.Visible = true;
                oUsuario = (Entidades.Seguridad.Usuario)Session["Usuario"];

                oUsuarioLogueado = (Entidades.Seguridad.Usuario)Session["Usuario"];
                txtUsuario.Text = oUsuarioLogueado.NombreUsuario;
                txtUsuario.Enabled = false;
                txtPassActual.Focus();
            }
        }
        protected void Aceptar_Click(object sender, EventArgs e)
        {
            string PassNueva, PassVieja;
            PassVieja = txtPassActual.Text;
            PassNueva = txtPassNueva.Text; 
            if(Controladora.Seguridad.ControladoraCambiarClave.ObtenerInstancia().CambiarClave(oUsuarioLogueado, PassVieja, PassNueva))
            {
                Response.Redirect("/Sistema/EmpleadoBackEnd.aspx");
            }
        }

        protected void Cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Sistema/EmpleadoBackEnd.aspx");
        }

    }
}

