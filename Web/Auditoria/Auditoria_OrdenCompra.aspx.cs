using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Auditoria
{
    public partial class Auditoria_OrdenCompra : System.Web.UI.Page
    {
        Entidades.Auditoria.AuditoriaOrdenCompra AuditoriaOrdenCompra;
        List<Entidades.Auditoria.AuditoriaOrdenCompra> _AuditoriaOrdenCompra;
        string Mensaje; 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                gvOrden.DataSource = Controladora.Auditoria.ControladoraAuditoria.ObtenerInstancia().RecuperarAuditoriaOrdenCompra();
                gvOrden.DataBind();
            }
            else
            {
                AuditoriaOrdenCompra = (Entidades.Auditoria.AuditoriaOrdenCompra)Session["AuditoriaOrdenCompra"];
                _AuditoriaOrdenCompra = (List<Entidades.Auditoria.AuditoriaOrdenCompra>)Session["_AuditoriaOrdenCompra"];
                _AuditoriaOrdenCompra = Controladora.Auditoria.ControladoraAuditoria.ObtenerInstancia().RecuperarAuditoriaOrdenCompra();
                gvOrden.DataSource = _AuditoriaOrdenCompra;
                Session.Add("_AuditoriaOrdenCompra", _AuditoriaOrdenCompra);
                gvOrden.DataBind();
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Auditorias.aspx");
        }

        protected void gvOrden_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int indiceFile = gvOrden.SelectedIndex + 1;
            Session.Add("AuditoriaOrdenCompra", _AuditoriaOrdenCompra[indiceFile]);
        }

        protected void BtnVerDetalle_Click(object sender, EventArgs e)
        {
            Entidades.Auditoria.AuditoriaOrdenCompra AOrdenCompra = (Entidades.Auditoria.AuditoriaOrdenCompra)Session["AuditoriaOrdenCompra"]; 
            if(AOrdenCompra != null)
            {
                int nro = this.gvOrden.SelectedIndex;
                Entidades.Auditoria.AuditoriaOrdenCompra usuario = Controladora.Auditoria.ControladoraAuditoria.ObtenerInstancia().RecuperarAuditoriaOrdenCompra()[nro];
                Session.Add("AuditoriaOrdenCompra", usuario);
                Response.Redirect("Detalle_Auditoria_OC.aspx");
            }
            else
            {
                Mensaje = "Por favor, seleccione una Orden de Compra"; 
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
        }
        protected void gvlOG_SelectedIndexChanged(object sender, EventArgs e) { }
        protected void gvlOG_PageIndexChanging(object sender, GridViewPageEventArgs e) { }


    }
}
