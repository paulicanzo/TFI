using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora.Seguridad
{
    public class ControladoraGestionarPerfiles
    {
        private static ControladoraGestionarPerfiles instancia; 
        public static ControladoraGestionarPerfiles ObtenerInstancia()
        {
            if (instancia == null) instancia = new ControladoraGestionarPerfiles(); 
            return instancia;
        }
        private List<Entidades.Seguridad.Perfil> perfiles;
        private ControladoraGestionarPerfiles()
        {
            try
            {
                this.perfiles = new List<Entidades.Seguridad.Perfil>();
            }
            catch (Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
            }
        }

        public bool AgregarPerfil (Entidades.Seguridad.Perfil oPerfil, Entidades.Seguridad.Usuario usuario)
        {
            bool noEncontrado = Convert.ToBoolean(Modelo.Seguridad.Facade.Buscar(oPerfil.Grupo.Nombre, oPerfil.Formulario.Nombre, oPerfil.Permiso.Nombre));
            if (noEncontrado)
            {
                oPerfil.Usuario = usuario.Nombre;
                oPerfil.Operacion = "Agregar";
                oPerfil.Equipo = Environment.MachineName;
                oPerfil.Fecha = DateTime.Now;
                Modelo.Seguridad.Facade.Agregar(oPerfil);
                return true;
            }
            else return false;
        }

        public void EliminarPerfil(Entidades.Seguridad.Perfil oPerfil, Entidades.Seguridad.Usuario oUsuario)
        {
            try
            {
                if (Modelo.Seguridad.Facade.Eliminar(oPerfil))
                {
                    Entidades.Auditoria.AuditoriaPerfil oAuditoriaPerfil = new Entidades.Auditoria.AuditoriaPerfil();
                    oAuditoriaPerfil.Equipo = "PAU_PC";
                    oAuditoriaPerfil.Fecha = DateTime.Now;
                    oAuditoriaPerfil.Grupo = oPerfil.Grupo.Nombre;
                    oAuditoriaPerfil.Operacion = "Agregar";
                    oAuditoriaPerfil.Permiso = "Admin";
                    oAuditoriaPerfil.Formulario = oPerfil.Formulario.Nombre;
                    Modelo.Auditoria.catAuditoria.ObtenerInstancia().AgregarAuditoriaPerfil(oAuditoriaPerfil);

                    Entidades.Auditoria.AuditoriaPerfil oAPerfil = new Entidades.Auditoria.AuditoriaPerfil();
                    oAPerfil.Equipo = Environment.MachineName;
                    oAPerfil.Fecha = DateTime.Now;
                    oAPerfil.Grupo = oPerfil.Grupo.Nombre;
                    oAPerfil.Operacion = "Eliminar";
                    oAPerfil.Permiso = oPerfil.Permiso.Nombre;
                    oAPerfil.Usuario = oUsuario.NombreUsuario;
                    oAPerfil.Formulario = oPerfil.Formulario.Nombre;
                    Modelo.Auditoria.catAuditoria.ObtenerInstancia().AgregarAuditoriaPerfil(oAPerfil);

                    Modelo.Seguridad.Facade.Eliminar(oPerfil);
                }
            }
            catch (Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
            }
        }

        public List<Entidades.Seguridad.Perfil> ListarPerfiles()
        {
            List<Entidades.Seguridad.Perfil> listaPerfiles = new List<Entidades.Seguridad.Perfil>();
            try
            {
                listaPerfiles = (List<Entidades.Seguridad.Perfil>)Modelo.Seguridad.Facade.Consultar("Perfiles");
            }
            catch (Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
            }
            return listaPerfiles;
        }

        public List<Entidades.Seguridad.Grupo> RecuperarGrupo()
        {
            return (List<Entidades.Seguridad.Grupo>)Modelo.Seguridad.Facade.Consultar("Grupos");
        }
        public List<Entidades.Seguridad.Permiso> RecuperarPermiso()
        {
            return (List<Entidades.Seguridad.Permiso>)Modelo.Seguridad.Facade.Consultar("Permisos");
        }

        public List<Entidades.Seguridad.Formulario> RecuperarFormulario()
        {
            return (List<Entidades.Seguridad.Formulario>)Modelo.Seguridad.Facade.Consultar("Formularios");
        }
    }
}

