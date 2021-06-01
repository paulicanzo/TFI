using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Seguridad
{
    public partial class WebFormLogin : System.Web.UI.Page
    {
        Entidades.Seguridad.Usuario Usuario;
        string Mensaje;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Session.Add("Usuario", Usuario);
            }
            else
            {
                Usuario = (Entidades.Seguridad.Usuario)Session["Usuario"];
            }
        }
        private void Aceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                object objeto = Controladora.Seguridad.ControladoraIniciarSesion.ObtenerInstancia().IniciarSesion(this.txtUsuario.Text, this.txtContraseña.Text);
                if (objeto is Entidades.Seguridad.Usuario)
                {
                    Entidades.Seguridad.Usuario oUsuario = (Entidades.Seguridad.Usuario)objeto;
                    Session.Add("Usuario", oUsuario);
                    Response.Redirect("/Sistema/EmpleadoBackEnd.aspx");
                }
                if(objeto is string)
                {
                    Mensaje = "No se puede ingresar";
                    string script = @"<script type='text/javascript'>alert('" + Mensaje + "');window.location='WebFormLogin.aspx';</script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                }
            }
        }
        private bool Validar()
        {
            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                Mensaje = "Complete el usuario";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');window.location='WebFormLogin.aspx';</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return false;
            }
            if (string.IsNullOrEmpty(txtContraseña.Text))
            {
                Mensaje = "Complete la contraseña";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');window.location='WebFormLogin.aspx';</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return false;
            }
            return true;
        }
        protected void Cancelar_Click(object sender, EventArgs e) { }
        protected void btnOlvideMi_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Seguridad/MDSOlvideMiContraseña.aspx");
        }
        protected void Aceptar_Click1(object sender, EventArgs e)
        {
            if (Validar())
            {
                object objeto = Controladora.Seguridad.ControladoraIniciarSesion.ObtenerInstancia().IniciarSesion(this.txtUsuario.Text, this.txtContraseña.Text);
                if (objeto is Entidades.Seguridad.Usuario)
                {
                    Entidades.Seguridad.Usuario oUsuario = (Entidades.Seguridad.Usuario)objeto;
                    Session.Add("Usuario", oUsuario);
                    Response.Redirect("/Sistema/EmpleadoBackEnd.aspx");
                }
                if (objeto is string)
                {
                    Mensaje = "No se puede Ingresar!";
                    string script = @"<script type='text/javascript'>alert('" + Mensaje + "');window.location='WebFormLogin.aspx';</script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                }
            }
        }
        protected void Olvi_Click(object sender, EventArgs e)
        {
            Response.Redirect("MDSOlvideMiContraseña.aspx");
        }
    }
}

