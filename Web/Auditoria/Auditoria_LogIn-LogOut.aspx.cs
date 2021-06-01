using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Auditoria
{
    public partial class Auditoria_LogIn_LogOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LogGV.DataSource = Controladora.Auditoria.ControladoraAuditoria.ObtenerInstancia().RecuperarAuditoria();
                LogGV.DataBind();
            }
            else
            {
                LogGV.DataSource = Controladora.Auditoria.ControladoraAuditoria.ObtenerInstancia().RecuperarAuditoria();
                LogGV.DataBind();
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Auditorias.aspx");
        }

        protected void gvLog_PageIndexChanging(object sender, GridViewPageEventArgs e) { }

        protected void gvLog_SelectedIndexChanged(object sender, EventArgs e) { }

        protected void LogGV_SelectedIndexChanged(object sender, EventArgs e) { }

        protected void LogGV_PageIndexChanging(object sender, GridViewPageEventArgs e) { }

    }
}

