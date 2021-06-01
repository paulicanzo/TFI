using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class BackEnd : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}

/*
namespace VistaWeb
{
    public partial class BackEnd : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["Usuario"] != null)
                {
                    btnLinkButton1.Visible = true;
                    ButtonCerrarSecion.Visible = true;
                    LabelSesion.Visible = true;
                    btnSecion.Enabled = true;
                    oUsuario = (Entidades.Seguridad.Usuario)Session["Usuario"];
                    btnSecion.Text = oUsuario.NombreUsuario;
                    LabelSesion.Text = oUsuario.NombreUsuario;
                    //this.EtiquetaLogin.Visible = false;

                }
                else
                {
                    btnLinkButton1.Visible = false;
                    ButtonCerrarSecion.Visible = false;
                    LabelSesion.Visible = false;
                    btnSecion.Enabled = false;
                    oUsuario = (Entidades.Seguridad.Usuario)Session["Usuario"];
                }
            }
            else
            {
                if (Session["Usuario"] != null)
                {
                    btnLinkButton1.Visible = false;
                    //ButtonCerrarSecion.Visible = true;
                    LabelSesion.Visible = true;
                    //this.EtiquetaLogin.Visible = false;
                    btnSecion.Enabled = true;
                    oUsuario = (Entidades.Seguridad.Usuario)Session["Usuario"];
                    //LabelSesion.Text = oUsuario.Nombre;
                    btnSecion.Text = oUsuario.NombreUsuario;
                }
                else
                {
                    btnLinkButton1.Visible = false;
                    //ButtonCerrarSecion.Visible = false;
                    LabelSesion.Visible = false;
                    btnSecion.Enabled = false;
                    oUsuario = (Entidades.Seguridad.Usuario)Session["Usuario"];
                    //  LabelSesion.Text = Usuario.Nombre;       
                    string Mensaje = "Complete el Nombre!";
                    string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

                }
            }
        }
        protected void btnLinkButton1_Click(object sender, EventArgs e)
        {
            oUsuario = (Entidades.Seguridad.Usuario)Session["Usuario"];
            Controladora.Seguridad.CtrlCerrarSesion.ObtenerInstancia().CerrarSesion(oUsuario.NombreUsuario);
            Session.Abandon();
            Response.Redirect("../index.html");
        }

        protected void btnSecion_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Seguridad/MDSCambiarClave.aspx");
        }

        protected void ButtonCerrarSecion_Click(object sender, EventArgs e)
        {
            oUsuario = (Entidades.Seguridad.Usuario)Session["Usuario"];
            Controladora.Seguridad.CtrlCerrarSesion.ObtenerInstancia().CerrarSesion(oUsuario.NombreUsuario);
            Session.Abandon();
            Response.Redirect("index.html");
        }
        //public string Login
        //{
        //    get { return EtiquetaLogin.InnerText; }
        //    set { EtiquetaLogin.InnerText = value; }
        //}

        List<Entidades.Seguridad.Perfil> Perfiles;
        Entidades.Seguridad.Usuario oUsuario;

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }







        //protected void LinkButton1_Click(object sender, EventArgs e)
        //{

        //}

        //protected void LinkButton1_Click1(object sender, EventArgs e)
        //{

        //}

        //protected void btnSecion_Click(object sender, EventArgs e)
        //{

        //}
    }
}
 */
