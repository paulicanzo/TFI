using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Sistema
{
    public partial class RegistrarPago : System.Web.UI.Page
    {
        List<Entidades.Sistema.Cliente> Clientes;
        Entidades.Sistema.Cliente Cliente;
        List<Entidades.Sistema.CuentaCorriente> CuentasCorrientes;
        List<Entidades.Sistema.OrdenCompra> OrdenesCompras;
        Entidades.Sistema.OrdenCompra OrdenCompra;
        Entidades.Sistema.CondicionesPago CondicionPago;
        List<Entidades.Sistema.CondicionesPago> CondicionesPago;
        Entidades.Sistema.CuentaCorriente CuentaCorriente;
        Entidades.Seguridad.Usuario oUsuario;
        string Mensaje;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.txtFecha.Text = DateTime.Now.ToShortDateString();
            if (!Page.IsPostBack)
            {
                CargarCtaCte();
                CargarForma();
                CargarOc();
                CondicionPago = (Entidades.Sistema.CondicionesPago)Session["CondicionPago"];
                CondicionesPago = (List<Entidades.Sistema.CondicionesPago>)Session["CondicionesPago"];
                Cliente = (Entidades.Sistema.Cliente)Session["Cliente"];
                OrdenCompra = (Entidades.Sistema.OrdenCompra)Session["OrdenCompra"];
                OrdenesCompras = (List<Entidades.Sistema.OrdenCompra>)Session["OrdenesCompras"];
                CuentaCorriente = (Entidades.Sistema.CuentaCorriente)Session["CuentaCorriente"];
                CuentasCorrientes = (List<Entidades.Sistema.CuentaCorriente>)Session["CuentasCorrientes"];
                oUsuario = (Entidades.Seguridad.Usuario)Session["Usuario"];

                if(oUsuario == null)
                {
                    Response.Redirect("DefaultBackEnd.aspx");
                }
            }
            else
            {
                CargarCtaCte();
                CondicionPago = (Entidades.Sistema.CondicionesPago)Session["CondicionPago"];
                CondicionesPago = (List<Entidades.Sistema.CondicionesPago>)Session["CondicionesPago"];
                OrdenCompra = (Entidades.Sistema.OrdenCompra)Session["OrdenCompra"];
                OrdenesCompras = (List<Entidades.Sistema.OrdenCompra>)Session["OrdenesCompras"];
                CuentaCorriente = (Entidades.Sistema.CuentaCorriente)Session["CuentaCorriente"];
                CuentasCorrientes = (List<Entidades.Sistema.CuentaCorriente>)Session["CuentasCorrientes"];
                Cliente = (Entidades.Sistema.Cliente)Session["Cliente"];
                Clientes = (List<Entidades.Sistema.Cliente>)Session["Clientes"];
                oUsuario = (Entidades.Seguridad.Usuario)Session["Usuario"];
            }
        }
        protected void Registrar_Clink(object sender, EventArgs e)
        {
            if (Validar())
            {
                Entidades.Sistema.Movimiento Movimiento = new Entidades.Sistema.Movimiento();

                Movimiento.Tipo = Entidades.Sistema.Movimiento.MovimientoTipo.Ingreso;
                Movimiento.Monto = Convert.ToInt32(txtMonto.Text);
                Movimiento.Fecha = Convert.ToDateTime(txtFecha.Text.ToString());
                Movimiento.ComprobanteAbonado = OrdenCompra.NroOrdenCompra;
                Movimiento.Concepto = txtConcepto.Text;
                Movimiento.FormaPago = CondicionPago;
                CuentaCorriente = (Entidades.Sistema.CuentaCorriente)Session["CuentaCorriente"];
                CuentaCorriente.AgregarMovimiento(Movimiento);
                Controladora.Sistema.ControladoraCuentasCorrientes.ObtenerInstancia().ModificarCuentaCorriente(CuentaCorriente);
                Mensaje = "Pago registrado";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
            Limpiar();
        }
        private void Limpiar()
        {
            this.txtFecha.Text = DateTime.Now.ToShortDateString();
            txtConcepto.Text = "";
            txtMonto.Text = ""; ;
            txtConcepto.Text = "";
            CargarForma();
            CargarOc();
            CargarCtaCte();
        }
        private void CargarForma()
        {
            CondicionesPago = Controladora.Sistema.ControladoraGestionarCondicionesPago.ObtenerInstancia().RecuperarCondicionesPago();
            ddlFormadePago.DataSource = CondicionesPago;
            ddlFormadePago.DataMember = "Nombre";
            ddlFormadePago.DataBind();
            Session.Add("CondicionesPago", CondicionesPago);
        }
        private void CargarCtaCte()
        {
            CuentasCorrientes = Controladora.Sistema.ControladoraRegistrarPago.ObtenerInstancia().RecuperarCuentaCorriente();
            ddlClientes.DataSource = CuentasCorrientes;
            ddlClientes.DataMember = "Cliente";
            ddlClientes.DataBind();
            Session.Add("CuentasCorrientes", CuentasCorrientes);
        }
        private void CargarOc()
        {
            OrdenesCompras = Controladora.Sistema.ControladoraRegistrarPago.ObtenerInstancia().RecuperarOrdenesCompra();
            ddlComprobanteAbonar.DataSource = OrdenesCompras;
            ddlComprobanteAbonar.DataMember = "NroOrdenCompra";
            ddlComprobanteAbonar.DataBind();
            Session.Add("OrdenesCompras", OrdenesCompras);
        }
        private bool Validar()
        {
            if (string.IsNullOrEmpty(txtConcepto.Text))
            {
                Mensaje = "Por favor, ingrese el concepto del pago";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return false;
            }
            if (string.IsNullOrEmpty(txtMonto.Text))
            {
                Mensaje = "Por favor, ingrese el monto del pago";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return false;
            }
            if (string.IsNullOrEmpty(txtFecha.Text))
            {
                Mensaje = "Por favor, ingrese la fecha";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return false;
            }
            return true;
        }
        protected void ddlClientes_SelectedIndexChanged(object sender, EventArgs e) { }
        protected void ddlClientes_SelectedIndexChanged1(object sender, EventArgs e)
        {
            int indice = ddlClientes.SelectedIndex;
            Session.Add("CuentaCorriente", CuentasCorrientes[indice]);
            CuentaCorriente = (Entidades.Sistema.CuentaCorriente)Session["CuentaCorriente"];
            txtSaldo.Text = Convert.ToString(CuentaCorriente.Saldo);
        }
        protected void ddlComprobanteAbonar_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = ddlComprobanteAbonar.SelectedIndex;
            Session.Add("OrdenCompra", OrdenesCompras[indice]);
            OrdenCompra = (Entidades.Sistema.OrdenCompra)Session["OrdenCompra"];
            txtSaldoCompro.Text = Convert.ToString(OrdenCompra.PrecioTotal); 
        }
        protected void txtMonto_TextChanged(object sender, EventArgs e) { }
        protected void BtnCargarConcepto_Click(object sender, EventArgs e)
        {
            CuentaCorriente = (Entidades.Sistema.CuentaCorriente)Session["CuentaCorriente"];
            OrdenCompra = (Entidades.Sistema.OrdenCompra)Session["OrdenCompra"];
            txtConcepto.Text = string.Concat("En el dia de la fecha ", txtFecha.Text, " el cliente ", CuentaCorriente.Cliente.RazonSocial, " abonó un total de $", txtMonto.Text, ". Correspondiente al comprobante ", ddlComprobanteAbonar.Text, " abonando por medio de ", CondicionPago.Nombre);
        }
        protected void ddlFormadePago_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = ddlFormadePago.SelectedIndex;
            Session.Add("CondicionPago", CondicionesPago[indice]);
        }
    }
}

