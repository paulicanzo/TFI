using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo.Sistema
{
    public class CatOrdenCompra
    {
        private static CatOrdenCompra instancia;
        private List<Entidades.Sistema.OrdenCompra> ordenCompra; 

        public static CatOrdenCompra ObtenerInstancia()
        {
            if (instancia == null) instancia = new CatOrdenCompra();
            return instancia;

        }

        private CatOrdenCompra()
        {
            this.ordenCompra = new List<Entidades.Sistema.OrdenCompra>();
            this.ordenCompra = Mapping.Sistema.MappingOrdenCompra.ObtenerInstancia().Recuperar(); 
        }

        public List<Entidades.Sistema.OrdenCompra> ConsultarOrdenCompra()
        {
            return this.ordenCompra.OrderBy(x => x.FechaEmision).ToList(); 
        }

        public Entidades.Sistema.OrdenCompra BuscarOrden(Entidades.Sistema.OrdenCompra oOrdenCompra)
        {
            return this.ordenCompra.Find(orden => orden.NroOrdenCompra == oOrdenCompra.NroOrdenCompra); 
        }

        public bool AgregarOrdenCompra(Entidades.Sistema.OrdenCompra oOrdenCompra)
        {
            Mapping.Sistema.MappingOrdenCompra.AgregarOrdenCompra(oOrdenCompra);
            if (!ordenCompra.Contains(oOrdenCompra))
            {
                ordenCompra.Add(oOrdenCompra);
                return true;
            }
            else return false; 
        }

        public void AnularOrdenCompra(Entidades.Sistema.OrdenCompra oOrdenCompra)
        {
            oOrdenCompra.Estado = "Anulada";
            Mapping.Sistema.MappingOrdenCompra.AnularCompra(oOrdenCompra);
        }

        public List<Entidades.Sistema.OrdenCompra> ConsultarProducto()
        {
            return this.ordenCompra.OrderBy(x => x.FechaEmision).ToList(); 
        }

        public List<Entidades.Sistema.OrdenCompra> FiltrarUsuarios(string criterio)
        {
            return this.ordenCompra.FindAll(OC => OC.Proveedor.ToString().ToLower().Contains(criterio.ToLower()) || OC.FechaEmision.ToShortDateString().ToLower().Contains(criterio.ToLower()) || OC.FechaRecepcionMercaderia.ToShortDateString().ToLower().Contains(criterio.ToLower()) || OC.Estado.ToString().ToLower().Contains(criterio.ToLower()));
        }
    }
}
