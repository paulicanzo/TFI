using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Sistema
{
    public partial class DetalleNotaVenta : System.Web.UI.Page
    {
        Entidades.Sistema.LineaNotaVenta Linea;
        Entidades.Sistema.NotaVenta NotaVenta;
        private List<Entidades.Sistema.LineaNotaVenta> Lineas;
        string Mensaje;
        Entidades.Seguridad.Usuario oUsuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.txtTotal.Enabled = false;
                this.txtNroNota.Enabled = false;
                CargarGrilla();
            }
            else
            {
                CargarGrilla();
                NotaVenta = (Entidades.Sistema.NotaVenta)Session["NotaVenta"];
                oUsuario = (Entidades.Seguridad.Usuario)Session["Usuarios"];
                Lineas = (List<Entidades.Sistema.LineaNotaVenta>)Session["Lineas"];
            }
        }
        private void CargarGrilla()
        {
            NotaVenta = (Entidades.Sistema.NotaVenta)Session["NotaVenta"];
            this.txtNroNota.Text = NotaVenta.NroNotaVenta.ToString();
            this.txtTotal.Text = NotaVenta.PrecioTotal.ToString();
            Lineas = NotaVenta.LineaNotaVenta;
            gvDetalleNota.DataSource = Lineas;
            gvDetalleNota.DataBind();
        }
        protected void Aceptar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionarNotasdeVenta.aspx");
        }
    }
}

