using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades.Seguridad;

namespace Web.Seguridad
{
    public partial class WebModuloSeguridad : System.Web.UI.Page
    {
        private Entidades.Seguridad.Usuario oUsuario;
        List<Entidades.Seguridad.Perfil> Perfiles; 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.btnGrupos.Visible = false;
                this.btnPerfiles.Visible = false;
                this.btnUsu.Visible = false;
                oUsuario = (Entidades.Seguridad.Usuario)Session["Usuario"];
                if(oUsuario == null)
                {
                    Response.Redirect("/Sistema/DefaultBackEnd.aspx");
                }
                else
                {
                    CargarPermisos(Perfiles);
                }
            }
            else
            {
                oUsuario = (Entidades.Seguridad.Usuario)Session["Usuario"];
            }
        }
        private void CargarPermisos(List<Entidades.Seguridad.Perfil> Perfiles)
        {
            Perfiles = Controladora.Seguridad.ControladoraIniciarSesion.ObtenerInstancia().RecuperarPerfil(oUsuario);
            foreach (Entidades.Seguridad.Perfil oPerfil in Perfiles)
            {
                if("Seguridad" == oPerfil.Formulario.Nombre)
                {
                    switch (oPerfil.Permiso.Nombre)
                    {
                        case "Usuario":
                            this.btnUsu.Visible = true;
                            break;

                        case "Grupo":
                            this.btnGrupos.Visible = true;
                            break;

                        case "Perfiles":
                            this.btnPerfiles.Visible = true;
                            break; 

                        default:
                            break;
                    }
                }
            }
        }
        protected void ButtonCliente_Click(object sender, EventArgs e) { }
        protected void ButtonGrupos_Click(object sender, EventArgs e)
        {
            Response.Redirect("MDSGestionarGrupos.aspx");
        }
        protected void ButtonPerfiles_Click(object sender, EventArgs e)

        {
            Response.Redirect("MDSGestionarPerfiles.aspx");
        }
        protected void btnUsu_Click(object sender, EventArgs e)
        {
            Response.Redirect("MDSGestionarUsuarios.aspx");
        }
    }
}

