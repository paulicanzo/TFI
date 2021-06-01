//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Data;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.HtmlControls;
//using System.Web.UI.WebControls;
//using System.Xml.Linq;

//namespace Web.Sistema
//{
//    public partial class EmpleadoBackEnd : System.Web.UI.Page
//    {
//        Entidades.Seguridad.Usuario oUsuario;
//        List<Entidades.Seguridad.Perfil> Perfiles;
//        List<Entidades.Seguridad.Menu> _Menu; 
//        protected void Page_Load(object sender, EventArgs e)
//        {
//            if (!Page.IsPostBack)
//            {
//                oUsuario = (Entidades.Seguridad.Usuario)Session["Usuario"];
//                MasterPage master = this.Master;
//                BackEnd be = (BackEnd)master;
//                be.btnCerrarSesion.Visible = true;
//                CargarPermisos();
//            }
//            else
//            {
//                oUsuario = (Entidades.Seguridad.Usuario)Session["Usuario"];
//                MasterPage master = this.Master;
//                BackEnd be = (BackEnd)master;
//            }
//        }
//        private void CancelarEtiquetas()
//        {
//            BackEnd back = (BackEnd)this.Master; 
//        }
//        private void CargarPermisos()
//        {
//            Perfiles = Controladora.Seguridad.ControladoraIniciarSesion.ObtenerInstancia().RecuperarPerfil(oUsuario);
//            foreach (var perfil in Perfiles)
//            {
//                foreach (Control item in ((BackEnd)this.Master).Controls)
//                {
//                    BackEnd back = (BackEnd)this.Master; 
//                    if(item is HtmlAnchor)
//                    {
//                        HtmlAnchor anchor = (HtmlAnchor)item;
//                        if (anchor.ID == perfil.Formulario.Nombre) anchor.Visible = true; 
//                        if("WEBPrincipal" == perfil.Formulario.Nombre)
//                        {
//                            switch (perfil.Permiso.Nombre)
//                            {
//                                case "Productos":
//                                    back.etProductos.Visible = true;
//                                    break;
//                                case "Proveedores":
//                                    back.etProveedores.Visible = true;
//                                    break;
//                                case "Categorias":
//                                    back.etCategoriaProducto.Visible = true;
//                                    break;
//                                case "Orden de Compra":
//                                    back.etOC.Visible = true;
//                                    break;
//                                case "Condiciones de Pago":
//                                    back.etCondiciones.Visible = true;
//                                default:
//                                    break;
//                            }
//                        }
//                    }
//                }
//            }
//        }
//    }
//}
