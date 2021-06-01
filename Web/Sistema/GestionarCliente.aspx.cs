using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Sistema
{
    public partial class GestionarCliente : System.Web.UI.Page
    {
        List<Entidades.Sistema.CategoriaIVA> _CategoriasIVA;
        Entidades.Sistema.CategoriaIVA CategoriaIVA;
        List<Entidades.Sistema.Provinicia> Provincias;
        Entidades.Sistema.Provinicia Provincia;
        List<Entidades.Sistema.Localidad> Localidades;
        Entidades.Sistema.Localidad Localidad;
        Entidades.Seguridad.Usuario oUsuario;
        Entidades.Sistema.Cliente Cliente;
        string _operacion;
        string Mensaje;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarCombos();
                _operacion = Session["OpcionCliente"].ToString();
                if (_operacion == "Modificar")
                {
                    Cliente = (Entidades.Sistema.Cliente)Session["Cliente"];
                    PrepararFormModificar();
                }
                if (_operacion == "Consultar")
                {
                    btnGuardar.Enabled = false;
                    this.txtTitular.Enabled = false;
                    this.txtCUIT.Enabled = false;
                    this.txtRazonSocial.Enabled = false;
                    this.txtDireccion.Enabled = false;
                    this.txtCodPostal.Enabled = false;
                    this.txtTelefono.Enabled = false;
                    this.ddlProvincia.Enabled = false;
                    this.ddlLocalidad.Enabled = false;
                    this.ddlIVA.Enabled = false;
                    this.ddlTipo.Enabled = false;
                    this.txtEmail.Enabled = false;
                    PrepararFormModificar();
                }
            }
            else
            {
                _operacion = Session["OpcionCliente"].ToString();
                Cliente = (Entidades.Sistema.Cliente)Session["Cliente"];
                Provincias = (List<Entidades.Sistema.Provinicia>)Session["Provincias"];
                Provincia = (Entidades.Sistema.Provinicia)Session["Provincia"];
                Localidades = (List<Entidades.Sistema.Localidad>)Session["Localidades"];
                Localidad = (Entidades.Sistema.Localidad)Session["Localidad"];
                oUsuario = (Entidades.Seguridad.Usuario)Session["Usuarios"];
                CategoriaIVA = (Entidades.Sistema.CategoriaIVA)Session["CategoriaIVA"];
                _CategoriasIVA = (List<Entidades.Sistema.CategoriaIVA>)Session["_CategoriasIVA"];
                if(_operacion == "Modificar")
                {
                    Cliente = (Entidades.Sistema.Cliente)Session["Cliente"];
                    this.txtCUIT.Enabled = false;
                    CargarCombos();
                }
                else if(_operacion == "Agregar")
                {
                    Cliente = new Entidades.Sistema.Cliente();
                    Session.Add("Cliente", Cliente);
                }
            }
        }
        private void CargarCombos()
        {
            _CategoriasIVA = Controladora.Sistema.ControladoraGestionarClientes.ObtenerInstancia().RecuperarCategoriasIVA();
            ddlIVA.DataSource = _CategoriasIVA;
            ddlIVA.DataMember = "Nombre";
            ddlIVA.DataBind();
            Session.Add("_CategoriasIVA", _CategoriasIVA);

            Provincias = Controladora.Sistema.ControladoraGestionarClientes.ObtenerInstancia().RecuperarProvincias();
            ddlProvincia.DataSource = Provincias;
            ddlProvincia.DataMember = "Nombre";
            ddlProvincia.DataBind();
            Session.Add("Provincias", Provincias);
        }
        private void PrepararFormModificar()
        {
            this.txtTitular.Text = Cliente.Titular.ToString();
            this.txtCUIT.Text = Cliente.Cuit.ToString();
            this.txtRazonSocial.Text = Cliente.RazonSocial;
            this.txtDireccion.Text = Cliente.Direccion;
            this.txtCodPostal.Text = (Cliente.CodigoPostal).ToString();
            this.txtTelefono.Text = Cliente.Telefono;
            this.txtEmail.Text = Cliente.CorreoElectronico;

            string tipo = Cliente.TipoCliente.ToString();
            this.ddlTipo.Text = tipo;

            string IVA = Cliente.SituacionFiscal.Nombre;
            this.ddlIVA.Text = IVA;

        }
        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nombre = ddlProvincia.SelectedValue;
            int indice = ddlProvincia.SelectedIndex;
            Session.Add("Provincia", Provincias[indice]);
            Entidades.Sistema.Provinicia prov = Controladora.Sistema.ControladoraGestionarClientes.ObtenerInstancia().RecuperarProvincias().Find(x => x.Nombre == nombre);

            Localidades = prov.Localidad;
            ddlLocalidad.DataSource = Localidades;
            ddlLocalidad.DataMember = "Ciudades.Nombre";
            ddlLocalidad.DataBind();
            Session.Add("Localidades", Localidades);
        }
        protected void ddIVA_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = ddlIVA.SelectedIndex;
            Session.Add("CategoriaIVA", _CategoriasIVA[indice]);
        }
        protected void lbCondiciones_SelectedIndexChanged(object sender, EventArgs e) { }
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                if(_operacion == "Modificar")
                {
                    this.txtCUIT.Enabled = false;
                    Entidades.Sistema.Provinicia prov = (Entidades.Sistema.Provinicia)Session["Provincia"];
                    Entidades.Sistema.Localidad oLocalidad = (Entidades.Sistema.Localidad)Session["Localidad"];
                    Cliente.RazonSocial = txtRazonSocial.Text;
                    Cliente.Localidad = oLocalidad;
                    Cliente.CodigoPostal = Convert.ToInt32(txtCodPostal.Text);
                    Cliente.Cuit = Convert.ToInt32(txtCUIT.Text);
                    Cliente.Direccion = txtDireccion.Text;
                    Cliente.CorreoElectronico = txtEmail.Text;
                    Cliente.Titular = txtTitular.Text;
                    Cliente.Telefono = txtTelefono.Text;
                    Entidades.Sistema.CategoriaIVA oCategoria = (Entidades.Sistema.CategoriaIVA)Session["CategoriaIVA"];
                    Cliente.SituacionFiscal = oCategoria;
                    Cliente.TipoCliente = ddlTipo.SelectedItem.Value;
                    bool res; 
                    if(res = Controladora.Sistema.ControladoraGestionarClientes.ObtenerInstancia().ModificarCliente(Cliente))
                    {
                        Mensaje = "El cliente " + txtRazonSocial.Text + " se modifico correctamente";
                        string script = @"<script type='text/javascript'>alert('" + Mensaje + "');window.location='FrmGestionarProveedores.aspx'</script>";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                    }
                }
                if(_operacion == "Agregar")
                {
                    Entidades.Sistema.Provinicia prov = (Entidades.Sistema.Provinicia)Session["Provincia"];
                    Entidades.Sistema.Localidad oLocalidad = (Entidades.Sistema.Localidad)Session["Localidad"];
                    Cliente.RazonSocial = txtRazonSocial.Text;
                    Cliente.Localidad = oLocalidad;
                    Cliente.CodigoPostal = Convert.ToInt32(txtCodPostal.Text);
                    Cliente.Cuit = Convert.ToInt32(txtCUIT.Text);
                    Cliente.Direccion = txtDireccion.Text;
                    Cliente.CorreoElectronico = txtEmail.Text;
                    Cliente.Titular = txtTitular.Text;
                    Cliente.Telefono = txtTelefono.Text;
                    Entidades.Sistema.CategoriaIVA cate = (Entidades.Sistema.CategoriaIVA)Session["CategoriaIVA"];
                    Cliente.SituacionFiscal = cate;
                    Cliente.TipoCliente = ddlTipo.SelectedItem.Value;

                    if (Controladora.Sistema.ControladoraGestionarClientes.ObtenerInstancia().AgregarCliente(Cliente))
                    {
                        Mensaje = "El cliente " + txtRazonSocial.Text + " se ha agregado correctamente!";
                        string script = @"<script type='text/javascript'>alert('" + Mensaje + "');window.location='FrmGestionarProveedores.aspx'</script>";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                    }
                    else
                    {
                        Mensaje = "Error! No se ha podido agregar el cliente";
                        string script = @"<script type='text/javascript'>alert('" + Mensaje + "');window.location='FrmGestionarProveedores.aspx'</script>";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                    }
                }
            }
        }
        private bool Validar()
        {
            if (string.IsNullOrEmpty(txtRazonSocial.Text))
            {
                Mensaje = "Ingrese la razon social del cliente";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');window.location='FrmGestionarProveedores.aspx'</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return false;
            }
            if (string.IsNullOrEmpty(txtTitular.Text))
            {
                Mensaje = "Ingrese el nombre del titular";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');window.location='FrmGestionarProveedores.aspx'</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return false;
            }
            if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                Mensaje = "Ingrese la direccion";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');window.location='FrmGestionarProveedores.aspx'</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return false;
            }
            if (string.IsNullOrEmpty(txtTelefono.Text))
            {
                Mensaje = "Ingrese el telefono";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');window.location='FrmGestionarProveedores.aspx'</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return false;
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                Mensaje = "Ingrese el correo electronico";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');window.location='FrmGestionarProveedores.aspx'</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return false;
            }
            if (string.IsNullOrEmpty(txtCodPostal.Text))
            {
                Mensaje = "Ingrese el codigo postal";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');window.location='FrmGestionarProveedores.aspx'</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return false;
            }
            if (string.IsNullOrEmpty(txtCUIT.Text))
            {
                Mensaje = "Ingrese el CUIT";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');window.location='FrmGestionarProveedores.aspx'</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return false;
            }
            if (string.IsNullOrEmpty(ddlIVA.Text))
            {
                Mensaje = "Seleccione una categoria de IVA";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');window.location='FrmGestionarProveedores.aspx'</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return false;
            }
            if (string.IsNullOrEmpty(ddlLocalidad.Text))
            {
                Mensaje = "Seleccione una localidad";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');window.location='FrmGestionarProveedores.aspx'</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return false;
            }
            if (string.IsNullOrEmpty(ddlProvincia.Text))
            {
                Mensaje = "Seleccione una provincia";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');window.location='FrmGestionarProveedores.aspx'</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return false;
            }
            if (string.IsNullOrEmpty(ddlTipo.Text))
            {
                Mensaje = "Seleccione un tipo de cliente";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');window.location='FrmGestionarProveedores.aspx'</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return false;
            }
            return true;
        }
        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionarClientes.aspx");
        }
        protected void ddTipoCliente_SelectedIndexChanged(object sender, EventArgs e) { }
        protected void ddlCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            int localidad = ddlLocalidad.SelectedIndex;
            Session.Add("Localidad", Localidades[localidad]);
        }
    }
}
