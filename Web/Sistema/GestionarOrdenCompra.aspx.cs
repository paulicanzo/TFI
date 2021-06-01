using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Sistema
{
    public partial class GestionarOrdenCompra : System.Web.UI.Page
    {
        Entidades.Sistema.OrdenCompra OrdenCompra;
        List<Entidades.Sistema.OrdenCompra> _OrdenesCompra;
        private string Operacion;
        private Entidades.Seguridad.Usuario oUsuario;
        List<Entidades.Seguridad.Perfil> Perfiles;
        string Mensaje;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.gvOrdenes.Visible = false;
                this.BtnAnular.Visible = false;
                this.BtnGenerarOC.Visible = false;
                this.BtnImprimir.Visible = false;
                this.BtnVerDetalle.Visible = false;
                this.BtnIngresarMercaderia.Visible = false;
                oUsuario = (Entidades.Seguridad.Usuario)Session["Usuario"];
                if(oUsuario == null)
                {
                    Response.Redirect("DefaultBackEnd.aspx");
                }
                else
                {
                    CargarPermisos(Perfiles);
                    CargarGrilla();
                }
            }
            else
            {
                OrdenCompra = (Entidades.Sistema.OrdenCompra)Session["OrdenCompra"];
                _OrdenesCompra = (List<Entidades.Sistema.OrdenCompra>)Session["_OrdenesCompra"];
                oUsuario = (Entidades.Seguridad.Usuario)Session["Usuario"];
                CargarGrilla();
            }
        }
        private void CargarPermisos(List<Entidades.Seguridad.Perfil> Perfiles)
        {
            Perfiles = Controladora.Seguridad.ControladoraIniciarSesion.ObtenerInstancia().RecuperarPerfil(oUsuario);
            foreach (Entidades.Seguridad.Perfil oPerfil in Perfiles)
            {
                if ("Orden de Compra" == oPerfil.Formulario.Nombre)
                {
                    switch (oPerfil.Permiso.Nombre)
                    {
                        case "Agregar":
                            this.BtnGenerarOC.Visible = true;
                            break;
                        case "Anular":
                            this.BtnAnular.Visible = true;
                            break;
                        case "Imprimir Orden":
                            this.BtnImprimir.Visible = true;
                            break;
                        case "Ver Detalle":
                            this.BtnVerDetalle.Visible = true;
                            break;
                        case "Ingresar Mercaderia":
                            this.BtnIngresarMercaderia.Visible = true;
                            break;
                        case "Acceso":
                            this.gvOrdenes.Visible = true;
                            break;

                    }
                }
            }
        }
        private void CargarGrilla()
        {
            _OrdenesCompra = Controladora.Sistema.ControladoraOrdenCompra.ObtenerInstancia().RecuperarOrdenCompra();
            gvOrdenes.DataSource = _OrdenesCompra;
            gvOrdenes.DataBind();
            Session.Add("_OrdenesCompra", _OrdenesCompra);
        }
        protected void gvOrdenes_SelectedIndexChanged(object sender, EventArgs e) { }
        protected void BtnFiltrar_Click(object sender, EventArgs e)
        {
            gvOrdenes.DataSource = Controladora.Sistema.ControladoraOrdenCompra.ObtenerInstancia().FiltrarOrdenes(this.txtFiltrar.Text);
            gvOrdenes.DataBind();
        }
        protected void BtnGenerarOC_Click(object sender, EventArgs e)
        {
            Operacion = "Agregar";
            Session["OpcionOrden"] = Operacion;
            Response.Redirect("OrdendeCompra.aspx");
        }
        protected void BtnVerDetalle_Click(object sender, EventArgs e)
        {
            Entidades.Sistema.OrdenCompra OrdenCompra = (Entidades.Sistema.OrdenCompra)Session["OrdenCompra"];
            if (OrdenCompra != null)
            {
                int nro = this.gvOrdenes.SelectedIndex;
                Entidades.Sistema.OrdenCompra usu = Controladora.Sistema.ControladoraOrdenCompra.ObtenerInstancia().RecuperarOrdenCompra()[nro];
                Session.Add("OrdenCompra", usu);
                Response.Redirect("DetalleOC.aspx");
            }
            else
            {
                Mensaje = "Seleccione una Orden!";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
        }
        protected void BtnAnular_Click(object sender, EventArgs e)
        {
            Entidades.Sistema.OrdenCompra OrdenCompra = (Entidades.Sistema.OrdenCompra)Session["OrdenCompra"];
            oUsuario = (Entidades.Seguridad.Usuario)Session["Usuario"];
            if (OrdenCompra != null)
            {
                if (OrdenCompra.Estado == "En Curso")
                {
                    BtnAnular.Attributes.Add("language", "javascript");
                    BtnAnular.Attributes.Add("onclick", "return confirm('¿Desea Anular la Orden de Compra seleccionada?')");
                    bool res = Controladora.Sistema.ControladoraOrdenCompra.ObtenerInstancia().AnularOrdenCompra(OrdenCompra, oUsuario);
                    if (res)
                    {
                        CargarGrilla();
                    }
                    else
                    {
                        Mensaje = "La Orden Nro " + OrdenCompra.NroOrdenCompra + " no se puede anular";
                        string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);
                    }
                }
                else if (OrdenCompra.Estado == "Anulada")
                {
                    Mensaje = "La Orden Nro " + OrdenCompra.NroOrdenCompra + " ya fue anulada";
                    string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);
                }
            }
            else
            {
                Mensaje = "Seleccione una Orden!";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
        }
        protected void BtnImprimir_Click(object sender, EventArgs e)
        {
            Entidades.Sistema.OrdenCompra OrdenCompra = (Entidades.Sistema.OrdenCompra)Session["OrdenCompra"];
            if (OrdenCompra != null)
            {
                int nro = this.gvOrdenes.SelectedIndex;
                Entidades.Sistema.OrdenCompra usu = Controladora.Sistema.ControladoraOrdenCompra.ObtenerInstancia().RecuperarOrdenCompra()[nro];
                Session.Add("OrdenCompra", usu);
                Response.Redirect("/Sistema/Reportes/ImprimirOrdenCompra.aspx");
            }
            else
            {
                Mensaje = "Seleccione una Orden!";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
        }
        protected void BtnIngresarMercaderia_Click(object sender, EventArgs e)
        {
            Entidades.Sistema.OrdenCompra OrdenCompra = (Entidades.Sistema.OrdenCompra)Session["OrdenCompra"];
            if (OrdenCompra != null)
            {
                int nro = this.gvOrdenes.SelectedIndex;
                Entidades.Sistema.OrdenCompra usu = Controladora.Sistema.ControladoraOrdenCompra.ObtenerInstancia().RecuperarOrdenCompra()[nro];
                Session.Add("OrdenCompra", usu);
                Response.Redirect("IngresoMercaderia.aspx");
            }
            else
            {
                Mensaje = "Seleccione una Orden!";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
        }
        protected void gvOrdenes_SelectedIndexChanged1(object sender, EventArgs e)
        {
            int IndiceFila = gvOrdenes.SelectedIndex;
            Session.Add("OrdenCompra", _OrdenesCompra[IndiceFila]);
        }
        protected void gvOrdenes_RowDataBound(object sender, GridViewRowEventArgs e) { }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            CargarGrilla();
        }
    }
}
