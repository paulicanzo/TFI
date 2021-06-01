using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Sistema
{
    public partial class GestionarCategoriaProductos : System.Web.UI.Page
    {
        private Entidades.Seguridad.Usuario oUsuario;
        string Mensaje;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Aceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                Entidades.Sistema.CategoriaProducto oCategoria = new Entidades.Sistema.CategoriaProducto();
                oCategoria.Nombre = txtNombre.Text;
                oCategoria.Descripcion = txtDescripcion.Text;
                bool resultado = Controladora.Sistema.ControladoraGestionarCategoriaProductos.ObtenerInstancia().AgregarCategoriaProducto(oCategoria);
                if (resultado)
                {
                    Mensaje = "La categoria " + txtNombre.Text + " se agrego";
                    string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);
                    Response.Redirect("/Sistema/GestionarCategoriasProductos.aspx");
                }
                else
                {
                    Mensaje = "No se ha podido agregar la categoria";
                    string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);
                }
            }
        }
        private bool Validar()
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                Mensaje = "Por favor, complete el nombre";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);
                return false;
            }
            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                Mensaje = "Por favor, inserte una descripcion";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);
                return false;
            }
            return true;
        }
        protected void Cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Sistema/GestionarCategoriasProductos.aspx");
        }
    }
}

