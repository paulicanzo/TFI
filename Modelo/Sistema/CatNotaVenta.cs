using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo.Sistema
{
    public class CatNotaVenta
    {
        private static CatNotaVenta instancia;
        private List<Entidades.Sistema.NotaVenta> notaVenta; 

        public static CatNotaVenta ObtenerInstancia()
        {
            if (instancia == null) instancia = new CatNotaVenta();
            return instancia; 
        }

        public CatNotaVenta()
        {
            this.notaVenta = new List<Entidades.Sistema.NotaVenta>();
            this.notaVenta = Mapping.Sistema.MappingNotaVenta.RecuperarNotaVenta();
        }

        public List<Entidades.Sistema.NotaVenta> ConsultarNotaVenta()
        {
            return this.notaVenta.OrderBy(x => x.NroNotaVenta).ToList();
        }
        
        public Entidades.Sistema.NotaVenta BuscarNotaVenta(Entidades.Sistema.NotaVenta NV)
        {
            return this.notaVenta.Find(nota => nota.NroNotaVenta == NV.NroNotaVenta); 
        }

        public bool AgregarNotaVenta(Entidades.Sistema.NotaVenta NV)
        {
            Mapping.Sistema.MappingNotaVenta.AgregarNotaVenta(NV);
            if (!notaVenta.Contains(NV))
            {
                notaVenta.Add(NV);
                return true;
            }
            else return false; 
        }

        public void AnularNotaVenta(Entidades.Sistema.NotaVenta NV)
        {
            NV.Estado = "Anulada";
            Mapping.Sistema.MappingNotaVenta.AnularNotaVenta(NV); 
        }

        public void FinalizarNotaVenta(Entidades.Sistema.NotaVenta NV)
        {
            NV.Estado = "Finalizada";
            Mapping.Sistema.MappingNotaVenta.FinalizarNotaVenta(NV);
        }

        public List<Entidades.Sistema.NotaVenta> FiltrarNotaVenta(string criterio)
        {
            return this.notaVenta.FindAll(oNT => oNT.Cliente.ToString().ToLower().Contains(criterio.ToLower()) || oNT.Estado.ToString().ToLower().Contains(criterio.ToLower()) || oNT.Fecha.ToString().ToLower().Contains(criterio.ToLower()));
        }

    }
}
