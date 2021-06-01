using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Sistema
{
    public class CatProvincias
    {
        private List<Entidades.Sistema.Provinicia> provincias;
        private static CatProvincias instancia; 

        public static CatProvincias ObtenerInstancia()
        {
            if (instancia == null) instancia = new CatProvincias();
            return instancia;
        }

        private CatProvincias()
        {
            this.provincias = new List<Entidades.Sistema.Provinicia>();
            this.provincias = Mapping.Sistema.MappingProvincias.RecuperarProvincias(); 
        }

        public List<Entidades.Sistema.Provinicia> RecuperarProvincias()
        {
            return provincias;
        }
    }
}
