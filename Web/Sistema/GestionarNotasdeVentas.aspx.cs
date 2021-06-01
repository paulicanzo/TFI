using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Sistema
{
    public partial class GestionarNotasdeVentas : System.Web.UI.Page
    {
        List<Entidades.Sistema.NotaVenta> _NotasVentas;
        Entidades.Sistema.NotaVenta NotaVenta;
        private string Operacion;
        private Entidades.Seguridad.Usuario oUsuario;
        List<Entidades.Seguridad.Perfil> Perfiles;
        string Mensaje;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.gvNotas.Visible = false;
                this.BtnAnular.Visible = false;
                this.BtnGenerarOC.Visible = false;
                this.BtnImprimir.Visible = false;
                this.BtnVerDetalle.Visible = false;
                this.BtnDescontarMercaderia.Visible = false;
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
                NotaVenta = (Entidades.Sistema.NotaVenta)Session["NotaVenta"];
                _NotasVentas = (List<Entidades.Sistema.NotaVenta>)Session["_NotasVentas"];
                oUsuario = (Entidades.Seguridad.Usuario)Session["Usuarios"];
                CargarGrilla();
            }
        }
        private void CargarPermisos(List<Entidades.Seguridad.Perfil> Perfiles)
        {
            Perfiles = Controladora.Seguridad.ControladoraIniciarSesion.ObtenerInstancia().RecuperarPerfil(oUsuario);
            foreach (Entidades.Seguridad.Perfil oPerfil in Perfiles)
            {
                if("Notas de Ventas"  == oPerfil.Formulario.Nombre)
                {
                    switch (oPerfil.Permiso.Nombre)
                    {
                        case "Agregar":
                            this.BtnGenerarOC.Visible = true;
                            break;
                        case "Anular":
                            this.BtnAnular.Visible = true;
                            break;
                        case "Imprimir Nota":
                            this.BtnImprimir.Visible = true;
                            break;
                        case "Ver Detalle":
                            this.BtnVerDetalle.Visible = true;
                            break;
                        case "Dar Baja":
                            this.BtnDescontarMercaderia.Visible = true;
                            break;
                        case "Acceso":
                            this.gvNotas.Visible = true;
                            break;
                    }
                }
            }
        }
        private void CargarGrilla()
        {
            _NotasVentas = Controladora.Sistema.ControladoraNotaVenta.ObtenerInstancia().RecuperarNotaVenta();
            gvNotas.DataSource = null;
            gvNotas.DataSource = _NotasVentas;
            gvNotas.DataBind();
            Session.Add("_NotasVentas", _NotasVentas);
        }
        protected void gvNotas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indiceFila = gvNotas.SelectedIndex;
            Session.Add("NotaVenta", _NotasVentas[indiceFila]);
        }
        protected void gvNotas_RowDataBound(object sender, GridViewRowEventArgs e) { }
        protected void BtnGenerarOC_Click(object sender, EventArgs e)
        {
            Operacion = "Agregar";
            Session["OpcionNota"] = Operacion;
            Response.Redirect("GenerarNotadeVenta.aspx");
        }
        protected void BtnDescontarMercaderia_Click(object sender, EventArgs e)
        {
            Entidades.Sistema.NotaVenta NotaVenta = (Entidades.Sistema.NotaVenta)Session["NotaVenta"];
            if(NotaVenta != null)
            {
                int nro = this.gvNotas.SelectedIndex;
                Entidades.Sistema.NotaVenta nota = Controladora.Sistema.ControladoraNotaVenta.ObtenerInstancia().RecuperarNotaVenta()[nro];
                Session.Add("NotaVenta", nota);
                Response.Redirect("DescontarMercaderia.aspx");
            }
            else
            {
                Mensaje = "Seleccione una Nota!";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
        }
        protected void BtnVerDetalle_Click(object sender, EventArgs e)
        {
            Entidades.Sistema.NotaVenta NotaVenta = (Entidades.Sistema.NotaVenta)Session["NotaVenta"]; 
            if(NotaVenta != null)
            {
                int nro = this.gvNotas.SelectedIndex;
                Entidades.Sistema.NotaVenta nota = Controladora.Sistema.ControladoraNotaVenta.ObtenerInstancia().RecuperarNotaVenta()[nro];
                Session.Add("NotaVenta", nota);
                Response.Redirect("DetalleNotaVenta.aspx");
            }
            else
            {
                Mensaje = "Seleccione una Nota!";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
        }
        protected void BtnAnular_Click(object sender, EventArgs e)
        {
            Entidades.Sistema.NotaVenta NotaVenta = (Entidades.Sistema.NotaVenta)Session["NotaVenta"];
            if(NotaVenta!= null)
            {
                if(NotaVenta.Estado == "En Curso")
                {
                    BtnAnular.Attributes.Add("language", "javascript");
                    BtnAnular.Attributes.Add("onclick", "return confirm('¿Desea Anular la Nota de Venta seleccionada?')");
                    bool res = Controladora.Sistema.ControladoraNotaVenta.ObtenerInstancia().AnularNotaVenta(NotaVenta);
                    if (res)
                    {
                        CargarGrilla();
                    }
                    else
                    {
                        Mensaje = "La Nota Nro " + NotaVenta.NroNotaVenta + " no se puede anular";
                        string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);
                    }
                }
                else if(NotaVenta.Estado == "Anulada")
                {
                    Mensaje = "La Nota Nro " + NotaVenta.NroNotaVenta + " ya fue anulada";
                    string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);
                }
            }
            else
            {
                Mensaje = "Seleccione una Nota!";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
        }
        protected void BtnImprimir_Click(object sender, EventArgs e)
        {
            Entidades.Sistema.NotaVenta NotaVenta = (Entidades.Sistema.NotaVenta)Session["NotaVenta"]; 
            if(NotaVenta != null)
            {
                int nro = this.gvNotas.SelectedIndex;
                Entidades.Sistema.NotaVenta nota = Controladora.Sistema.ControladoraNotaVenta.ObtenerInstancia().RecuperarNotaVenta()[nro];
                Session.Add("NotaVenta", nota);
                Response.Redirect("/Sistema/Reportes/ImprimirNotaVenta.aspx");
            }
            else
            {
                Mensaje = "Seleccione una Nota!";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
        }
        protected void BtnFiltrar_Click(object sender, EventArgs e) { }
        protected void BtnFiltrar_Click1(object sender, EventArgs e)
        {
            gvNotas.DataSource = Controladora.Sistema.ControladoraNotaVenta.ObtenerInstancia().FiltrarNotaVenta(this.txtFiltrar.Text);
            gvNotas.DataBind();
        }
    }
}

