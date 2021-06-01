using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Seguridad
{
    public partial class MDSGestionarGrupos : System.Web.UI.Page
    {
        Entidades.Seguridad.Grupo Grupo;
        List<Entidades.Seguridad.Grupo> Grupos;
        private string Operacion;
        private Entidades.Seguridad.Usuario oUsuario;
        List<Entidades.Seguridad.Perfil> Perfiles;
        string Mensaje;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.gvGrupos.Visible = false;
                this.btnAgregar.Visible = false;
                this.btnEliminar.Visible = false;
                this.btnModificar.Visible = false;
                this.btnHabilitar.Visible = false;
                oUsuario = (Entidades.Seguridad.Usuario)Session["Usuario"];
                CargarPermisos(Perfiles);
                CargarGrilla();
            }
            else
            {
                Grupo = (Entidades.Seguridad.Grupo)Session["Grupo"];
                Grupos = (List<Entidades.Seguridad.Grupo>)Session["Grupos"];
                oUsuario = (Entidades.Seguridad.Usuario)Session["Usuarios"];
                CargarGrilla();
            }
        }
        private void CargarPermisos(List<Entidades.Seguridad.Perfil> Perfiles)
        {
            Perfiles = Controladora.Seguridad.ControladoraIniciarSesion.ObtenerInstancia().RecuperarPerfil(oUsuario);
            foreach (Entidades.Seguridad.Perfil oPerfil in Perfiles)
            {
                if ("Grupos" == oPerfil.Formulario.Nombre)
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

                        case "Acceso":
                            this.gvGrupos.Visible = true;
                            break;

                    }
                }
            }
        }
        private void CargarGrilla()
        {
            gvGrupos.AutoGenerateColumns = false;
            Grupos = Controladora.Seguridad.ControladoraGestionarGrupos.ObtenerInstancia().RecuperarGrupos().ToList();
            gvGrupos.DataSource = Grupos;
            gvGrupos.DataBind();
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Operacion = "Agregar";
            Session["OpcionGrupo"] = Operacion;
            Response.Redirect("MDSGestionarGrupo.aspx");
        }
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Entidades.Seguridad.Grupo oGrupo = (Entidades.Seguridad.Grupo)Session["Grupo"];
            if (oGrupo != null)
            {
                Operacion = "Modificar";
                Session["OpcionGrupo"] = Operacion;
                Response.Redirect("MDSGestionarGrupo.aspx");
            }
            else
            {
                Mensaje = "Seleccione un grupo";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Entidades.Seguridad.Grupo Grupo = (Entidades.Seguridad.Grupo)Session["Grupo"];
            if (Grupo != null)
            {
                btnEliminar.Attributes.Add("language", "javascript");
                btnEliminar.Attributes.Add("onclick", "return confirm('¿Desea eliminar el grupo seleccionado?')");
                bool respuesta = Controladora.Seguridad.ControladoraGestionarGrupos.ObtenerInstancia().EliminarGrupo(Grupo);
                if (respuesta)
                {
                    Mensaje = "El grupo se eliminó correctamente";
                    string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);
                    CargarGrilla();
                }
                else
                {
                    Mensaje = "El grupo " + Grupo.Nombre + " no se puede eliminar";
                    string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);
                }
            }
            else
            {
                Mensaje = "Seleccione un grupo";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
        }
        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            Entidades.Seguridad.Grupo oGrupo = (Entidades.Seguridad.Grupo)Session["Grupo"];
            if (oGrupo != null)
            {
                if (oGrupo.Estado == false)
                {
                    btnHabilitar.Attributes.Add("language", "javascript");
                    btnHabilitar.Attributes.Add("onclick", "return confirm('El grupo se encuentra habilitado, ¿Desea deshabilitarlo?')");
                    Controladora.Seguridad.ControladoraGestionarUsuarios.ObtenerInstancia().HabilitarDeshabilitar(oUsuario);
                    CargarGrilla();
                }
                else if (oGrupo.Estado == true)
                {
                    btnHabilitar.Attributes.Add("language", "javascript");
                    btnHabilitar.Attributes.Add("onclick", "return confirm('El grupo se encuentra habilitado, ¿Desea deshabilitarlo?')");
                    Controladora.Seguridad.ControladoraGestionarUsuarios.ObtenerInstancia().HabilitarDeshabilitar(oUsuario);
                    CargarGrilla();
                }
                else
                {
                    Mensaje = "Seleccione un grupo";
                    string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                }
            }
        }
        protected void gvGrupos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indiceFila = gvGrupos.SelectedIndex;
            string nombreGrupo = gvGrupos.Rows[indiceFila].Cells[1].Text;

            Entidades.Seguridad.Grupo Grupo = Controladora.Seguridad.ControladoraGestionarGrupos.ObtenerInstancia().RecuperarGrupos().First(x => x.Nombre == nombreGrupo); 
        }
    }
}
