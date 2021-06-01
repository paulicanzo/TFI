using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Seguridad
{
    public partial class MDSGestionarUsuario : System.Web.UI.Page
    {
        Entidades.Seguridad.Usuario GestionarUsuario;
        Entidades.Seguridad.Usuario oUsuario;
        string _Operacion;
        List<Entidades.Seguridad.Grupo> _Grupos;
        Entidades.Seguridad.Grupo Grupo;
        Entidades.Seguridad.Usuario UsuarioCreado;
        string Mensaje;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                oUsuario = (Entidades.Seguridad.Usuario)Session["Usuario"];
                Grupo = (Entidades.Seguridad.Grupo)Session["Grupo"];
                _Grupos = (List<Entidades.Seguridad.Grupo>)Session["_Grupos"];
                UsuarioCreado = (Entidades.Seguridad.Usuario)Session["UsuarioCreado"];
                _Operacion = Session["OpcionUsuario"].ToString();
            }
            else
            {
                _Operacion = Session["OpcionUsuario"].ToString();
                oUsuario = (Entidades.Seguridad.Usuario)Session["Usuario"]; 

                if(_Operacion == "Modificar")
                {
                    this.txtNombreUsuario.Enabled = false;
                    ListarTodosGrupos();
                    CargarCampos();
                }
                else if(_Operacion == "Agregar")
                {
                    ListarTodosGrupos();
                    UsuarioCreado = new Entidades.Seguridad.Usuario();
                    Session.Add("UsuarioCreado", UsuarioCreado);
                }
            }
        }
        public void CargarCampos()
        {
            GestionarUsuario = (Entidades.Seguridad.Usuario)Session["GestionarUsuario"];
            this.txtNombre.Text = GestionarUsuario.Nombre;
            this.txtNombreUsuario.Text = GestionarUsuario.NombreUsuario;
            this.txtCorreoElectronico.Text = GestionarUsuario.CorreoElectronico;
            this.txtApellido.Text = GestionarUsuario.Apellido;

            CargarGrupos();
        }
        public void CargarGrupos()
        {
            _Grupos = oUsuario.Grupos;
            Session.Add("_Grupos", _Grupos);
            ddlGrupos.DataSource = _Grupos;
            ddlGrupos.DataBind();
        }
        public void ListarTodosGrupos()
        {
            _Grupos = Controladora.Seguridad.ControladoraGestionarGrupos.ObtenerInstancia().RecuperarGrupos();
            Session.Add("_Grupos", _Grupos);
            lbGrupos.DataSource = _Grupos;
            lbGrupos.DataBind();
        }
        protected void Aceptar_Click(object sender, EventArgs e) { }
        protected void Cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("MDSGestionarUsuarios.aspx");
        }
        protected void Asignar_Click(object sender, EventArgs e)
        {
            if (!ddlGrupos.Items.Contains(lbGrupos.SelectedItem))
            {
                if(_Operacion == "Agregar")
                {
                    oUsuario = (Entidades.Seguridad.Usuario)Session["UsuarioCreado"];
                }
                else if (_Operacion == "Modificar")
                {
                    oUsuario = (Entidades.Seguridad.Usuario)Session["Usuario"];
                }
                int indice = lbGrupos.SelectedIndex;
                oUsuario.AgregarGrupo(_Grupos[indice]);
                ddlGrupos.DataSource = null;
                ddlGrupos.DataSource = oUsuario.Grupos;
                ddlGrupos.DataBind();
            }
            else
            {
                ddlGrupos.DataSource = null;
                int indice = lbGrupos.SelectedIndex;
                Entidades.Seguridad.Grupo grupo = _Grupos[indice];
                Mensaje = "El grupo " + grupo.Nombre + " ya está asociado";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
        }
        protected void Quitar_Click(object sender, EventArgs e)
        {
            if(_Operacion == "Agregar")
            {
                oUsuario = (Entidades.Seguridad.Usuario)Session["UsuarioCreado"]; 
            }
            else if(_Operacion == "Modificar")
            {
                oUsuario = (Entidades.Seguridad.Usuario)Session["Usuario"];
            }
            int indice = lbGrupos.SelectedIndex;
            oUsuario.EliminarGrupo(_Grupos[indice]);
            ddlGrupos.DataSource = null;
            ddlGrupos.DataSource = oUsuario.Grupos;
            ddlGrupos.DataBind();
        }
        protected void ddlGrupos_SelectedIndexChanged(object sender, EventArgs e) { }
        protected void lbGrupos_SelectedIndexChanged(object sender, EventArgs e) { }
        protected void btnAceptar_Click(object sender, EventArgs e) { }
        protected void Button1_Click(object sender, EventArgs e) { }
        protected void btnAceptar_Click1(object sender, EventArgs e) { }
        protected void ButtonAceptarusuario_Click(object sender, EventArgs e)
        {
            _Operacion = Session["OpcionUsuario"].ToString(); 
            if(_Operacion == "Modificar")
            {
                if (Validar())
                {
                    oUsuario.Nombre = txtNombre.Text;
                    oUsuario.Apellido = txtApellido.Text;
                    oUsuario.NombreUsuario = txtNombreUsuario.Text;
                    oUsuario.CorreoElectronico = txtCorreoElectronico.Text;
                    if (Controladora.Seguridad.ControladoraGestionarUsuarios.ObtenerInstancia().ModificarUsuario(oUsuario))
                    {
                        Mensaje = "El usuario " + txtNombreUsuario.Text + " se modificó correctamente";
                        string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                        Response.Redirect("MDSGestionarUsuarios.aspx");
                    }
                }
            }
            else if(_Operacion == "Agregar")
            {
                if (Validar())
                {
                    oUsuario = (Entidades.Seguridad.Usuario)Session["UsuarioCreado"];
                    oUsuario.Nombre = txtNombre.Text;
                    oUsuario.Apellido = txtApellido.Text;
                    oUsuario.NombreUsuario = txtNombreUsuario.Text;
                    oUsuario.CorreoElectronico = txtCorreoElectronico.Text;
                    if (Controladora.Seguridad.ControladoraGestionarUsuarios.ObtenerInstancia().AgregarUsuario(oUsuario))
                    {
                        Mensaje = "El usuario " + txtNombreUsuario.Text + " se agregó correctamente";
                        string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                        Response.Redirect("MDSGestionarUsuarios.aspx");
                    }
                    else
                    {
                        Mensaje = "El usuario " + txtNombreUsuario.Text + " ya existe";
                        string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                        Response.Redirect("MDSGestionarUsuarios.aspx");
                    }
                }
            }
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
            if (string.IsNullOrEmpty(txtApellido.Text))
            {
                Mensaje = "Complete el Apellido!";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');window.location='WebFormLogin.aspx';</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return false;
            }
            if (string.IsNullOrEmpty(txtCorreoElectronico.Text))
            {
                Mensaje = "Complete el Correo Electronico!";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');window.location='WebFormLogin.aspx';</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return false;
            }
            if (string.IsNullOrEmpty(txtNombreUsuario.Text))
            {
                Mensaje = "Complete el NombreUsuario!";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');window.location='WebFormLogin.aspx';</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return false;
            }
            return true;
        }
    }
}
