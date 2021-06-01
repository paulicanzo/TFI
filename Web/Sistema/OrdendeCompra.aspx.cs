using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Sistema
{
    public partial class OrdendeCompra : System.Web.UI.Page
    {
        Entidades.Sistema.LineaOrdenCompra Linea;
        Entidades.Sistema.CondicionesPago Condicion;
        Entidades.Sistema.OrdenCompra OrdenesCompras;
        Entidades.Sistema.Proveedor Proveedor;
        Entidades.Sistema.Producto Producto;
        private List<Entidades.Sistema.Proveedor> Proveedores;
        private List<Entidades.Sistema.Producto> Productos;
        private List<Entidades.Sistema.LineaOrdenCompra> Lineas;
        string Mensaje;
        Entidades.Seguridad.Usuario oUsuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Proveedores = Controladora.Sistema.ControladoraGestionarProveedores.ObtenerInstancia().RecuperarProveedores();
                Session.Add("Proveedores", Proveedores);
                dProveedores.DataSource = Proveedores;
                dProveedores.DataBind();
                txtTotal.Enabled = false;
                oUsuario = (Entidades.Seguridad.Usuario)Session["Usuario"];
                OrdenesCompras = new Entidades.Sistema.OrdenCompra();
                Session.Add("OrdenesCompras", OrdenesCompras);
            }
            else
            {
                txtTotal.Enabled = false;
                Condicion = (Entidades.Sistema.CondicionesPago)Session["Condicion"];
                Proveedores = (List<Entidades.Sistema.Proveedor>)Session["Proveedores"];
                Proveedor = (Entidades.Sistema.Proveedor)Session["Proveedor"];
                Productos = (List<Entidades.Sistema.Producto>)Session["Productos"];
                Producto = (Entidades.Sistema.Producto)Session["Producto"];
                Linea = (Entidades.Sistema.LineaOrdenCompra)Session["Linea"];
                Lineas = (List<Entidades.Sistema.LineaOrdenCompra>)Session["Lineas"];
                OrdenesCompras = (Entidades.Sistema.OrdenCompra)Session["OrdenesCompras"];
                oUsuario = (Entidades.Seguridad.Usuario)Session["Usuario"];
            }
        }
        protected void Button1_Click(object sender, EventArgs e) { }
        protected void Quitar_Click(object sender, EventArgs e) { }
        protected void dProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            Proveedor = (Entidades.Sistema.Proveedor)Proveedores[dProveedores.SelectedIndex];
            Session.Add("Proveedor", Proveedor);
            ddCondiciones.DataSource = Proveedor.CondicionesPago;
            ddCondiciones.DataBind();

            Productos = Controladora.Sistema.ControladoraOrdenCompra.ObtenerInstancia().RecuperarProductosProveedor(Proveedor);
            Session.Add("Productos", Productos);
            gvListadoProductos.DataSource = Productos;
            gvListadoProductos.DataBind();
        }
        protected void Aceptar_Click(object sender, EventArgs e)
        {
            OrdenesCompras.Proveedor = (Entidades.Sistema.Proveedor)Proveedor;
            OrdenesCompras.CondicionesPago = Condicion;
            OrdenesCompras.FechaEmision = Convert.ToDateTime(TxtFechaEmision.Text);
            OrdenesCompras.FechaRecepcionMercaderia = Convert.ToDateTime(txtFecgaRecepcion.Text);
            OrdenesCompras.PrecioTotal = Convert.ToDecimal(txtTotal.Text);
            OrdenesCompras.Estado = "En Curso";
            bool resultado = Controladora.Sistema.ControladoraOrdenCompra.ObtenerInstancia().AgregarOrdenCompra(OrdenesCompras, oUsuario);
            if (resultado)
            {
                Response.Redirect("GestionarOrdenCompra.aspx");
            }
            else
            {
                Mensaje = "No se puede Generar la Orden!";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);
            }
        }
        protected void ddCondicionesPago_SelectedIndexChanged(object sender, EventArgs e) { }
        protected void gvListadoProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Producto = (Entidades.Sistema.Producto)Productos[gvListadoProductos.SelectedIndex];
            Session.Add("Producto", Producto); 
        }
        protected void dProveedores_SelectedIndexChanged1(object sender, EventArgs e)
        {
            Proveedor = (Entidades.Sistema.Proveedor)Proveedores[dProveedores.SelectedIndex];
            Session.Add("Proveedor", Proveedor);
            ddCondiciones.DataSource = Proveedor.CondicionesPago;
            ddCondiciones.DataBind();

            Productos = (Controladora.Sistema.ControladoraOrdenCompra.ObtenerInstancia().RecuperarProductosProveedor(Proveedor));
            Session.Add("Productos", Productos);
            gvListadoProductos.DataSource = Productos;
            gvListadoProductos.DataBind();
        }
        protected void ddCondiciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            Condicion = (Entidades.Sistema.CondicionesPago)Proveedor.CondicionesPago[ddCondiciones.SelectedIndex];
            Session.Add("Condicion", Condicion);
        }
        protected void gvDetalle_SelectedIndexChanged(object sender, EventArgs e)
        {
            Linea = (Entidades.Sistema.LineaOrdenCompra)Lineas[gvDetalle.SelectedIndex];
            Session.Add("Linea", Linea);
        }
        protected void Agregar_Click(object sender, EventArgs e)
        {
            Producto = (Entidades.Sistema.Producto)Session["Producto"]; 
            if(Producto == null)
            {
                Response.Write("<script language='JavaScript'>window. ('Seleccione el producto a agregar.')</script>");
                if (string.IsNullOrEmpty(txtCantidad.Text))
                {
                    Response.Write("<script language='JavaScript'>window. ('Ingrese la cantidad del producto seleccionado')</script>");
                }
                if (string.IsNullOrEmpty(txtPrecioUnitario.Text))
                {
                    Response.Write("script lengueaje='JavaScript'windows. ('Ingrese el precio del producto')");
                }
            }
            else
            {
                Entidades.Sistema.LineaOrdenCompra oLinea = new Entidades.Sistema.LineaOrdenCompra();
                oLinea.CargarDatos(Producto, Convert.ToDecimal(this.txtPrecioUnitario.Text), Convert.ToInt32(txtCantidad.Text));
                bool resultado = OrdenesCompras.AgregarLineaOrdenCompra(oLinea);

                Session.Add("Lineas", OrdenesCompras.LineaOrdenCompra);
                if (resultado)
                {
                    this.txtTotal.Text = OrdenesCompras.PrecioTotal.ToString();
                    CargarLineas(); 
                }
                else if(txtCantidad.Text == null)
                {

                    Mensaje = "Ingrese la cantidad del producto seleccionado!";
                    string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);
                }
                else if(txtPrecioUnitario.Text == null)
                {
                    Mensaje = "Ingrese el Precio Unitario del Producto seleccionado!";
                    string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);
                }
                else
                {
                    Mensaje = "El producto seleccionado ya fue agregado!";
                    string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);
                }
            }

        }
        protected void Quitar_Click1(object sender, EventArgs e)
        {
            Entidades.Sistema.OrdenCompra OrdenesCompras = (Entidades.Sistema.OrdenCompra)Session["OrdenesCompras"];
            Entidades.Sistema.LineaOrdenCompra linea = (Entidades.Sistema.LineaOrdenCompra)Session["Linea"];
            OrdenesCompras.QuitarLineaOrdenCompra(linea);
            this.txtTotal.Text = OrdenesCompras.PrecioTotal.ToString();
            CargarLineas();
        }
        private void CargarLineas()
        {
            Lineas = OrdenesCompras.LineaOrdenCompra;
            gvDetalle.DataSource = Lineas;
            gvDetalle.DataBind(); 
        }
        protected void TxtTotal_TextChanged(object sender, EventArgs e) { }
        protected void Cancelar_Click(object sender, EventArgs e) { }
    }
}
