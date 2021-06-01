using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.ObjectModel;

namespace Web.Seguridad
{
    public partial class MDSGestionarPerfiles : System.Web.UI.Page
    {
        List<Entidades.Seguridad.Grupo> _Grupos;
        List<Entidades.Seguridad.Formulario> _Formularios;
        List<Entidades.Seguridad.Permiso> _Permisos;
        Int32 indiceFila;
        private Entidades.Seguridad.Usuario oUsuario;
        List<Entidades.Seguridad.Perfil> Perfiles;
        Entidades.Seguridad.Perfil Perfil;
        string Mensaje;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.btnAgregar.Visible = false;
                this.btnEliminar.Visible = false;
                this.gvPerfiles.Visible = false;
                oUsuario = (Entidades.Seguridad.Usuario)Session["Usuario"];
                CargarPermisos(Perfiles);
                CargarPerfiles();
                llenarFormularios();
                llenarGrupos();
                llenarPermisos();
            }
            else
            {
                oUsuario = (Entidades.Seguridad.Usuario)Session["Usuario"];
                Perfil = (Entidades.Seguridad.Perfil)Session["Perfil"];
                _Grupos = (List<Entidades.Seguridad.Grupo>)Session["_Grupos"];
                _Formularios = (List<Entidades.Seguridad.Formulario>)Session["_Formularios"];
                _Permisos = (List<Entidades.Seguridad.Permiso>)Session["_Permisos"];
                Perfiles = (List<Entidades.Seguridad.Perfil>)Session["Perfiles"];
            }
        }
        private void CargarPerfiles()
        {
            gvPerfiles.AutoGenerateColumns = false;
            Perfiles = Controladora.Seguridad.ControladoraGestionarPerfiles.ObtenerInstancia().ListarPerfiles().ToList();
            gvPerfiles.DataSource = Perfiles;
            gvPerfiles.DataBind();
            Session.Add("Perfiles", Perfiles); 
        }
        private void CargarPermisos(List<Entidades.Seguridad.Perfil> Perfiles)
        {
            Perfiles = Controladora.Seguridad.ControladoraIniciarSesion.ObtenerInstancia().RecuperarPerfil(oUsuario);
            foreach (Entidades.Seguridad.Perfil oPerfil in Perfiles)
            {
                if("Perfiles" == oPerfil.Formulario.Nombre)
                {
                    switch (oPerfil.Permiso.Nombre)
                    {
                        case "Agregar":
                            this.btnAgregar.Visible = true;
                            break;

                        case "Eliminar":
                            this.btnEliminar.Visible = true;
                            break;

                        case "Acceso":
                            this.gvPerfiles.Visible = true;
                            break;

                        default:
                            break;
                    }
                }
            }
        }
        public void llenarGrupos()
        {
            _Grupos = Controladora.Seguridad.ControladoraGestionarPerfiles.ObtenerInstancia().RecuperarGrupo().ToList();
            ddlGrupos.DataSource = _Grupos;
            ddlGrupos.DataMember = "Nombre";
            ddlGrupos.DataBind();
            Session.Add("_Grupos", _Grupos);
        }
        public void llenarFormularios()
        {
            _Formularios = Controladora.Seguridad.ControladoraGestionarPerfiles.ObtenerInstancia().RecuperarFormulario().ToList();
            ddlFormularios.DataSource = _Formularios;
            ddlFormularios.DataMember = "Nombre";
            ddlFormularios.DataBind();
            Session.Add("_Formularios", _Formularios);
        }
        public void llenarPermisos()
        {
            _Permisos = Controladora.Seguridad.ControladoraGestionarPerfiles.ObtenerInstancia().RecuperarPermiso().ToList();
            ddlPermisos.DataSource = _Permisos;
            ddlPermisos.DataMember = "Tipo";
            ddlPermisos.DataBind();
            Session.Add("_Permisos", _Permisos);
        }
        protected void btnAgregar_Click(object sender, EventArgs e) { }
        protected void btnModificar_Click(object sender, EventArgs e) { }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Entidades.Seguridad.Perfil oPerfil = Perfiles[gvPerfiles.SelectedIndex]; 
            if(oPerfil != null)
            {
                btnEliminar.Attributes.Add("language", "javascript");
                btnEliminar.Attributes.Add("onclick", "return confirm('¿Desea eliminar el perfil seleccionado?')");
                Controladora.Seguridad.ControladoraGestionarPerfiles.ObtenerInstancia().EliminarPerfil(oPerfil, oUsuario);
                CargarPerfiles();
            }
            else
            {
                Mensaje = "Seleccione un perfil";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
        }
        protected void Agregar_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Entidades.Seguridad.Perfil oPerfil = new Entidades.Seguridad.Perfil();
                Int32 _grupo = ddlGrupos.SelectedIndex;
                Int32 _formulario = ddlFormularios.SelectedIndex;
                Int32 _permiso = ddlPermisos.SelectedIndex;

                oPerfil.Grupo = _Grupos[_grupo];
                oPerfil.Formulario = _Formularios[_formulario];
                oPerfil.Permiso = _Permisos[_permiso];

                Controladora.Seguridad.ControladoraGestionarPerfiles.ObtenerInstancia().AgregarPerfil(oPerfil, oUsuario);
                Mensaje = "Perfil agregado!";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
        }
        protected void gvPerfiles_SelectedIndexChanged(object sender, EventArgs e) { }
        protected void gvPerfiles_PageIndexChanged(object sender, EventArgs e) { }
        protected void gvPerfiles_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPerfiles.PageIndex = e.NewPageIndex;
            gvPerfiles.DataSource = Controladora.Seguridad.ControladoraGestionarPerfiles.ObtenerInstancia().ListarPerfiles();
            gvPerfiles.DataBind();
        }
    }
}
