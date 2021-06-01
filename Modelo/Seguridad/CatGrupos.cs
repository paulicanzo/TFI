using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo.Seguridad
{
    class CatGrupos
    {
        private static CatGrupos instancia;
        private List<Entidades.Seguridad.Grupo> grupos; 

        public static CatGrupos ObtenerInstancia()
        {
            if (instancia == null) instancia = new CatGrupos();
            return instancia; 
        }

        private CatGrupos()
        {
            this.grupos = new List<Entidades.Seguridad.Grupo>();
            this.grupos = Mapping.Seguridad.MappingGrupos.RecuperarGrupos();
        }

        public List<Entidades.Seguridad.Grupo> ConsultarGrupo()
        {
            return this.grupos.OrderBy(x => x.Nombre).ToList(); 
        }

        public Entidades.Seguridad.Grupo BuscarGrupo(string nombreGrupo)
        {
            return this.grupos.Find(oGrupo => oGrupo.Nombre == nombreGrupo.ToLower());
        }

        public bool AgregarGrupo (Entidades.Seguridad.Grupo oGrupo)
        {
            Mapping.Seguridad.MappingGrupos.AgregarGrupo(oGrupo);
            if (!grupos.Contains(oGrupo))
            {
                grupos.Add(oGrupo);
                return true;
            }
            else return false;
        }

        public bool EliminarGrupo(Entidades.Seguridad.Grupo oGrupo)
        {
            Mapping.Seguridad.MappingGrupos.EliminarGrupo(oGrupo);
            Entidades.Seguridad.Grupo grupo = this.BuscarGrupo(oGrupo.Nombre);
            if (grupo != null)
            {
                this.grupos.Remove(oGrupo);
                return true;
            }
            else return false;
        }

        public bool ModificarGrupo(Entidades.Seguridad.Grupo oGrupo)
        {
            Mapping.Seguridad.MappingGrupos.ModificarGrupo(oGrupo);
            Entidades.Seguridad.Grupo grupo = this.BuscarGrupo(oGrupo.Nombre);
            if (oGrupo != null)
            {
                this.grupos.Remove(grupo);
                this.grupos.Add(oGrupo);
                return true;
            }
            else return false;
        }

        public List<Entidades.Seguridad.Grupo> FiltrarGrupos(string nombreGrupo)
        {
            return this.grupos.FindAll(oGrupo => oGrupo.Nombre.ToLower().Contains(nombreGrupo.ToLower()));
        }
    }
}
