using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Sistema.Auditoria
{
    public partial class AdministrarReportes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnListaPorod_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListadoProductos.aspx");
        }
        protected void ButtonListadoProdMasVend_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListadoProductosMasVendidos.aspx");
        }
        protected void BtnCompras_Click(object sender, EventArgs e)
        {
            Response.Redirect("ComprasMensuales.aspx");
        }
        protected void ButtonDeudores_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListadoMayoresDeudores.aspx");
        }
        protected void ButtonCompradores_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListadoMayoresCompradores.aspx");
        }
    }
}
