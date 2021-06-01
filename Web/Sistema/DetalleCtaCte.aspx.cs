using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Sistema
{
    public partial class DetalleCtaCte : System.Web.UI.Page
    {
        Entidades.Sistema.CuentaCorriente CuentaCorriente;
        private Entidades.Seguridad.Usuario oUsuario; 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.txtTotal.Enabled = false;
                this.txtCliente.Enabled = false;
                this.txtIVA.Enabled = false;
                this.txtLocalidad.Enabled = false;
                this.txtTelefono.Enabled = false;
                this.txtDomicilio.Enabled = false;

                CargarGrilla();
                CuentaCorriente = (Entidades.Sistema.CuentaCorriente)Session["CuentaCorriente"];
                oUsuario = (Entidades.Seguridad.Usuario)Session["Usuario"];
                if(oUsuario == null)
                {
                    Response.Redirect("DefaultBackEnd.aspx");
                }
            }
            else
            {
                CargarGrilla();
                CuentaCorriente = (Entidades.Sistema.CuentaCorriente)Session["CuentaCorriente"];
                oUsuario = (Entidades.Seguridad.Usuario)Session["Usuario"];
            }
        }
        private void CargarGrilla()
        {
            CuentaCorriente = (Entidades.Sistema.CuentaCorriente)Session["CuentaCorriente"];
            this.txtCliente.Text = this.CuentaCorriente.Cliente.RazonSocial;
            this.txtDomicilio.Text = this.CuentaCorriente.Cliente.Direccion;
            this.txtLocalidad.Text = this.CuentaCorriente.Cliente.Localidad.Nombre;
            this.txtIVA.Text = this.CuentaCorriente.Cliente.SituacionFiscal.Nombre;
            this.txtTelefono.Text = this.CuentaCorriente.Cliente.Telefono;
            this.txtTotal.Text = this.CuentaCorriente.Saldo.ToString();

            dvDetalle.DataSource = CuentaCorriente.Movimiento;
            dvDetalle.DataBind();
        }
        protected void Btnvolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListadoCuentasCorrientes.aspx");
        }
        protected void gvDetalle_SelectedIndexChanged(object sender, EventArgs e) { }
        protected void gvDetalle_PageIndexChanging(object sender, GridViewPageEventArgs e) { }
        protected void gvDetalle_DataBinding(object sender, EventArgs e) { }
        protected void dvDetalle_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            foreach (DataGridItem item in dvDetalle.Items)
            {
                if(item.Cells[5].Text.ToString() == Entidades.Sistema.Movimiento.MovimientoTipo.Ingreso.ToString())
                {
                    item.Cells[2].Text = item.Cells[4].Text;
                }
                else
                {
                    item.Cells[3].Text = item.Cells[4].Text;
                }
            }
        }
    }
}
