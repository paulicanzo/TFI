using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Sistema
{
    public partial class GestionarCategoriasProductos : System.Web.UI.Page
    {
        List<Entidades.Sistema.CategoriaProducto> _Categorias;
        private Entidades.Seguridad.Usuario oUsuario;
        List<Entidades.Seguridad.Perfil> Perfiles;
        string Mensaje;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.gvCategoria.Visible = false;
                this.btnAgregar.Visible = false;
                this.btnEliminar.Visible = false;
                oUsuario = (Entidades.Seguridad.Usuario)Session["Usuario"];
                if(oUsuario == null)
                {
                    Response.Redirect("DefaultBackEnd.aspx");
                }
                else
                {
                    CargarPermisos(Perfiles);
                    CargarGrilla();
                }
            }
            else
            {
                _Categorias = (List<Entidades.Sistema.CategoriaProducto>)Session["_Categorias"];
                oUsuario = (Entidades.Seguridad.Usuario)Session["Usuarios"];
                CargarGrilla();
            }
        }
        private void CargarPermisos(List<Entidades.Seguridad.Perfil> Perfiles)
        {
            Perfiles = Controladora.Seguridad.ControladoraIniciarSesion.ObtenerInstancia().RecuperarPerfil(oUsuario);
            foreach (Entidades.Seguridad.Perfil oPerfil in Perfiles)
            {
                if("Categorias" == oPerfil.Formulario.Nombre)
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
                            this.gvCategoria.Visible = true;
                            break;
                    }
                }
            }
        }
        private void CargarGrilla()
        {
            gvCategoria.AutoGenerateColumns = false;
            _Categorias = Controladora.Sistema.ControladoraGestionarCategoriaProductos.ObtenerInstancia().RecuperarCategoriaProducto().ToList();
            gvCategoria.DataSource = _Categorias;
            gvCategoria.DataBind();
        }
        protected void gvCat_SelectedIndexChanged(object sender, EventArgs e) { }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Entidades.Sistema.CategoriaProducto oCategoria = _Categorias[gvCategoria.SelectedIndex]; 
            if(oCategoria != null)
            {
                btnEliminar.Attributes.Add("language", "javascript"); 
                btnEliminar.Attributes.Add("onclick", "return confirm('¿Desea eliminar la categoria seleccionada?')");
                Controladora.Sistema.ControladoraGestionarCategoriaProductos.ObtenerInstancia().EliminarCategoriaProducto(oCategoria);
                CargarGrilla();
            }
            else
            {
                Mensaje = "Por favor, seleccione una categoria";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionarCategoriaProductos.aspx");
        }
    }
}
