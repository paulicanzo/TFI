using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Sistema
{
    public partial class IngresoMercaderia : System.Web.UI.Page
    {
        Entidades.Sistema.OrdenCompra OrdenCompra;
        Entidades.Sistema.LineaOrdenCompra Linea;
        List<Entidades.Sistema.LineaOrdenCompra> Lineas;
        Entidades.Sistema.Faltante Faltante;
        List<Entidades.Sistema.LineaFaltante> LineaFaltante;
        private Entidades.Seguridad.Usuario oUsuario;
        string Mensaje;
        int nroOC;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                oUsuario = (Entidades.Seguridad.Usuario)Session["Usuario"];
                CargarOC();
            }
            else
            {
                OrdenCompra = (Entidades.Sistema.OrdenCompra)Session["OrdenCompra"];
                Linea = (Entidades.Sistema.LineaOrdenCompra)Session["Linea"];
                Lineas = (List<Entidades.Sistema.LineaOrdenCompra>)Session["Lineas"];
                oUsuario = (Entidades.Seguridad.Usuario)Session["Usuarios"];
                Faltante = (Entidades.Sistema.Faltante)Session["Faltante"];
                LineaFaltante = (List<Entidades.Sistema.LineaFaltante>)Session["LineaFaltante"];
                CargarOC();
            }
        }
        private void CargarOC()
        {
            OrdenCompra = (Entidades.Sistema.OrdenCompra)Session["OrdenCompra"];
            gvDetalleOC.DataSource = OrdenCompra.LineaOrdenCompra;
            gvDetalleOC.DataBind();
            this.txtNroOrden.Enabled = false;
            this.txtCondicion.Enabled = false;
            this.TXTProveedor.Enabled = false;
            this.txtFecgaRecepcion.Enabled = false;
            this.TxtFechaEmision.Enabled = false;
            this.txtTotal.Enabled = false;
            nroOC = OrdenCompra.NroOrdenCompra;
            this.txtNroOrden.Text = nroOC.ToString();
            this.txtCondicion.Text = OrdenCompra.CondicionesPago.Nombre;
            this.TXTProveedor.Text = OrdenCompra.Proveedor.DenominacionLegal;
            this.txtFecgaRecepcion.Text = OrdenCompra.FechaRecepcionMercaderia.ToString();
            this.TxtFechaEmision.Text = OrdenCompra.FechaEmision.ToString();
            this.txtTotal.Text = OrdenCompra.PrecioTotal.ToString();
        }
        protected void gvDetalleOC_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indiceFila = gvDetalleOC.SelectedIndex;
            Session.Add("Linea", OrdenCompra.LineaOrdenCompra[indiceFila]);
        }
        protected void btnCargar_Click(object sender, EventArgs e)
        {
            Entidades.Sistema.LineaOrdenCompra linea = (Entidades.Sistema.LineaOrdenCompra)Session["Linea"]; 
            if(linea != null)
            {
                Entidades.Sistema.LineaFaltante oLineaFaltante = new Entidades.Sistema.LineaFaltante(); 
                if(linea.Cantidad > Convert.ToInt32(this.txtCantidadIngresada.Text))
                {
                    Faltante = new Entidades.Sistema.Faltante();
                    Session.Add("Faltante", Faltante);
                    Faltante.NroOrdenCompra = OrdenCompra.NroOrdenCompra;
                    oLineaFaltante.Producto = linea.Producto;
                    oLineaFaltante.CantidadFaltante = linea.Cantidad - Convert.ToInt32(this.txtCantidadIngresada.Text);

                    bool resultado = Faltante.AgregarLineaFaltante(oLineaFaltante);
                    Session.Add("LineaFaltante", Faltante.LineaFaltante);
                    if (resultado)
                    {
                        linea.Producto.Cantidad = linea.Producto.Cantidad + Convert.ToInt32(this.txtCantidadIngresada.Text);

                        Controladora.Sistema.ControladoraIngresarMercaderia.ObtenerInstancia().ModificarProducto(linea.Producto);
                        Controladora.Sistema.ControladoraIngresarMercaderia.ObtenerInstancia().AgregarFaltante(Faltante);
                        Controladora.Sistema.ControladoraIngresarMercaderia.ObtenerInstancia().ModificarFaltante(Faltante);
                        CargarGrilla();
                        Mensaje = "Existe faltante del producto seleccionado.";
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
                else if(linea.Cantidad == Convert.ToInt32(this.txtCantidadIngresada.Text))
                {
                    linea.Producto.Cantidad = linea.Producto.Cantidad + Convert.ToInt32(this.txtCantidadIngresada.Text);

                    Controladora.Sistema.ControladoraIngresarMercaderia.ObtenerInstancia().ModificarProducto(linea.Producto);
                    Mensaje = "Mercaderia entrante Correcta!";
                    string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);
                }
                if (string.IsNullOrEmpty(txtCantidadIngresada.Text))
                {
                    Mensaje = "Complete la Cantidad ingresada del producto seleccionado";
                    string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);
                }
            }
        }
        private void CargarGrilla()
        {
            Faltante = (Controladora.Sistema.ControladoraIngresarMercaderia.ObtenerInstancia().RecuperarFaltante(nroOC));
            gvEstadoMerca.DataSource = Faltante.LineaFaltante;
            gvEstadoMerca.DataBind();
        }
        protected void gvEstadoMerca_SelectedIndexChanged(object sender, EventArgs e) { }
        protected void Cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionarOrdenCompra.aspx");
        }
        protected void Aceptar_Click(object sender, EventArgs e)
        {
            if(Faltante == null)
            {
                Entidades.Auditoria.AuditoriaOrdenCompra AOCo = new Entidades.Auditoria.AuditoriaOrdenCompra();
                AOCo.Usuario = OrdenCompra.Usuario;
                AOCo.Equipo = Environment.MachineName;
                AOCo.Fecha = DateTime.Now;
                AOCo.Operacion = "Ingreso de Mercaderia";
                AOCo.NroOrdenCompra = OrdenCompra.NroOrdenCompra;
                AOCo.CondicionesPago = OrdenCompra.CondicionesPago.Nombre;
                AOCo.Estado = "Finalizada";
                OrdenCompra.Estado = "Finalizada";
                AOCo.FechaEmision = OrdenCompra.FechaEmision;
                AOCo.FechaRecepcionMercaderia = OrdenCompra.FechaRecepcionMercaderia;
                AOCo.PrecioTotal = OrdenCompra.PrecioTotal;
                AOCo.Proveedor = OrdenCompra.Proveedor.DenominacionLegal;
                Controladora.Auditoria.ControladoraAuditoria.ObtenerInstancia().AgregarAuditoriaOrdenCompra(AOCo);
                Mensaje = "Ingreso de mercaderia completa registrado!";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);
            }
            else
            {
                Entidades.Auditoria.AuditoriaOrdenCompra AOC = new Entidades.Auditoria.AuditoriaOrdenCompra();
                AOC.Usuario = OrdenCompra.Usuario;
                AOC.Equipo = Environment.MachineName;
                AOC.Fecha = DateTime.Now;
                AOC.Operacion = "Ingreso de Mercaderia";
                AOC.NroOrdenCompra = OrdenCompra.NroOrdenCompra;
                AOC.CondicionesPago = OrdenCompra.CondicionesPago.Nombre;
                AOC.Estado = "Pendiente";
                OrdenCompra.Estado = "Pendiente";
                AOC.FechaEmision = OrdenCompra.FechaEmision;
                AOC.FechaRecepcionMercaderia = OrdenCompra.FechaRecepcionMercaderia;
                AOC.PrecioTotal = OrdenCompra.PrecioTotal;
                AOC.Proveedor = OrdenCompra.Proveedor.DenominacionLegal;
                Controladora.Auditoria.ControladoraAuditoria.ObtenerInstancia().AgregarAuditoriaOrdenCompra(AOC);
                Controladora.Sistema.ControladoraIngresarMercaderia.ObtenerInstancia().AgregarFaltante(Faltante);
                Mensaje = "Ingreso de mercaderia Pendiente registrado!";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);
                Response.Redirect("GestionarOrdenCompra.aspx");
            }
        }
        protected void txtTotal_TextChanged(object sender, EventArgs e) { }
    }
}

