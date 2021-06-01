using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Modelo.Sistema
{
    public class CatCondicionesPago
    {
        private static CatCondicionesPago instancia;
        private List<Entidades.Sistema.CondicionesPago> condicionesPago; 

        public static CatCondicionesPago ObtenerInstancia()
        {
            if (instancia == null) instancia = new CatCondicionesPago();
            return instancia; 
        }

        private CatCondicionesPago()
        {
            this.condicionesPago = new List<Entidades.Sistema.CondicionesPago>();
            this.condicionesPago = Mapping.Sistema.MappingCondicionesPago.ObtenerInstancia().Recuperar();
        }

        public List<Entidades.Sistema.CondicionesPago> ConsultarCondicionesPago()
        {
            return this.condicionesPago.OrderBy(x => x.Nombre).ToList(); 
        }

        public Entidades.Sistema.CondicionesPago BuscarCondicionPago(string nombre)
        {
            return this.condicionesPago.Find(oCondicionPago => oCondicionPago.Nombre.ToLower() == nombre.ToLower());
        }

        public bool AgregarCondicionesPago(Entidades.Sistema.CondicionesPago condPago)
        {
            Mapping.Sistema.MappingCondicionesPago.AgregarCondicionesPago(condPago);
            if (!condicionesPago.Contains(condPago))
            {
                condicionesPago.Add(condPago);
                return true;
            }
            else return false;
        }

        public bool EliminarCondicionesPago(Entidades.Sistema.CondicionesPago oCondicionesPago)
        {
            bool resultado;
            resultado = Mapping.Sistema.MappingCondicionesPago.EliminarCondicionesPago(oCondicionesPago);
            return resultado; 
        }
    }
}
