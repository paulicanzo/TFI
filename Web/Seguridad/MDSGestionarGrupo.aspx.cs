using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Seguridad
{
    public partial class MDSGestionarGrupo : System.Web.UI.Page
    {
        private Entidades.Seguridad.Grupo oGrupo;
        string _Operacion;
        public string Mensaje; 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                oGrupo = (Entidades.Seguridad.Grupo)Session["Grupo"];
            }
            else
            {
                _Operacion = Session["OpcionGrupo"].ToString(); 
                if(_Operacion == "Modificar")
                {
                    this.txtNombre.Enabled = false;
                    CargarCampos();
                }
            }
        }
        public void CargarCampos()
        {
            oGrupo = (Entidades.Seguridad.Grupo)Session["Grupo"];
            this.txtNombre.Text = oGrupo.Nombre;
            this.txtDescripcion.Text = oGrupo.Descripcion;
        }
        protected void Cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("MDSGestionarGrupos.aspx");
        }
        private bool Validar()
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                Mensaje = "Complete el nombre";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');window.location='WebFormLogin.aspx';</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return false;
            }
            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                Mensaje = "Complete la descripcion";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');window.location='WebFormLogin.aspx';</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return false;
            }
            return true;
        }
        protected void Aceptar_Click1(object sender, EventArgs e)
        {
            _Operacion = Session["OpcionGrupo"].ToString(); 
            if(_Operacion == "Modificar")
            {
                if (Validar())
                {
                    oGrupo.Nombre = txtNombre.Text;
                    oGrupo.Descripcion = txtDescripcion.Text;
                    bool resultado = Controladora.Seguridad.ControladoraGestionarGrupos.ObtenerInstancia().ModificarGrupo(oGrupo);
                    if (resultado)
                    {
                        Mensaje = "El grupo " + txtNombre.Text + " se modificó";
                        string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);
                        Response.Redirect("MDSGestionarGrupos.aspx");
                    }
                }
            }
            else
            {
                if(_Operacion == "Agregar")
                {
                    if (Validar())
                    {
                        Entidades.Seguridad.Grupo oGrupo = new Entidades.Seguridad.Grupo();
                        oGrupo.Nombre = txtNombre.Text;
                        oGrupo.Descripcion = txtDescripcion.Text;
                        bool resultado = Controladora.Seguridad.ControladoraGestionarGrupos.ObtenerInstancia().AgregarGrupo(oGrupo);
                        if (resultado)
                        {
                            Mensaje = "El grupo " + txtNombre.Text + " se agregó correctamente";
                            string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);
                            Response.Redirect("MDSGestionarGrupos.aspx");
                        }
                        else
                        {
                            Mensaje = "No se puede agregar el grupo solicitado";
                            string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);
                        }
                    }
                }
            }
        }
    }
}
