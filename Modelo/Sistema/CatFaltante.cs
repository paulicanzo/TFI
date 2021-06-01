using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo.Sistema
{
    public class CatFaltante
    {
        private static CatFaltante instancia;
        private List<Entidades.Sistema.Faltante> faltante; 

        public static CatFaltante ObtenerInstancia()
        {
            if (instancia == null) instancia = new CatFaltante();
            return instancia;
        }

        private CatFaltante()
        {
            this.faltante = new List<Entidades.Sistema.Faltante>();
            this.faltante = Mapping.Sistema.MappingFaltante.RecuperarFaltante();
        }

        public bool AgregarFaltante(Entidades.Sistema.Faltante oFaltante)
        {
            if (!faltante.Contains(oFaltante))
            {
                faltante.Add(oFaltante);
                return true;
            }
            else return false;
        }

        public Entidades.Sistema.Faltante ConsultarFaltante(int nroOC)
        {
            return this.faltante.Find(Faltante => Faltante.NroOrdenCompra == nroOC); 
        }

        public Entidades.Sistema.Faltante BuscarFaltante(Entidades.Sistema.Faltante oFaltante)
        {
            return this.faltante.Find(Faltante => Faltante.NroOrdenCompra == oFaltante.NroOrdenCompra);
        }

        public List<Entidades.Sistema.Faltante> RecuperarFaltante()
        {
            return this.faltante.OrderBy(x => x.NroOrdenCompra).ToList();
        }

        public bool ModificarFaltante(Entidades.Sistema.Faltante oFaltante)
        {
            Mapping.Sistema.MappingFaltante.ModificarFaltante(oFaltante);
            faltante.Remove(oFaltante);
            faltante.Add(oFaltante);
            if (faltante.Contains(oFaltante)) return true; 
            else return false; 
        }
    }
}

