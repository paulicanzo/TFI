using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Seguridad
{
    class CatPerfiles
    {
        private static CatPerfiles instancia;
        private List<Entidades.Seguridad.Perfil> perfiles; 

        public static CatPerfiles ObtenerInstancia()
        {
            if (instancia == null) instancia = new CatPerfiles();
            return instancia;
        }
        
        private CatPerfiles()
        {
            this.perfiles = new List<Entidades.Seguridad.Perfil>();
            this.perfiles = Mapping.Seguridad.MappingPerfiles.RecuperarPerfiles(); 
        }

        public bool EliminarPerfil (Entidades.Seguridad.Perfil oPerfil)
        {
            Mapping.Seguridad.MappingPerfiles.EliminarPerfil(oPerfil);
            bool resultado = perfiles.Remove(oPerfil);
            return resultado;
        }

        public void AgregarPerfil(Entidades.Seguridad.Perfil oPerfil)
        {
            Mapping.Seguridad.MappingPerfiles.AgregarPerfiles(oPerfil);
            perfiles.Add(oPerfil); 
        }

        public List<Entidades.Seguridad.Perfil> ConsultarPerfiles() { return perfiles; }

        public bool BuscarPerfil(string nombreGrupo, string nombreFormulario, string nombrePermiso)
        {
            Entidades.Seguridad.Perfil oPerfil = perfiles.Find(perfil => perfil.Grupo.Nombre.ToLower() == nombreFormulario.ToLower() &&
                                                                         perfil.Permiso.Nombre.ToLower() == nombrePermiso.ToLower() &&
                                                                         perfil.Formulario.Nombre.ToLower() == nombreFormulario.ToLower());
            if (oPerfil == null) return true;
            else return false; 
        }
    }
}
