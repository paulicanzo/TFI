using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Sistema
{
    public partial class GestionarProveedor : System.Web.UI.Page
    {
        List<Entidades.Sistema.CondicionesPago> _codicionesPago;
        Entidades.Sistema.CondicionesPago condicionPago;
        List<Entidades.Sistema.CategoriaIVA> _categoriasIVA;
        List<Entidades.Sistema.Provinicia> _provincias;
        List<Entidades.Sistema.Localidad> _localidades;
        Entidades.Seguridad.Usuario oUsuario;
        Entidades.Sistema.Proveedor Proveedor;
        string _operacion;
        string Mensaje; 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarCombos();
                condicionPago = (Entidades.Sistema.CondicionesPago)Session["condicionPago"];
                _codicionesPago = (List<Entidades.Sistema.CondicionesPago>)Session["_condicionesPago"];
                _operacion = Session["OpcionProveedor"].ToString(); 

                if(_operacion == "Modificar")
                {
                    Proveedor = (Entidades.Sistema.Proveedor)Session["Proveedor"];
                    PrepararFormModificar();
                }
                if(_operacion == "Consultar")
                {
                    BtnGuardar.Enabled = false;
                    this.txtTitular.Enabled = false;
                    this.txtCuit.Enabled = false;
                    this.txtDenominacion.Enabled = false;
                    this.txtDireccion.Enabled = false;
                    this.txtCodPostal.Enabled = false;
                    this.txtTelefono.Enabled = false;
                    this.txtEncargado.Enabled = false;
                    this.txtIngresosBrutos.Enabled = false;
                    this.txtEmail.Enabled = false;
                    PrepararFormModificar();
                }
            }
            else
            {
                _operacion = Session["OpcionProveedor"].ToString();
                Proveedor = (Entidades.Sistema.Proveedor)Session["Proveedor"];
                oUsuario = (Entidades.Seguridad.Usuario)Session["Usuarios"]; 
                if(_operacion == "Modificar")
                {
                    Proveedor = (Entidades.Sistema.Proveedor)Session["Proveedor"];
                    this.txtCuit.Enabled = false;
                    CargarCombos();
                }
                else if(_operacion == "Agregar")
                {
                    ListarCondiciones();
                    Proveedor = new Entidades.Sistema.Proveedor();
                    Session.Add("Proveedor", Proveedor);
                }
            }
        }
        private void ListarCondiciones()
        {
            _codicionesPago = Controladora.Sistema.ControladoraGestionarProveedores.ObtenerInstancia().RecuperarCondicionesPago();
            lbCondiciones.DataSource = _codicionesPago;
            lbCondiciones.DataBind();
        }
        private void CargarCombos()
        {
            //se carga el combo de categoriaIVA
            _categoriasIVA = Controladora.Sistema.ControladoraGestionarProveedores.ObtenerInstancia().RecuperarCategoriaIVA();
            ddIVA.DataSource = _categoriasIVA;
            ddIVA.DataMember = "Nombre";
            ddIVA.DataBind();

            // se cargan las condiciones de pago.
            lbTodasCondiciones.DataSource = Controladora.Sistema.ControladoraGestionarProveedores.ObtenerInstancia().RecuperarCondicionesPago();
            lbCondiciones.DataBind();

            // se cargan todas las provincias. 
            _provincias = Controladora.Sistema.ControladoraGestionarProveedores.ObtenerInstancia().RecuperarProvincias();
            ddlProvincia.DataSource = _provincias;
            ddlProvincia.DataMember = "Nombre";
            ddlProvincia.DataBind();

            int indice = this.ddlProvincia.SelectedIndex;
        }
        private void PrepararFormModificar()
        {

            this.txtTitular.Text = Proveedor.Titular.ToString();
            this.txtCuit.Text = Proveedor.Cuit.ToString();
            this.txtDenominacion.Text = Proveedor.DenominacionLegal;
            this.txtDireccion.Text = Proveedor.Direccion;
            this.txtCodPostal.Text = (Proveedor.CodigoPostal).ToString();
            this.txtTelefono.Text = Proveedor.Telefono;
            this.txtEncargado.Text = Proveedor.Encargado;
            this.txtIngresosBrutos.Text = (Proveedor.IngresosBrutos).ToString();
            this.txtEmail.Text = Proveedor.CorreoElectronico;

            string indiceProvincia = Proveedor.Localidad.Provincia.Nombre;
            string indiceLocalidad = Proveedor.Localidad.Nombre;
            this.ddlCiudad.Text = indiceLocalidad;
            this.ddlProvincia.Text = indiceProvincia;

            string indiceIVA = Proveedor.CategoriaIVA.Nombre;
            this.ddIVA.Text = indiceIVA;
        }
        protected void ddLocalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCiudad.Items.Clear();
            int indice = this.ddlProvincia.SelectedIndex;
            ddlCiudad.DataSource = _provincias[indice - 1].Localidad;
            ddlCiudad.DataMember = "Localidad.Nombre";
            ddlCiudad.DataBind();
        }
        protected void BtnFiltrar_Click(object sender, EventArgs e) { }
        protected void BtnAgregar_Click(object sender, EventArgs e) { }
        protected void BtnModificar_Click(object sender, EventArgs e) { }
        protected void BtnEliminar_Click(object sender, EventArgs e) { }
        protected void BtnConsultar_Click(object sender, EventArgs e) { }
        protected void gvProveedores_PageIndexChanging(object sender, GridViewPageEventArgs e) { }
        protected void gvProveedores_SelectedIndexChanged(object sender, EventArgs e) { }
        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nombre = ddlProvincia.SelectedValue;
            int indice = ddlProvincia.SelectedIndex;
            Entidades.Sistema.Provinicia prov = Controladora.Sistema.ControladoraGestionarProveedores.ObtenerInstancia().RecuperarProvincias().Find(x => x.Nombre == nombre);

            ddlCiudad.DataSource = prov.Localidad;
            ddlCiudad.DataMember = "Ciudades.Nombre";
            ddlCiudad.DataBind();
        }
        protected void BtnGuardar_Click(object sender, EventArgs e) { }
        protected void BtnCancelar_Click(object sender, EventArgs e) { }
        protected void ddIVA_SelectedIndexChanged(object sender, EventArgs e) { }
        protected void BtnGuardar_Click1(object sender, EventArgs e)
        {
           if(_operacion == "Modificar")
            {
                this.txtTitular.Enabled = false;
                this.txtCuit.Enabled = false;

                Proveedor.IngresosBrutos = Convert.ToInt32(txtIngresosBrutos.Text);

                string _Ciudad = ddlCiudad.SelectedItem.Value;
                int indicelocalidad = ddlCiudad.SelectedIndex;
                int indice = ddlProvincia.SelectedIndex;
                Entidades.Sistema.Provinicia prov = _provincias[indice];
                Entidades.Sistema.Localidad oLoca = prov.Localidad[indicelocalidad];
                Proveedor.Localidad = oLoca;
                Proveedor.CodigoPostal = Convert.ToInt32(txtCodPostal.Text);
                Proveedor.Cuit = Convert.ToInt32(txtCuit.Text);
                Proveedor.Direccion = txtDireccion.Text;
                Proveedor.CorreoElectronico = txtEmail.Text;
                Proveedor.Encargado = txtEncargado.Text;

                Proveedor.Titular = txtTitular.Text;
                Proveedor.Telefono = txtTelefono.Text;
                string _TipoIva = ddIVA.SelectedItem.Value;
                Proveedor.CategoriaIVA = _categoriasIVA.Find(x => x.Nombre == _TipoIva);
                bool res;
                if (res = Controladora.Sistema.ControladoraGestionarProveedores.ObtenerInstancia().ModificarProveedor(Proveedor))
                {
                    Mensaje = "El proveedor " + txtDenominacion.Text + " se ha modificado correctamente";
                    string script = @"<script type='text/javascript'>alert('" + Mensaje + "');window.location='FrmGestionarProveedores.aspx'</script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                }
            }
           if(_operacion == "Agregar")
            {
                Proveedor.IngresosBrutos = Convert.ToInt32(txtIngresosBrutos.Text);
                string _Ciudad = ddlCiudad.SelectedItem.Value;
                int indicelocalidad = ddlCiudad.SelectedIndex;
                int indice = ddlProvincia.SelectedIndex;
                Entidades.Sistema.Provinicia prov = _provincias[indice];
                Entidades.Sistema.Localidad oCiudad = prov.Localidad[indicelocalidad];
                Proveedor.Localidad = oCiudad;
                Proveedor.CodigoPostal = Convert.ToInt32(txtCodPostal.Text);
                Proveedor.Cuit = Convert.ToInt32(txtCuit.Text);
                Proveedor.Direccion = txtDireccion.Text;
                Proveedor.CorreoElectronico = txtEmail.Text;
                Proveedor.Encargado = txtEncargado.Text;

                Proveedor.Titular = txtTitular.Text;
                Proveedor.Telefono = txtTelefono.Text;
                string _TipoIva = ddIVA.SelectedItem.Value;
                Proveedor.CategoriaIVA = _categoriasIVA.Find(Z => Z.Nombre == _TipoIva);

                if (Controladora.Sistema.ControladoraGestionarProveedores.ObtenerInstancia().AgregarProveedor(Proveedor))
                {
                    Mensaje = "El proveedor " + txtDenominacion.Text + " se agregó correctamente";
                    string script = @"<script type='text/javascript'>alert('" + Mensaje + "');window.location='FrmGestionarProveedores.aspx'</script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                }
                Response.Redirect("GestionarProveedores.aspx");
            }
        }
        protected void BtnCancelar_Click1(object sender, EventArgs e)
        {
            Response.Redirect("GestionarProveedores.aspx");
        }
        protected void lbCondiciones_SelectedIndexChanged(object sender, EventArgs e) { }
        protected void Asignar_Click(object sender, EventArgs e)
        {
            if (!lbCondiciones.Items.Contains(lbTodasCondiciones.SelectedItem))
            {
                if(_operacion == "Agregar")
                {
                    Proveedor = (Entidades.Sistema.Proveedor)Session["Proveedor"]; 
                }
                else if(_operacion == "Modificar")
                {
                    Proveedor = (Entidades.Sistema.Proveedor)Session["Proveedor"];
                }
                int indice = (lbTodasCondiciones.SelectedIndex) + 1;
                Proveedor.AgregarCondicionPago(_codicionesPago[indice]);
                lbCondiciones.DataSource = null;
                lbCondiciones.DataSource = Proveedor.CondicionesPago;
                lbCondiciones.DataBind();
            }
            else
            {
                lbCondiciones.DataSource = null;
                int indice = lbTodasCondiciones.SelectedIndex;
                Entidades.Sistema.CondicionesPago Condiciones = _codicionesPago[indice];
                Mensaje = "La Condiciones de Pago " + Condiciones.Nombre + " ya esta asociado";
                string script = @"<script type='text/javascript'>alert('" + Mensaje + "');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
        }
        protected void Quitar_Click(object sender, EventArgs e)
        {
            if(_operacion == "Agregar")
            {
                Proveedor = (Entidades.Sistema.Proveedor)Session["Proveedor"]; 
            }
            else if(_operacion == "Modificar")
            {
                Proveedor = (Entidades.Sistema.Proveedor)Session["Proveedor"]; 
            }
            int indice = (lbTodasCondiciones.SelectedIndex) + 1;
            Proveedor.EliminarCondicionPago(_codicionesPago[indice]);
            lbCondiciones.DataSource = null;
            lbCondiciones.DataSource = Proveedor.CondicionesPago;
            lbCondiciones.DataBind();
        }
        protected void lbTodasCondiciones_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}
