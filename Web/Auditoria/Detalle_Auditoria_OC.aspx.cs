using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Auditoria
{
    public partial class Detalle_Auditoria_OC : System.Web.UI.Page
    {
        Entidades.Auditoria.AuditoriaLineaOrdenCompra Linea;
        Entidades.Auditoria.AuditoriaOrdenCompra OrdenCompra;
        private List<Entidades.Auditoria.AuditoriaLineaOrdenCompra> Lineas;
        string Mensaje;
        Entidades.Seguridad.Usuario oUsuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.txtTotal.Enabled = false;
                this.txtNroOrden.Enabled = false;
                CargarGrilla();
            }
            else
            {
                CargarGrilla();
                OrdenCompra = (Entidades.Auditoria.AuditoriaOrdenCompra)Session["AuditoriaOrdenCompra"];
                oUsuario = (Entidades.Seguridad.Usuario)Session["Usuarios"];
                Lineas = (List<Entidades.Auditoria.AuditoriaLineaOrdenCompra>)Session["Lineas"];
            }
        }
        private void CargarGrilla()
        {
            OrdenCompra = (Entidades.Auditoria.AuditoriaOrdenCompra)Session["AuditoriaOrdenCompra"];
            this.txtNroOrden.Text = OrdenCompra.NroOrdenCompra.ToString();
            this.txtTotal.Text = OrdenCompra.PrecioTotal.ToString();
            Lineas = OrdenCompra.AuditoriaLineaOrdenCompra;
            gvDetalleAOC.DataSource = Lineas;
            gvDetalleAOC.DataBind(); 
        }
        protected void Aceptar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Auditoria_OrdenCompra.aspx");
        }
    }
}
