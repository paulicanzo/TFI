using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Sistema
{
    public partial class DetalleOC : System.Web.UI.Page
    {
        Entidades.Sistema.LineaOrdenCompra Linea;
        Entidades.Sistema.OrdenCompra OrdenCompra;
        private List<Entidades.Sistema.LineaOrdenCompra> Lineas;
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
                OrdenCompra = (Entidades.Sistema.OrdenCompra)Session["OrdenCompra"];
                oUsuario = (Entidades.Seguridad.Usuario)Session["Usuarios"];
                Lineas = (List<Entidades.Sistema.LineaOrdenCompra>)Session["Lineas"];
            }
        }
        private void CargarGrilla()
        {
            OrdenCompra = (Entidades.Sistema.OrdenCompra)Session["OrdenCompra"];
            this.txtNroOrden.Text = OrdenCompra.NroOrdenCompra.ToString();
            this.txtTotal.Text = OrdenCompra.PrecioTotal.ToString();
            Lineas = OrdenCompra.LineaOrdenCompra;
            gvDetalleOC.DataSource = Lineas;
            gvDetalleOC.DataBind();
        }
        protected void Aceptar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionarOrdenCompra.aspx");
        }
    }
}
