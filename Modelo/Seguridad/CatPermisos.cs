using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo.Seguridad
{
    class CatPermisos
    {
        private static CatPermisos instancia;
        private List<Entidades.Seguridad.Permiso> permisos; 

        public static CatPermisos ObtenerInstancia()
        {
            if (instancia == null) instancia = new CatPermisos();
            return instancia; 
        }

        private CatPermisos()
        {
            this.permisos = new List<Entidades.Seguridad.Permiso>();
            this.permisos = Mapping.Seguridad.MappingPermisos.RecuperarPermiso(); 
        }

        public List<Entidades.Seguridad.Permiso> ConsultarPermiso()
        {
            return this.permisos.OrderBy(x => x.Nombre).ToList(); 
        }
    }
}
