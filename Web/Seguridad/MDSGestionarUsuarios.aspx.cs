using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Seguridad
{
    public partial class MDSGestionarUsuarios : System.Web.UI.Page
    {
        private int indiceFila;
        private string Operacion;
        private Entidades.Seguridad.Usuario oUsuario;
        private Entidades.Seguridad.Usuario GestionarUsuario;
        List<Entidades.Seguridad.Perfil> Perfiles;
        string Mensaje;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.btnAgregar.Visible = false;
                this.btnModificar.Visible = false;
                this.btnEliminar.Visible = false;
                this.btnHabilitar.Visible = false;
                this.gvUsuarios.Visible = false;
                oUsuario = (Entidades.Seguridad.Usuario)Session["Usuario"];
                GestionarUsuario = (Entidades.Seguridad.Usuario)Session["GestionarUsuario"];
                CargarPermisos(Perfiles);
                CargarUsuarios();
            }
        }
        private void CargarUsuarios()
        {
            gvUsuarios.AutoGenerateColumns = false;
            gvUsuarios.DataSource = Controladora.Seguridad.ControladoraGestionarUsuarios.ObtenerInstancia().RecuperarUsuario();
            gvUsuarios.DataBind();
        }
        private void CargarPermisos(List<Entidades.Seguridad.Perfil> Perfiles)
        {
            Perfiles = Controladora.Seguridad.ControladoraIniciarSesion.ObtenerInstancia().RecuperarPerfil(oUsuario);
            foreach (Entidades.Seguridad.Perfil oPerfil in Perfiles)
            {
                if("Usuarios" == oPerfil.Formulario.Nombre)
                {
                    switch (oPerfil.Permiso.Nombre)
                    {
                        case "Agregar":
                            this.btnAgregar.Visible = true;
                            break;

                        case "Eliminar":
                            this.btnEliminar.Visible = true;
                            break;

                        case "Modificar":
                            this.btnModificar.Visible = true;
                            break;

                        case "Hab/Des":
                            this.btnHabilitar.Visible = true;
                            break;

                        case "Resetear":
                            this.btnResetear.Visible = true;
                            break;

                        case "Acceso":
                            this.gvUsuarios.Visible = true;
                            break; 


                        default:
                            break;
                    }
                }
            }
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Operacion = "Agregar";
            Session["OpcionUsuario"] = Operacion;
            Response.Redirect("MDSGestionarUsuario.aspx");
        }
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Entidades.Seguridad.Usuario GestionarUsuario = (Entidades.Seguridad.Usuario)Session["GestionarUsuario"]; 
            if(GestionarUsuario != null)
            {
                Operacion = "Modificar";
                Session["OpcionUsuario"] = Operacion;
                int nro = this.gvUsuarios.SelectedIndex;
                Entidades.Seguridad.Usuario usu = Controladora.Seguridad.ControladoraGestionarUsuarios.ObtenerInstancia().RecuperarUsuario()[nro];
                Session.Add("GestionarUsuario", usu);
                Response.Redirect("MDSGestionarUsuario.aspx");
            }
            else
            {
                Mensaje = "Seleccione un usuario";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Entidades.Seguridad.Usuario GestionarUsuario = (Entidades.Seguridad.Usuario)Session["GestionarUsuario"]; 
            if(GestionarUsuario != null)
            {
                btnHabilitar.Attributes.Add("language", "javascript"); 
                btnHabilitar.Attributes.Add("onclick", "return confirm('¿Desea eliminar el usuario seleccionado?')");
                Controladora.Seguridad.ControladoraGestionarUsuarios.ObtenerInstancia().EliminarUsuario(oUsuario);
                CargarUsuarios();
            }
            else
            {
                Mensaje = "Seleccione un usuario";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
        }
        //protected void btnConsultar_Click(object sender, EventArgs e)
        //{
        //    Operacion = "Consultar";
        //    Session["OpcionUsuario"] = Operacion;
        //    int nro = this.gvUsuarios.SelectedIndex;
        //    Entidades.Seguridad.Usuario usu = Controladora.Seguridad.ControladoraGestionarUsuarios.ObtenerInstancia().RecuperarUsuario()[nro];
        //    Session.Add("GestionarUsuario", usu);
        //    Response.Redirect("MDSGestionarUsuario.aspx");
        //}
        protected void btnHabilitar_Click(object sender, EventArgs e)
        {
            Entidades.Seguridad.Usuario GestionarUsuario = (Entidades.Seguridad.Usuario)Session["GestionarUsuario"];
            if(GestionarUsuario != null)
            {
                if(GestionarUsuario.Estado == false)
                {
                    btnHabilitar.Attributes.Add("language", "javascript");
                    btnHabilitar.Attributes.Add("onclick", "return confirm('El usuario se encuentra habilitado, ¿Desea deshabilitarlo?')");
                    Controladora.Seguridad.ControladoraGestionarUsuarios.ObtenerInstancia().HabilitarDeshabilitar(oUsuario);
                    CargarUsuarios();
                }
                else if(GestionarUsuario.Estado == true)
                {
                    btnHabilitar.Attributes.Add("language", "javascript");
                    btnHabilitar.Attributes.Add("onclick", "return confirm('El usuario se encuentra inhabilitado, ¿Desea habilitarlo?)");
                    Controladora.Seguridad.ControladoraGestionarUsuarios.ObtenerInstancia().HabilitarDeshabilitar(oUsuario);
                }
            }
            else
            {
                Mensaje = "Seleccione un usuario";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
        }
        protected void Button1_Click(object sender, EventArgs e) { }
        protected void btnResetear_Click(object sender, EventArgs e)
        {
            Entidades.Seguridad.Usuario GestionarUsuario = (Entidades.Seguridad.Usuario)Session["GestionarUsuario"];
            if(GestionarUsuario == null)
            {
                Mensaje = "Seleccione un usuario";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
            else
            {
                bool respuesta = Controladora.Seguridad.ControladoraGestionarUsuarios.ObtenerInstancia().ResetearClave(GestionarUsuario); 
                if(respuesta == true)
                {
                    Mensaje = "La clave del usuario " + GestionarUsuario.NombreUsuario + " ha sido reseteada correctamente";
                    string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                }
                else
                {
                    Mensaje = "No ha podido resetear la clave";
                    string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                }
            }
        }
        protected void gvUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e) { }
        protected void gvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indiceFila = gvUsuarios.SelectedIndex;
            string idUsuario = gvUsuarios.Rows[indiceFila].Cells[1].Text;
            string NAUsuario = gvUsuarios.Rows[indiceFila].Cells[2].Text;
            Entidades.Seguridad.Usuario GestionarUsuario = Controladora.Seguridad.ControladoraGestionarUsuarios.ObtenerInstancia().RecuperarUsuario().First(x => x.NombreUsuario == NAUsuario);
            Session["GestionarUsuario"] = GestionarUsuario; 
        }
        protected void IBFiltrar_Click(object sender, EventArgs e) { }
        protected void ButtonFiltrar_Click(object sender, EventArgs e) { }
        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            gvUsuarios.AutoGenerateColumns = false;
            gvUsuarios.DataSource = Controladora.Seguridad.ControladoraGestionarUsuarios.ObtenerInstancia().FiltrarUsuarios(txtFiltrar.Text);
            gvUsuarios.DataBind();
        }
        protected void ButtonCancelar_Click(object sender, EventArgs e)
        {
            this.txtFiltrar.Text = "";
            gvUsuarios.DataSource = null;
            gvUsuarios.DataSource = Controladora.Seguridad.ControladoraGestionarUsuarios.ObtenerInstancia().RecuperarUsuario();
            gvUsuarios.DataBind();
        }
    }
}

