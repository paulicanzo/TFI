using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Sistema
{
    public partial class GenerarNotadeCredito : System.Web.UI.Page
    {
        List<Entidades.Sistema.Cliente> _Clientes;
        Entidades.Sistema.Cliente Cliente;
        List<Entidades.Sistema.CuentaCorriente> _CuentaCorriente;
        List<Entidades.Sistema.OrdenCompra> _OrdenesCompras;
        Entidades.Sistema.OrdenCompra OrdenCompra;
        Entidades.Sistema.CuentaCorriente CuentaCorriente;
        Entidades.Seguridad.Usuario oUsuario;
        Entidades.Sistema.CondicionesPago CondicionesPago;
        List<Entidades.Sistema.CondicionesPago> _Condiciones;
        string Mensaje;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.txtFecha.Text = DateTime.Now.ToShortDateString();
            if (!Page.IsPostBack)
            {
                CargarForma();
                CargarOC();
                CondicionesPago = (Entidades.Sistema.CondicionesPago)Session["CondicionesPago"];
                _Condiciones = (List<Entidades.Sistema.CondicionesPago>)Session["_Condiciones"];
                CargarCtaCte();
                Cliente = (Entidades.Sistema.Cliente)Session["Cliente"];
                OrdenCompra = (Entidades.Sistema.OrdenCompra)Session["OrdenCompra"];
                _OrdenesCompras = (List<Entidades.Sistema.OrdenCompra>)Session["_OrdenesCompra"];
                CuentaCorriente = (Entidades.Sistema.CuentaCorriente)Session["CuentaCorriente"];
                _CuentaCorriente = (List<Entidades.Sistema.CuentaCorriente>)Session["_CuentaCorriente"];
                oUsuario = (Entidades.Seguridad.Usuario)Session["Usuario"];
                if(oUsuario == null)
                {
                    Response.Redirect("DefaultBackEnd.aspx");
                }
            }
            else
            {
                CargarCtaCte();
                CondicionesPago = (Entidades.Sistema.CondicionesPago)Session["CondicionesPago"];
                _Condiciones = (List<Entidades.Sistema.CondicionesPago>)Session["_Condiciones"];
                OrdenCompra = (Entidades.Sistema.OrdenCompra)Session["OrdenCompra"];
                _OrdenesCompras = (List<Entidades.Sistema.OrdenCompra>)Session["_OrdenesCompra"];
                CuentaCorriente = (Entidades.Sistema.CuentaCorriente)Session["CuentaCorriente"];
                _CuentaCorriente = (List<Entidades.Sistema.CuentaCorriente>)Session["_CuentaCorriente"];
                Cliente = (Entidades.Sistema.Cliente)Session["Cliente"]; 
                _Clientes = (List<Entidades.Sistema.Cliente>)Session["_Clientes"];
                oUsuario = (Entidades.Seguridad.Usuario)Session["Usuario"];
            }
        }
        private void CargarOC()
        {
            _OrdenesCompras = Controladora.Sistema.ControladoraRegistrarPago.ObtenerInstancia().RecuperarOrdenesCompra();
            ddlComprobanteAbonar.DataSource = _OrdenesCompras;
            ddlComprobanteAbonar.DataMember = "NroOrdenCompra";
            ddlComprobanteAbonar.DataBind();
            Session.Add("_OrdenesCompras", _OrdenesCompras);
        }
        private void CargarForma()
        {
            _Condiciones = Controladora.Sistema.ControladoraGestionarCondicionesPago.ObtenerInstancia().RecuperarCondicionesPago();
            ddlFormaPago.DataSource = _Condiciones;
            ddlFormaPago.DataMember = "Nombre";
            ddlFormaPago.DataBind();
            Session.Add("_Condiciones", _Condiciones);
        }
        private void CargarCtaCte()
        {
            _CuentaCorriente = Controladora.Sistema.ControladoraRegistrarPago.ObtenerInstancia().RecuperarCuentaCorriente();
            ddlClientes.DataSource = _CuentaCorriente;
            ddlClientes.DataMember = "Cliente";
            ddlClientes.DataBind();
            Session.Add("_CuentaCorriente", _CuentaCorriente);
        }
        private bool Validar()
        {
            if (string.IsNullOrEmpty(txtConcepto.Text))
            {
                Mensaje = "Por favor, complete el concepto";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return false;
            }
            if (string.IsNullOrEmpty(txtMonto.Text))
            {
                Mensaje = "Complete el monto";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return false;
            }
            if (string.IsNullOrEmpty(txtFecha.Text))
            {
                Mensaje = "Complete la fecha";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return false;
            }
            return true;
        }
        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                Entidades.Sistema.Movimiento Movimiento = new Entidades.Sistema.Movimiento();
                Movimiento.Concepto = txtConcepto.Text;
                Movimiento.Tipo = Entidades.Sistema.Movimiento.MovimientoTipo.Egreso;
                Movimiento.Monto = Convert.ToInt32(txtMonto.Text);
                Movimiento.Fecha = Convert.ToDateTime(txtFecha.Text.ToString());
                Movimiento.FormaPago = CondicionesPago;
                CuentaCorriente = (Entidades.Sistema.CuentaCorriente)Session["CuentaCorriente"];
                CuentaCorriente.RestarMovimiento(Movimiento);
                Controladora.Sistema.ControladoraCuentasCorrientes.ObtenerInstancia().ModificarCuentaCorriente(CuentaCorriente);
                Mensaje = "Nota de credito registrada";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
            Limpiar();
        }
        private void Limpiar()
        {
            this.txtFecha.Text = DateTime.Now.ToShortDateString();
            txtConcepto.Text = "";
            txtMonto.Text = "";
            CargarForma();
            CargarOC();
            CargarCtaCte();
        }
        protected void ddlClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = ddlClientes.SelectedIndex;
            Session.Add("CuentaCorriente", _CuentaCorriente[indice]);
            CuentaCorriente = (Entidades.Sistema.CuentaCorriente)Session["CuentaCorriente"];
            txtSaldo.Text = Convert.ToString(CuentaCorriente.Saldo);
        }
        protected void ddlComprobanteAbonar_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = ddlComprobanteAbonar.SelectedIndex;
            Session.Add("OrdenCompra", _OrdenesCompras[indice]);
            OrdenCompra = (Entidades.Sistema.OrdenCompra)Session["OrdenCompra"];
            txtSaldoCompro.Text = Convert.ToString(OrdenCompra.PrecioTotal);
        }
        protected void BtnCargarConcepto_Click(object sender, EventArgs e)
        {
            CuentaCorriente = (Entidades.Sistema.CuentaCorriente)Session["CuentaCorriente"];
            OrdenCompra = (Entidades.Sistema.OrdenCompra)Session["OrdenCompra"];
            txtConcepto.Text = string.Concat("Se registra una nota de credito del dia ", txtFecha.Text, " al cliente ", CuentaCorriente.Cliente.RazonSocial, " con un monto de $ ", txtMonto.Text, "., correspondiente al comprobante ", ddlComprobanteAbonar.Text);
        }
        protected void ddlFormadePago_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = ddlFormaPago.SelectedIndex;
            Session.Add("CondicionesPago", _Condiciones[indice]);
        }
    }
}
