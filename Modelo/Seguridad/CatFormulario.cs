using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo.Seguridad
{
    class CatFormulario
    {
        private static CatFormulario instancia;
        private List<Entidades.Seguridad.Formulario> formularios; 

        public static CatFormulario ObtenerInstancia()
        {
            if (instancia == null) instancia = new CatFormulario();
            return instancia; 
        }

        private CatFormulario()
        {
            this.formularios = new List<Entidades.Seguridad.Formulario>();
            this.formularios = Mapping.Seguridad.MappingFormularios.RecuperarFormulario();
           
        }

        public List<Entidades.Seguridad.Formulario> ConsultarFormularios()
        {
            return this.formularios.OrderBy(x => x.Nombre).ToList(); 
        }
    }
}
