using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Sistema
{
    public partial class GestionarClientes : System.Web.UI.Page
    {
        private string Operacion;
        Int32 indiceFila;
        private Entidades.Seguridad.Usuario oUsuario;
        List<Entidades.Seguridad.Perfil> Perfiles;
        Entidades.Sistema.Cliente Cliente;
        private List<Entidades.Sistema.Cliente> Clientes;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.gvClientes.Visible = false;
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
                Clientes = (List<Entidades.Sistema.Cliente>)Session["Clientes"];
                Cliente = (Entidades.Sistema.Cliente)Session["Cliente"];
                oUsuario = (Entidades.Seguridad.Usuario)Session["oUsuario"];
            }
        }
        private void CargarGrilla()
        {
            Clientes = Controladora.Sistema.ControladoraGestionarClientes.ObtenerInstancia().RecuperarClientes();
            gvClientes.DataSource = Clientes;
            gvClientes.DataBind();
            Session.Add("Clientes", Clientes);
        }
        private void CargarPermisos(List<Entidades.Seguridad.Perfil> Perfiles)
        {
            Perfiles = Controladora.Seguridad.ControladoraIniciarSesion.ObtenerInstancia().RecuperarPerfil(oUsuario);
            int contador = 0;
            foreach (Entidades.Seguridad.Perfil oPerfil in Perfiles)
            {
                if("Clientes" == oPerfil.Formulario.Nombre)
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
                            this.gvClientes.Visible = true;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        protected void BtnFiltrar_Click(object sender, EventArgs e)
        {
            this.gvClientes.DataSource = null; 
            if(txtFiltrar.Text == "")
            {
                this.gvClientes.DataSource = Controladora.Sistema.ControladoraGestionarClientes.ObtenerInstancia().RecuperarClientes();
            }
            else
            {
                this.gvClientes.DataSource = Controladora.Sistema.ControladoraGestionarClientes.ObtenerInstancia().FiltrarClientes(txtFiltrar.Text);
            }
            this.gvClientes.DataBind();
        }
        protected void gvProveedores_SelectedIndexChanged(object sender, EventArgs e) { }
        protected void gvProveedores_PageIndexChanging(object sender, GridViewPageEventArgs e) { }
        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            Operacion = "Agregar";
            Session["OpcionCliente"] = Operacion;
            Response.Redirect("GestionarCliente.aspx");
        }
        protected void BtnModificar_Click(object sender, EventArgs e)
        {
            Operacion = "Modificar";
            Session["OpcionCliente"] = Operacion;
            int nro = this.gvClientes.SelectedIndex;
            Entidades.Sistema.Cliente cliente = Clientes[nro];
            Session.Add("Cliente", cliente);
            Response.Redirect("GestionarCliente.aspx"); 
        }
        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            Entidades.Sistema.Cliente oCliente = (Entidades.Sistema.Cliente)Session["Cliente"]; 
            if(oCliente.Estado == false)
            {
                BtnEliminar.Attributes.Add("language", "javascript");
                BtnEliminar.Attributes.Add("onclick", "return confirm('El cliente se encuentra inhabilitado, ¿Desea habilitarlo?')");
                Controladora.Sistema.ControladoraGestionarClientes.ObtenerInstancia().CambiarEstado(oCliente);
                Response.Redirect("GestionarClientes.aspx");
            }
            else if (oCliente.Estado == true)
            {
                BtnEliminar.Attributes.Add("language", "javascript"); 
                BtnEliminar.Attributes.Add("onclick", "return confirm('El cliente se encuentra habilitado, ¿Desea inhabilitarlo?')");
                Controladora.Sistema.ControladoraGestionarClientes.ObtenerInstancia().CambiarEstado(oCliente);
                Response.Redirect("GestionarClientes.aspx");
            }
        }
        protected void BtnConsultar_Click(object sender, EventArgs e)
        {
            Operacion = "Consultar";
            Session["OpcionCliente"] = Operacion;
            int nro = this.gvClientes.SelectedIndex;
            Entidades.Sistema.Cliente Cliente = Clientes[nro];
            Session["Cliente"] = Cliente;
            Response.Redirect("GestionarClientes.aspx");
        }
        protected void gvClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indiceFila = gvClientes.SelectedIndex;
            string Razon = gvClientes.Rows[indiceFila].Cells[1].Text;

            Entidades.Sistema.Cliente Cliente = Controladora.Sistema.ControladoraGestionarClientes.ObtenerInstancia().RecuperarClientes().First(x => x.RazonSocial == Razon);
            Session["Cliente"] = Cliente;
        }
        protected void gvClientes_PageIndexChanging(object sender, GridViewPageEventArgs e) { }
    }
}

