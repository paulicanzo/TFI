using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Sistema
{
    public partial class GenerarNotadeVenta : System.Web.UI.Page
    {
        Entidades.Sistema.LineaNotaVenta Linea;
        Entidades.Sistema.NotaVenta NotaVenta;
        Entidades.Sistema.Cliente Cliente;
        Entidades.Sistema.Producto Producto;
        private List<Entidades.Sistema.Cliente> Clientes;
        private List<Entidades.Sistema.Producto> Productos;
        private List<Entidades.Sistema.LineaNotaVenta> Lineas;
        Entidades.Sistema.Caretaker cuidador; 
        string Mensaje;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Clientes = Controladora.Sistema.ControladoraGestionarClientes.ObtenerInstancia().RecuperarClientes();
                Session.Add("Clientes", Clientes);
                ddCliente.DataSource = Clientes;
                ddCliente.DataBind();

                Productos = Controladora.Sistema.ControladoraGestionarProductos.ObtenerInstancia().RecuperarProducto();
                Session.Add("Productos", Productos);
                gvListadoProductos.DataSource = Productos;
                gvListadoProductos.DataBind();
                cuidador = new Entidades.Sistema.Caretaker();
                NotaVenta = new Entidades.Sistema.NotaVenta();
                Session.Add("NotaVenta", NotaVenta);
                Session.Add("cuidador", cuidador);
            }
            else
            {
                cuidador = (Entidades.Sistema.Caretaker)Session["cuidador"];
                Clientes = (List<Entidades.Sistema.Cliente>)Session["Clientes"];
                Cliente = (Entidades.Sistema.Cliente)Session["Cliente"];
                Productos = (List<Entidades.Sistema.Producto>)Session["Productos"];
                Producto = (Entidades.Sistema.Producto)Session["Producto"];
                Linea = (Entidades.Sistema.LineaNotaVenta)Session["Linea"];
                Lineas = (List<Entidades.Sistema.LineaNotaVenta>)Session["Lineas"];
                NotaVenta = (Entidades.Sistema.NotaVenta)Session["NotaVenta"];
            }
        }
        protected void gvDetalle_SelectedIndexChanged(object sender, EventArgs e) { }
        protected void gvDetalle_SelectedIndexChanged1(object sender, EventArgs e)
        {
            Linea = (Entidades.Sistema.LineaNotaVenta)Lineas[gvDetalle.SelectedIndex];
            Session.Add("Linea", Linea);
        }
        protected void ddCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cliente = (Entidades.Sistema.Cliente)Clientes[ddCliente.SelectedIndex];
            Session.Add("Cliente", Cliente); 
        }
        protected void Cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionarNotasdeVentas.aspx");
        }
        protected void Aceptar_Click(object sender, EventArgs e)
        {
            NotaVenta.Cliente = (Entidades.Sistema.Cliente)Cliente;
            NotaVenta.Fecha = Convert.ToDateTime(txtFechaEmision.Text);
            NotaVenta.PrecioTotal = Convert.ToDecimal(txtTotal.Text);
            NotaVenta.Estado = "En curso";
            Controladora.Sistema.ControladoraNotaVenta.ObtenerInstancia().AgregarNotaVenta(NotaVenta);
            Mensaje = "Nota de venta creada";
            string script = @"<script type='text/javascript'>alert('" + Mensaje + "');window.location='FrmGestionarProveedores.aspx'</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            Response.Redirect("GestionarNotasdeVentas.aspx");
        }
        protected void Quitar_Click(object sender, EventArgs e)
        {
            Entidades.Sistema.NotaVenta NotaVenta = (Entidades.Sistema.NotaVenta)Session["NotaVenta"];
            Entidades.Sistema.LineaNotaVenta linea = (Entidades.Sistema.LineaNotaVenta)Session["Linea"];
            cuidador.AgregarMemento(NotaVenta.CrearMemento());
            NotaVenta.QuitarLineaNotaVenta(linea);

            Session.Add("cuidador", cuidador);
            Session.Add("NotaVenta", NotaVenta);
            this.txtTotal.Text = NotaVenta.PrecioTotal.ToString();
            CargarLineas();
        }
        protected void Agregar_Click(object sender, EventArgs e)
        {
            Producto = (Entidades.Sistema.Producto)Session["Producto"]; 
            if(Producto == null)
            {
                Mensaje = "Seleccione el producto a agregar";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');window.location='FrmGestionarProveedores.aspx'</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                if (string.IsNullOrEmpty(txtCantidad.Text))
                {
                    //Mensaje = "Complete la Cantidad del producto seleccionado";
                    //string script = @"<script type='text/javascript'>alert('" + Mensaje + "');window.location='FrmGestionarProveedores.aspx'</script>";
                    //ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                }
                if (string.IsNullOrEmpty(txtPrecioUnitario.Text))
                {
                    //Mensaje = "Complete el Precio Unitario del producto seleccionado";
                    //string script = @"<script type='text/javascript'>alert('" + Mensaje + "');window.location='FrmGestionarProveedores.aspx'</script>";
                    //ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                }
            }
            else
            {
                Entidades.Sistema.LineaNotaVenta oLNV = new Entidades.Sistema.LineaNotaVenta();
                oLNV.CargarDatos(Producto, Convert.ToDecimal(this.txtPrecioUnitario.Text), Convert.ToInt32(txtCantidad.Text));
                cuidador.AgregarMemento(NotaVenta.CrearMemento());

                bool res = NotaVenta.AgregarLineaNotaVenta(oLNV);
                Session.Add("cuidador", cuidador);
                Session.Add("NotaVenta", NotaVenta);
                Session.Add("Lineas", NotaVenta.LineaNotaVenta);
                if (res)
                {
                    this.txtTotal.Text = NotaVenta.PrecioTotal.ToString();
                    CargarLineas(); 
                }
                if (string.IsNullOrEmpty(txtCantidad.Text))
                {
                    Mensaje = "Complete la cantidad del producto seleccionado";
                    string script = @"<script type='text/javascript'>alert('" + Mensaje + "');window.location='FrmGestionarProveedores.aspx'</script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                }
                if (string.IsNullOrEmpty(txtPrecioUnitario.Text))
                {
                    Mensaje = "Complete el precio del producto seleccionado";
                    string script = @"<script type='text/javascript'>alert('" + Mensaje + "');window.location='FrmGestionarProveedores.aspx'</script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                }
            }
            
        }
        private void CargarLineas()
        {
            Lineas = NotaVenta.LineaNotaVenta;
            gvDetalle.DataSource = null;
            gvDetalle.DataSource = Lineas;
            gvDetalle.DataBind();
        }
        protected void txtTotal_TextChanged(object sender, EventArgs e) { }
        protected void gvListadoProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Producto = (Entidades.Sistema.Producto)Productos[gvListadoProductos.SelectedIndex];
            Session.Add("Producto", Producto);
        }
        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            gvListadoProductos.DataSource = null;
            gvListadoProductos.DataSource = Controladora.Sistema.ControladoraGestionarProductos.ObtenerInstancia().FiltrarProductos(this.txtFiltrar.Text);
            gvListadoProductos.DataBind();
        }
        protected void Unnamed_Click(object sender, EventArgs e)
        {
            this.txtFiltrar.Text = "";
            gvListadoProductos.DataSource = Controladora.Sistema.ControladoraGestionarProductos.ObtenerInstancia().FiltrarProductos(this.txtFiltrar.Text);
            gvListadoProductos.DataBind();
        }
        protected void BtnDeshacer_Click(object sender, EventArgs e)
        {
            Entidades.Sistema.Memento memento = cuidador.QuitarMemento(); 
            if(memento != null)
            {
                NotaVenta.setMemento(memento);
                CargarLineas();
            }
        }
    }
}

