using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Sistema
{
    public partial class ListadoCuentasCorrientes : System.Web.UI.Page
    {
        Int32 indiceFila;
        private Entidades.Seguridad.Usuario oUsuario;
        List<Entidades.Seguridad.Perfil> Perfiles;
        Entidades.Sistema.CuentaCorriente CuentaCorriente;
        private List<Entidades.Sistema.CuentaCorriente> CuentasCorrientes;
        string Mensaje;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.gvCtasCtes.Visible = false;
                this.BtnImprimir.Visible = false;
                this.BtnVerDetalle.Visible = false;

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
                CuentasCorrientes = (List<Entidades.Sistema.CuentaCorriente>)Session["CuentasCorrientes"];
                CuentaCorriente = (Entidades.Sistema.CuentaCorriente)Session["CuentaCorriente"];
                oUsuario = (Entidades.Seguridad.Usuario)Session["oUsuario"];
            }
        }
        private void CargarGrilla()
        {
            CuentasCorrientes = Controladora.Sistema.ControladoraCuentasCorrientes.ObtenerInstancia().RecuperarCuentaCorriente();
            gvCtasCtes.DataSource = CuentasCorrientes;
            gvCtasCtes.DataBind();
            Session.Add("CuentasCorrientes", CuentasCorrientes);
        }
        private void CargarPermisos(List<Entidades.Seguridad.Perfil> Perfiles)
        {
            Perfiles = Controladora.Seguridad.ControladoraIniciarSesion.ObtenerInstancia().RecuperarPerfil(oUsuario);
            int contador = 0;
            foreach (Entidades.Seguridad.Perfil oPerfil in Perfiles)
            {
                if("Cuentas Corrientes" == oPerfil.Formulario.Nombre)
                {
                    switch (oPerfil.Permiso.Nombre)
                    {
                        case "Imprimir Cta Cte":
                            this.BtnImprimir.Visible = true;
                            break;
                        case "Ver Detalle":
                            this.BtnVerDetalle.Visible = true;
                            break;
                        case "Acceso":
                            this.gvCtasCtes.Visible = true;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        protected void BtnFiltrar_Click(object sender, EventArgs e)
        {
            this.gvCtasCtes.DataSource = null; 
            if(txtFiltrar.Text == "")
            {
                this.gvCtasCtes.DataSource = Controladora.Sistema.ControladoraCuentasCorrientes.ObtenerInstancia().RecuperarCuentaCorriente();
            }
            else
            {
                this.gvCtasCtes.DataSource = Controladora.Sistema.ControladoraCuentasCorrientes.ObtenerInstancia().FiltrarCuentaCorriente(txtFiltrar.Text);
            }
            this.gvCtasCtes.DataBind();
        }
        protected void gvCtasCtes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indiceFila = gvCtasCtes.SelectedIndex;
            string razon = gvCtasCtes.Rows[indiceFila].Cells[1].Text;

            Entidades.Sistema.CuentaCorriente CuentaCorriente = Controladora.Sistema.ControladoraCuentasCorrientes.ObtenerInstancia().RecuperarCuentaCorriente().First(x => x.Cliente.RazonSocial == razon);
            Session["CuentaCorriente"] = CuentaCorriente;
        }
        protected void gvCtasCtes_PageIndexChanging(object sender, GridViewPageEventArgs e) { }
        protected void BtnVerDetalle_Click(object sender, EventArgs e)
        {
            Entidades.Sistema.CuentaCorriente CuentaCorriente = (Entidades.Sistema.CuentaCorriente)Session["CuentaCorriente"];
            if(CuentaCorriente != null)
            {
                int nro = this.gvCtasCtes.SelectedIndex;
                Entidades.Sistema.CuentaCorriente ctacte = Controladora.Sistema.ControladoraCuentasCorrientes.ObtenerInstancia().RecuperarCuentaCorriente()[nro];
                Session.Add("CuentaCorriente", ctacte);
                Response.Redirect("DetalleCtaCte.aspx");
            }
            else
            {
                Mensaje = "Seleccione una Cuenta Corriente!";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
        }
        protected void BtnImprimir_Click(object sender, EventArgs e)
        {
            Entidades.Sistema.CuentaCorriente CuentaCorriente = (Entidades.Sistema.CuentaCorriente)Session["CuentaCorriente"]; 
            if(CuentaCorriente != null)
            {
                int nro = this.gvCtasCtes.SelectedIndex;
                Entidades.Sistema.CuentaCorriente ctacte = Controladora.Sistema.ControladoraCuentasCorrientes.ObtenerInstancia().RecuperarCuentaCorriente()[nro];
                Session.Add("CuentaCorriente", ctacte);
                Response.Redirect("/Sistema/Reportes/ReportCtaCte.aspx");
            }
            else
            {
                Mensaje = "Seleccione una Cuenta Corriente!";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
        }
    }
}

