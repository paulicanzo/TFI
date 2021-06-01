using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Sistema
{
    public partial class DescontarMercaderia : System.Web.UI.Page
    {
        Entidades.Sistema.NotaVenta NotaVenta;
        Entidades.Sistema.LineaNotaVenta Linea;
        List<Entidades.Sistema.LineaNotaVenta> _Lineas;
        private Entidades.Seguridad.Usuario oUsuario;
        string Mensaje;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                oUsuario = (Entidades.Seguridad.Usuario)Session["Usuario"];
                CargarNV();
            }
            else
            {
                NotaVenta = (Entidades.Sistema.NotaVenta)Session["NotaVenta"];
                Linea = (Entidades.Sistema.LineaNotaVenta)Session["Linea"];
                _Lineas = (List<Entidades.Sistema.LineaNotaVenta>)Session["_Lineas"];
                oUsuario = (Entidades.Seguridad.Usuario)Session["Usuarios"];
                CargarNV();
            }
        }
        private void CargarNV()
        {
            NotaVenta = (Entidades.Sistema.NotaVenta)Session["NotaVenta"];
            gvDetalle.DataSource = NotaVenta.LineaNotaVenta;
            gvDetalle.DataBind();
            this.txtClientes.Enabled = false;
            this.txtFechaEmision.Enabled = false;
            this.txtTotal.Enabled = false;
            this.txtClientes.Text = NotaVenta.Cliente.RazonSocial;
            this.txtFechaEmision.Text = NotaVenta.Fecha.ToString();
            this.txtTotal.Text = NotaVenta.PrecioTotal.ToString();
        }
        protected void gvDetalle_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indiceFila = gvDetalle.SelectedIndex;
            Session.Add("Linea", NotaVenta.LineaNotaVenta[indiceFila]);
        }
        protected void txtTotal_TextChanged(object sender, EventArgs e) { }
        protected void btnCargar_Click(object sender, EventArgs e)
        {
            Entidades.Sistema.LineaNotaVenta linea = (Entidades.Sistema.LineaNotaVenta)Session["Linea"];
            if (linea != null)
            {
                if(Convert.ToInt32(this.txtCantidadIngresada.Text) == linea.Cantidad)
                {
                    linea.Producto.Cantidad = linea.Producto.Cantidad - linea.Cantidad;
                    Controladora.Sistema.ControladoraDarBajaMercaderia.ObtenerInstancia().ModificarProducto(linea.Producto);
                    NotaVenta.QuitarLineaNotaVenta(linea);
                    CargarGrilla();
                }
                else
                {
                    Mensaje = "Ingrese la cantidad correcta";
                    string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);
                }
            }
            else
            {
                Mensaje = "Seleccione un producto";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);
            }
            if (string.IsNullOrEmpty(txtCantidadIngresada.Text))
            {
                Mensaje = "Complete la cantidad ingresada del producto seleccionado";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);
            }
        }
        private void CargarGrilla()
        {
            NotaVenta = (Entidades.Sistema.NotaVenta)Session["NotaVenta"];
            gvDetalle.DataSource = NotaVenta.LineaNotaVenta;
            gvDetalle.DataBind();
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            NotaVenta = (Entidades.Sistema.NotaVenta)Session["NotaVenta"];
            if(gvDetalle.Rows.Count == 0)
            {
                NotaVenta.Estado = "Finalizada";
                Controladora.Sistema.ControladoraNotaVenta.ObtenerInstancia().FinalizarNotaVenta(NotaVenta);
            }
            else
            {
                NotaVenta.Estado = "Pendiente";
                Mensaje = "Falta ingresar mercaderia";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);
                Response.Redirect("GestionarNotasdeVentas.aspx");
            }
        }
    }
}

