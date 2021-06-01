using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.ObjectModel;

namespace Web.Sistema
{
    public partial class GestionarProductos : System.Web.UI.Page
    {
        private string Operacion;
        private Entidades.Seguridad.Usuario oUsuario;
        List<Entidades.Seguridad.Perfil> Perfiles;
        private List<Entidades.Sistema.Producto> Productos;
        private Entidades.Sistema.Producto Producto;
        string Mensaje;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.GridProducto.Visible = false;
                this.BtnAgregar.Visible = false;
                this.BtnModificar.Visible = false;
                this.BtnHabilitar.Visible = false;
                this.BtnConsultar.Visible = false;

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
                oUsuario = (Entidades.Seguridad.Usuario)Session["Usuario"];
                Producto = (Entidades.Sistema.Producto)Session["Producto"];
                Productos = (List<Entidades.Sistema.Producto>)Session["Productos"];
                oUsuario = (Entidades.Seguridad.Usuario)Session["oUsuario"];
            }
        }
        private void CargarPermisos(List<Entidades.Seguridad.Perfil> Perfiles)
        {
            Perfiles = Controladora.Seguridad.ControladoraIniciarSesion.ObtenerInstancia().RecuperarPerfil(oUsuario);
            int contador = 0;
            foreach (Entidades.Seguridad.Perfil oPerfil in Perfiles)
            {
                if("Productos" == oPerfil.Formulario.Nombre)
                {
                    switch (oPerfil.Permiso.Nombre)
                    {
                        case "Agregar":
                            this.BtnAgregar.Visible = true;
                            break;
                        case "Hab/Des":
                            this.BtnHabilitar.Visible = true;
                            break;
                        case "Modificar":
                            this.BtnModificar.Visible = true;
                            break;
                        case "Consultar":
                            this.BtnConsultar.Visible = true;
                            break;
                        case "Acceso":
                            this.GridProducto.Visible = true;
                            break;

                        default:
                            break;
                    }
                    contador = contador + 1;
                }
            }
            if(contador == 0)
            {
                string Mensaje = "No tiene permisos para acceder a la sección.";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('" + Mensaje + "');", true);
            }
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e) { }
        private void CargarGrilla()
        {
            Productos = Controladora.Sistema.ControladoraGestionarProductos.ObtenerInstancia().RecuperarProducto();
            GridProducto.DataSource = Productos;
            GridProducto.DataBind();
            Session.Add("Productos", Productos);
        }
        protected void ButtonAgregar_Click(object sender, EventArgs e) { }
        protected void ButtonModificar_Click(object sender, EventArgs e) { }
        protected void BtnConsultar_Click(object sender, EventArgs e)
        {
            Entidades.Sistema.Producto oProducto = (Entidades.Sistema.Producto)Session["Producto"]; 
            if(oProducto == null)
            {
                Mensaje = "Por favor, seleccione un producto!";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
            else
            {
                Operacion = "Consultar";
                Session["OpcionProductos"] = Operacion;
                Response.Redirect("GestionarProducto.aspx");
            }
        }
        protected void BtnEliminar_Click(object sender, EventArgs e) { }
        protected void BtnModificar_Click(object sender, EventArgs e)
        {
            Entidades.Sistema.Producto oProducto = (Entidades.Sistema.Producto)Session["Producto"];
            if(oProducto == null)
            {
                Mensaje = "Por favor, seleccione el producto a modificar";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
            else
            {
                Operacion = "Modificar";
                Session["OpcionProductos"] = Operacion;
                Response.Redirect("GestionarProducto.aspx");
            }
        }
        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            Operacion = "Agregar";
            Session["OpcionProductos"] = Operacion;
            Response.Redirect("GestionarProducto.aspx");
        }
        protected void gvProductos_SelectedIndexChanged(object sender, EventArgs e) { }
        protected void gvProductos_RowDataBound(object sender, GridViewRowEventArgs e) { }
        protected void BtnFiltrar_Click(object sender, EventArgs e)
        {
            GridProducto.AutoGenerateColumns = false;
            GridProducto.DataSource = Controladora.Sistema.ControladoraGestionarProductos.ObtenerInstancia().FiltrarProductos(txtFiltrar.Text);
            GridProducto.DataBind();
        }
        protected void gvProductos_SelectedIndexChanged1(object sender, EventArgs e) { }
        protected void BtnHabilitar_Click(object sender, EventArgs e)
        {
            Entidades.Sistema.Producto oProducto = (Entidades.Sistema.Producto)Session["Producto"]; 
            if(oProducto.Estado == false)
            {
                BtnHabilitar.Attributes.Add("language", "javascript");
                BtnHabilitar.Attributes.Add("onclick", "return confirm('El producto se encuentra deshabilitado, ¿desea habilitarlo?')");
                Controladora.Sistema.ControladoraGestionarProductos.ObtenerInstancia().CambiarEstado(oProducto);
                Response.Redirect("GestionarProductos.aspx");
            }
            else if(oProducto.Estado == true)
            {
                BtnHabilitar.Attributes.Add("language", "javascript");
                BtnHabilitar.Attributes.Add("onclick", "return confirm('El producto se encuentra habilitado, ¿desea deshabilitarlo?')");
                Controladora.Sistema.ControladoraGestionarProductos.ObtenerInstancia().CambiarEstado(oProducto);
                Response.Redirect("GestionarProductos.aspx");
            }
        }
        protected void gvProd_SelectedIndexChanged(object sender, EventArgs e) { }
        protected void gvProd_PageIndexChanging(object sender, GridViewPageEventArgs e) { }
        protected void gvProductos_PageIndexChanging(object sender, GridViewPageEventArgs e) { }
        protected void gvProductos_SelectedIndexChanged2(object sender, EventArgs e) { }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e) { }
        protected void GridProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indiceFila = GridProducto.SelectedIndex;
            string nombreProducto = GridProducto.Rows[indiceFila].Cells[1].Text;

            Entidades.Sistema.Producto Producto = Controladora.Sistema.ControladoraGestionarProductos.ObtenerInstancia().RecuperarProducto().First(x => x.Nombre == nombreProducto);
            Session["Producto"] = Producto; 
        }
    }
}
