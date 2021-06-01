using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Auditoria
{
    public partial class Auditorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }
            else
            {

            }
        }
        protected void btnLogInLogOut_Click(object sender, EventArgs e)
        {
            LogGV.DataSource = Controladora.Auditoria.ControladoraAuditoria.ObtenerInstancia().RecuperarAuditoria();
            LogGV.DataBind();

            gvPerfil.Visible = false;
            gvPerfil.Visible = false;
        }
        protected void btnPerfil_Click(object sender, EventArgs e)
        {
            gvPerfil.DataSource = Controladora.Auditoria.ControladoraAuditoria.ObtenerInstancia().RecuperarAuditoriaPerfil();
            gvPerfil.DataBind();

            gvOrden.Visible = false;
            LogGV.Visible = false;
        }
        protected void btnOrden_Click(object sender, EventArgs e)
        {
            gvOrden.DataSource = Controladora.Auditoria.ControladoraAuditoria.ObtenerInstancia().RecuperarAuditoriaOrdenCompra();
            gvOrden.DataBind();

            LogGV.Visible = false;
            gvPerfil.Visible = false;
        }
        protected void gvPerfil_SelectedIndexChanged(object sender, EventArgs e) { }
        protected void gvPerfil_PageIndexChanging(object sender, GridViewPageEventArgs e) { }
        protected void gvOrden_SelectedIndexChanged(object sender, EventArgs e) { }
        protected void gvOrden_PageIndexChanging(object sender, GridViewPageEventArgs e) { }
        protected void LogGV_SelectedIndexChanged(object sender, EventArgs e) { }
        protected void LogGV_PageIndexChanging(object sender, GridViewPageEventArgs e) { }
    }
}
