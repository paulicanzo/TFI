using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Seguridad
{
    public partial class MDSOlvideMiContraseña : System.Web.UI.Page
    {
        string Mensaje;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Aceptar_Click(object sender, EventArgs e)
        {
            string nombreUsuario = txtUsuario.Text;
            if (string.IsNullOrEmpty(nombreUsuario))
            {
                Mensaje = "Complete el nombre del usuario";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
            else
            {
                bool resultado = Controladora.Seguridad.ControladoraRecuperarClave.ObtenerInstancia().RecuperarClave(nombreUsuario); 
                if(resultado == false)
                {
                    Mensaje = "El nombre de usuario ingresado no es correcto";
                    string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                }
                else
                {
                    Mensaje = "La contraseña ha sido enviada a su correo electrónico";
                    string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                }
            }
        }
        protected void Cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Sistema/EmpleadoBackEnd.aspx");
        }
    }
}
