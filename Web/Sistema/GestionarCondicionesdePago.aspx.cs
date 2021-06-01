using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Sistema
{
    public partial class GestionarCondicionesdePago : System.Web.UI.Page
    {
        private int indiceFila;
        private string Operacion;
        private Entidades.Seguridad.Usuario oUsuario;
        private Entidades.Sistema.CondicionesPago CondicionPago;
        private List<Entidades.Sistema.CondicionesPago> _CondicionesPago;
        List<Entidades.Seguridad.Perfil> Perfiles;
        string Mensaje;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.gvCondiciones.Visible = false;
                this.ButtonAgregar.Visible = false;
                this.ButtonEliminar.Visible = false;

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
                oUsuario = (Entidades.Seguridad.Usuario)Session["Usuario"];
                CondicionPago = (Entidades.Sistema.CondicionesPago)Session["CondicionPago"];
                _CondicionesPago = (List<Entidades.Sistema.CondicionesPago>)Session["_CondicionesPago"];
            }
        }
        private void CargarPermisos(List<Entidades.Seguridad.Perfil> Perfiles)
        {
            Perfiles = Controladora.Seguridad.ControladoraIniciarSesion.ObtenerInstancia().RecuperarPerfil(oUsuario);
            foreach (Entidades.Seguridad.Perfil oPerfil in Perfiles)
            {
                if("Condiciones de Pago" == oPerfil.Formulario.Nombre)
                {
                    switch (oPerfil.Permiso.Nombre)
                    {
                        case "Agregar":
                            this.ButtonAgregar.Visible = true;
                            break;
                        case "Eliminar":
                            this.ButtonEliminar.Visible = true;
                            break;
                        case "Acceso":
                            this.gvCondiciones.Visible = true;
                            break;
                    }
                }
            }
        }
        private void CargarGrilla()
        {
            _CondicionesPago = Controladora.Sistema.ControladoraGestionarCondicionesPago.ObtenerInstancia().RecuperarCondicionesPago();
            Session.Add("_CondicionesPago", _CondicionesPago);
            gvCondiciones.DataSource = _CondicionesPago;
            gvCondiciones.DataBind();
        }
        protected void ButtonAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionarCondiciondePago.aspx");
        }
        protected void ButtonEliminar_Click(object sender, EventArgs e)
        {
            Entidades.Sistema.CondicionesPago oCondicion = (Entidades.Sistema.CondicionesPago)Session["CondicionPago"]; 
            if(oCondicion != null)
            {
                ButtonEliminar.Attributes.Add("language", "javascript"); 
                ButtonEliminar.Attributes.Add("onclick", "return confirm('¿Desea eliminar la condicion de pago que ha seleccionado?')");
                if (Controladora.Sistema.ControladoraGestionarCondicionesPago.ObtenerInstancia().EliminarCondicionPago(oCondicion))
                {
                    CargarGrilla();
                }
                else
                {
                    Mensaje = "No se puede eliminar la condicion de pago seleccionada!";
                    string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                }
            }
            else
            {
                Mensaje = "Seleccione una condicion de pago";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
        }
        protected void gvCondiciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indiceFila = gvCondiciones.SelectedIndex;
            Session.Add("CondicionPago", _CondicionesPago[indiceFila]);
        }
        protected void gvCondiciones_PageIndexChanging(object sender, GridViewPageEventArgs e) { }
        protected void ButtonBuscar_Click(object sender, EventArgs e) { }
        protected void ButtonCancelar_Click(object sender, EventArgs e) { }
    }
}


