using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Sistema
{
    public partial class GestionarProducto : System.Web.UI.Page
    {
        string Operacion;
        List<Entidades.Sistema.CategoriaProducto> Categorias;
        List<Entidades.Sistema.Proveedor> Proveedores;
        Entidades.Sistema.Producto Producto;
        Entidades.Seguridad.Usuario oUsuario;
        string Mensaje;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarCategorias();
                CargarProveedores();
                Operacion = Session["OpcionProductos"].ToString();
                if (Operacion == "Modificar")
                {
                    this.txtNombre.Enabled = false;
                    CargarCampos();
                }
                else if (Operacion == "Consultar")
                {

                    this.txtNombre.Enabled = false;
                    this.txtCantidad.Enabled = false;
                    this.txtPrecio.Enabled = false;
                    this.txtPuntoPedido.Enabled = false;
                    this.ddlCategoria.Enabled = false;
                    this.ddlProveedor.Enabled = false;
                    CargarCampos();

                }
            }
            else
            {
                Operacion = Session["OpcionProductos"].ToString();
                Categorias = (List<Entidades.Sistema.CategoriaProducto>)Session["Categorias"];
                Proveedores = (List<Entidades.Sistema.Proveedor>)Session["Proveedores"];
                oUsuario = (Entidades.Seguridad.Usuario)Session["Usuarios"];
                Producto = (Entidades.Sistema.Producto)Session["Producto"];
                if (Operacion == "Modificar")
                {
                    this.txtNombre.Enabled = false;
                    CargarCampos();
                }
            }
        }

        private void CargarCampos()
        {
            Producto = (Entidades.Sistema.Producto)Session["Producto"];
            txtNombre.Text = this.Producto.Nombre;
            ddlCategoria.Text = this.Producto.CategoriaProducto.Nombre;
            txtPuntoPedido.Text = this.Producto.PuntoPedido.ToString();
            txtPrecio.Text = this.Producto.Precio.ToString();
            txtCantidad.Text = this.Producto.Cantidad.ToString();
            ddlProveedor.Text = Producto.Proveedor.DenominacionLegal;
        }

        private void CargarProveedores()
        {
            Proveedores = Controladora.Sistema.ControladoraGestionarProveedores.ObtenerInstancia().RecuperarProveedores();
            Session.Add("Proveedores", Proveedores);
            ddlProveedor.DataSource = Proveedores;
            ddlProveedor.DataBind();
        }

        private void CargarCategorias()
        {
            Categorias = Controladora.Sistema.ControladoraGestionarCategoriaProductos.ObtenerInstancia().RecuperarCategoriaProducto();
            Session.Add("Categorias", Categorias);
            ddlCategoria.DataSource = Categorias;
            ddlCategoria.DataBind();
        }

        protected void ImageMap1_Click(object sender, ImageMapEventArgs e) { }

        protected void ddCategoria_SelectedIndexChanged(object sender, EventArgs e) { }
        protected void Cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionarProductos.aspx");
        }

        protected void Aceptar_Click(object sender, EventArgs e) { }

        private bool Validar()
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                Mensaje = "Complete el Nombre!";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return false;
            }

            if (string.IsNullOrEmpty(txtPrecio.Text))
            {
                Mensaje = "Complete el Precio!";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return false;
            }

            if (string.IsNullOrEmpty(txtPuntoPedido.Text))
            {
                Mensaje = "Complete el Punto de Pedido!";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return false;
            }

            if (string.IsNullOrEmpty(txtCantidad.Text))
            {
                Mensaje = "Complete la Cantidad!";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return false;
            }
            return true;
        }

        protected void Cancelar_Click1(object sender, EventArgs e)
        {
            Response.Redirect("GestionarProductos.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                if (Operacion == "Modificar")
                {
                    this.Producto.Nombre = txtNombre.Text;
                    int cat = ddlCategoria.SelectedIndex;
                    Producto.CategoriaProducto = Categorias[cat];
                    this.Producto.PuntoPedido = Convert.ToInt32(txtPuntoPedido.Text);
                    this.Producto.Precio = Convert.ToInt32(txtPrecio.Text);
                    this.Producto.Cantidad = Convert.ToInt32(txtCantidad.Text);
                    int indice = ddlProveedor.SelectedIndex;
                    Producto.Proveedor = Proveedores[indice];
                    Controladora.Sistema.ControladoraGestionarProductos.ObtenerInstancia().ModificarProducto(Producto);
                    Mensaje = "El producto " + Producto.Nombre + " fue agregado";
                    string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                }
                else if (Operacion == "Agregar")
                {
                    Entidades.Sistema.Producto Producto = new Entidades.Sistema.Producto();
                    Producto.Nombre = txtNombre.Text;
                    int indice = ddlProveedor.SelectedIndex;
                    Producto.Proveedor = Proveedores[indice];
                    Producto.PuntoPedido = Convert.ToInt32(txtPuntoPedido.Text);
                    Producto.Precio = Convert.ToInt32(txtPrecio.Text);
                    Producto.Cantidad = Convert.ToInt32(txtCantidad.Text);
                    int cat = ddlCategoria.SelectedIndex;
                    Producto.CategoriaProducto = Categorias[cat];
                    bool resultado = Controladora.Sistema.ControladoraGestionarProductos.ObtenerInstancia().AgregarProducto(Producto);
                    if (resultado)
                    {
                        Mensaje = "El producto " + Producto.Nombre + " fue agregado";
                        string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                    }
                    else
                    {
                        Mensaje = "No se puede cargar este producto, ya existe!";
                        string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                    }
                }
            }
        }
        protected void ddIVA_SelectedIndexChanged(object sender, EventArgs e) { }
        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e) { }
        protected void ddlProveedores_SelectedIndexChanged(object sender, EventArgs e) { }
        protected void BtnGuardar_Click(object sender, EventArgs e) { }
        protected void BtnCancelar_Click(object sender, EventArgs e) { }
        protected void ddlCategoria_SelectedIndexChanged1(object sender, EventArgs e) { }
        protected void ddlProveedor_SelectedIndexChanged(object sender, EventArgs e) { }
        protected void Gruardar_Click(object sender, EventArgs e) { }
    }
}
