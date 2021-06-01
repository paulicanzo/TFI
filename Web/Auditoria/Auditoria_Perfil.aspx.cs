using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Auditoria
{
    public partial class Auditoria_Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                gvPerfil.DataSource = Controladora.Auditoria.ControladoraAuditoria.ObtenerInstancia().RecuperarAuditoriaPerfil();
                gvPerfil.DataBind();
            }
            else
            {
                gvPerfil.DataSource = Controladora.Auditoria.ControladoraAuditoria.ObtenerInstancia().RecuperarAuditoriaPerfil();
                gvPerfil.DataBind();
            }
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Auditorias.aspx");
        }
        protected void gvPerfil_PageIndexChanging(object sender, GridViewPageEventArgs e) { }
        protected void gvPerfil_SelectedIndexChanged(object sender, EventArgs e) { }

    }
}
