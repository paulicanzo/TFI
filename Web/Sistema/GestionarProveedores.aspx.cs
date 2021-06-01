using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Sistema
{
    public partial class GestionarProveedores : System.Web.UI.Page
    {
        string Operacion;
        Int32 indiceFila;
        private Entidades.Seguridad.Usuario oUsuario;
        List<Entidades.Seguridad.Perfil> Perfiles;
        Entidades.Sistema.Proveedor Proveedor;
        private List<Entidades.Sistema.Proveedor> Proveedores;
       
        protected void Page_init(object sender, EventArgs e)
        {
            Proveedores = ((List<Entidades.Sistema.Proveedor>)Controladora.Sistema.ControladoraGestionarProveedores.ObtenerInstancia().RecuperarProveedores());
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.gvProveedores.Visible = false;
                this.BtnAgregar.Visible = false;
                this.BtnEliminar.Visible = false;
                this.BtnConsultar.Visible = false;
                this.BtnModificar.Visible = false;

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
                Proveedores = (List<Entidades.Sistema.Proveedor>)Session["Proveedores"];
                Proveedor = (Entidades.Sistema.Proveedor)Session["Proveedor"];
                oUsuario = (Entidades.Seguridad.Usuario)Session["oUsuario"];
            }
        }
        private void CargarGrilla()
        {
            Proveedores = Controladora.Sistema.ControladoraGestionarProveedores.ObtenerInstancia().RecuperarProveedores();
            gvProveedores.DataSource = Proveedores;
            gvProveedores.DataBind();
            Session.Add("Proveedores", Proveedores); 
        }
        private void CargarPermisos(List<Entidades.Seguridad.Perfil> Perfiles)
        {
            Perfiles = Controladora.Seguridad.ControladoraIniciarSesion.ObtenerInstancia().RecuperarPerfil(oUsuario);
            int contador = 0;
            foreach (Entidades.Seguridad.Perfil oPerfil in Perfiles)
            {
                if("Proveedores" == oPerfil.Formulario.Nombre)
                {
                    switch (oPerfil.Permiso.Nombre)
                    {
                        case "Agregar":
                            this.BtnAgregar.Visible = true;
                            break;
                        case "Hab/Des":
                            this.BtnEliminar.Visible = true;
                            break;
                        case "Modificar":
                            this.BtnModificar.Visible = true;
                            break;
                        case "Consultar":
                            this.BtnConsultar.Visible = true;
                            break;
                        case "Acceso":
                            this.gvProveedores.Visible = true;
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
                Response.Redirect("~/FrmPrincipalSistema.aspx");
            }
        }
        protected void Agregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionarProveedor.aspx");
        }
        protected void Modificar_Click(object sender, EventArgs e) { }
        protected void GridViewProveedores_SelectedIndexChanged(object sender, EventArgs e) { }
        protected void gvProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indiceFila = gvProveedores.SelectedIndex;
            string nombreProveedor = gvProveedores.Rows[indiceFila].Cells[1].Text;

            Entidades.Sistema.Proveedor Proveedor = Controladora.Sistema.ControladoraGestionarProveedores.ObtenerInstancia().RecuperarProveedores().First(x => x.DenominacionLegal == nombreProveedor);
            Session["Proveedor"] = Proveedor;
        }
        protected void gvProveedores_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProveedores.PageIndex = e.NewPageIndex;
            gvProveedores.DataSource = Controladora.Sistema.ControladoraGestionarProveedores.ObtenerInstancia().RecuperarProveedores();
            gvProveedores.DataBind();
        }
        protected void BtnModificar_Click(object sender, EventArgs e)
        {
            Operacion = "Modificar";
            Session["OpcionProveedor"] = Operacion;
            int nro = this.gvProveedores.SelectedIndex;
            Entidades.Sistema.Proveedor oProveedor = Proveedores[nro];
            Session.Add("Proveedor", oProveedor);
            Response.Redirect("GestionarProveedor.aspx"); 
        }
        protected void BtnAgregar_Click(object sender, EventArgs e) { }
        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            Entidades.Sistema.Proveedor oProveedor = (Entidades.Sistema.Proveedor)Session["Proveedor"];
            if(oProveedor.Estado == false)
            {
                BtnEliminar.Attributes.Add("language", "javascript");
                BtnEliminar.Attributes.Add("onclick", "return confirm('El Proveedor se encuentra deshabilitado ¿Desea habilitarlo?')");
                Controladora.Sistema.ControladoraGestionarProveedores.ObtenerInstancia().CambiarEstado(oProveedor);
                Response.Redirect("GestionarProveedores.aspx");
            }
            else if(oProveedor.Estado == true)
            {
                BtnEliminar.Attributes.Add("language", "javascript");
                BtnEliminar.Attributes.Add("onclick", "return confirm('El Proveedor se encuentra Habilitado ¿Desea Deshabilitarlo?')");
                Controladora.Sistema.ControladoraGestionarProveedores.ObtenerInstancia().CambiarEstado(oProveedor);
                Response.Redirect("GestionarProveedores.aspx");
            }
        }
        protected void BtnConsultar_Click(object sender, EventArgs e)
        {
            Operacion = "Consultar";
            Session["OpcionProveedor"] = Operacion;
            int nro = this.gvProveedores.SelectedIndex;
            Entidades.Sistema.Proveedor oProveedor = Proveedores[nro];
            Session["Proveedor"] = oProveedor;
            Response.Redirect("GestionarProveedor.aspx");
        }
        protected void BtnAgregar_Click1(object sender, EventArgs e)
        {
            Operacion = "Agregar";
            Session["OpcionProveedor"] = Operacion;
            Response.Redirect("GestionarProveedor.aspx");
        }
        protected void BtnFiltrar_Click(object sender, EventArgs e)
        {
            this.gvProveedores.DataSource = null; 
            if(txtFiltrar.Text == "")
            {
                this.gvProveedores.DataSource = Controladora.Sistema.ControladoraGestionarProveedores.ObtenerInstancia().RecuperarProveedores();
            }
            else
            {
                this.gvProveedores.DataSource = Controladora.Sistema.ControladoraGestionarProveedores.ObtenerInstancia().FiltrarProveedores(txtFiltrar.Text);
            }
            this.gvProveedores.DataBind();
        }
    }
}

