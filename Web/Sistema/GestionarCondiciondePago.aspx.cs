using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Sistema
{
    public partial class GestionarCondiciondePago : System.Web.UI.Page
    {
        private int indiceFila;
        private Entidades.Seguridad.Usuario oUsuario;
        private Entidades.Sistema.CondicionesPago CondicionPago;
        private List<Entidades.Sistema.CondicionesPago> _CondicionesPago;
        List<Entidades.Seguridad.Perfil> Perfiles;
        string Mensaje;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                oUsuario = (Entidades.Seguridad.Usuario)Session["Usuario"];
            }
        }
        protected void Aceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                Entidades.Sistema.CondicionesPago Condicion = new Entidades.Sistema.CondicionesPago();
                Condicion.Nombre = txtNombre.Text;
                Condicion.Descripcion = txtDescripcion.Text;
                if (Controladora.Sistema.ControladoraGestionarCondicionesPago.ObtenerInstancia().AgregarCondicionesPago(Condicion))
                {
                    Mensaje = "La condicion de pago " + txtNombre.Text + " se agregó correctamente";
                    string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                    Response.Redirect("GestionarCondiciondePago.aspx");
                }
                else
                {
                    Mensaje = "La condicion de pago " + txtNombre.Text + " ya existe";
                    string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                    Response.Redirect("GestionarCondiciondePago.aspx");
                }
            }
        }
        private bool Validar()
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                Mensaje = "Por favor, ingrese el nombre!";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return false;
            }
            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                Mensaje = "Por favor, ingrese una descripcion";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return false;
            }
            return true;
        }
        protected void Cancelar_Click(object sender, EventArgs e) { }
    }

}
