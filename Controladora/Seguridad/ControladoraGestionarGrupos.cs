using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora.Seguridad
{
    public class ControladoraGestionarGrupos
    {
        private static ControladoraGestionarGrupos instancia; 
        public static ControladoraGestionarGrupos ObtenerInstancia()
        {
            if (instancia == null) instancia = new ControladoraGestionarGrupos();
            return instancia;
        }

        private ControladoraGestionarGrupos() { }

        public List<Entidades.Seguridad.Grupo> RecuperarGrupos()
        {
            List<Entidades.Seguridad.Grupo> oGrupos = new List<Entidades.Seguridad.Grupo>();
            try
            {
                oGrupos = (List<Entidades.Seguridad.Grupo>)Modelo.Seguridad.Facade.Consultar("Grupos"); 
            }
            catch (Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
            }
            return oGrupos;
        }

        public bool AgregarGrupo(Entidades.Seguridad.Grupo oGrupo)
        {
            try
            {
                Entidades.Seguridad.Grupo oGrupos = (Entidades.Seguridad.Grupo)Modelo.Seguridad.Facade.Buscar(oGrupo.Nombre, "Grupos"); 
                if(oGrupos == null)
                {
                    Modelo.Seguridad.Facade.Agregar(oGrupo);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex); 
            }
            return false;
        }

        public bool EliminarGrupo (Entidades.Seguridad.Grupo oGrupo)
        {
            try
            {
                foreach (Entidades.Seguridad.Perfil item in (List<Entidades.Seguridad.Perfil>)Modelo.Seguridad.Facade.Consultar("Perfiles"))
                {
                    if (item.Grupo.Nombre == oGrupo.Nombre) return false;
                }
                foreach (Entidades.Seguridad.Usuario item in (List<Entidades.Seguridad.Usuario>)Modelo.Seguridad.Facade.Consultar("Usuarios"))
                {
                    List<Entidades.Seguridad.Grupo> oGrupos = (List<Entidades.Seguridad.Grupo>)Modelo.Seguridad.Facade.Consultar("Grupos");
                    Entidades.Seguridad.Grupo grupoEncontrado = oGrupos.Find(x => x.Nombre == item.Nombre);
                    if (grupoEncontrado != null) return false;
                }
                return Modelo.Seguridad.Facade.Eliminar(oGrupo);
            }
            catch (Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
                return false;
            }
        }

        public bool ModificarGrupo(Entidades.Seguridad.Grupo oGrupo)
        {
            try
            {
                Modelo.Seguridad.Facade.Modificar(oGrupo);
                return true;
            }
            catch (Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
                return false;
            }
        }

        public void HabilitarDeshabilitar(Entidades.Seguridad.Grupo oGrupo)
        {
            try
            {
                oGrupo.CambiarEstado();
                Modelo.Seguridad.Facade.Modificar(oGrupo);
            }
            catch (Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
            }
        }

        public List<Entidades.Seguridad.Grupo> FiltrarGrupos(string criterio)
        {
            List<Entidades.Seguridad.Grupo> oGrupos = new List<Entidades.Seguridad.Grupo>();
            try
            {
                oGrupos = (List<Entidades.Seguridad.Grupo>)Modelo.Seguridad.Facade.Filtrar(criterio, "Grupos");
            }
            catch (Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
            }
            return oGrupos;
        }
    }
}
