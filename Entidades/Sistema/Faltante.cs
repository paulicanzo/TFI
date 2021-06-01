using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Sistema
{
    public class Faltante
    {
        public Faltante()
        {
            LineaFaltante = new List<LineaFaltante>(); 
        }
        private int nroOrdenCompra; 
        public int NroOrdenCompra { get => nroOrdenCompra; set => nroOrdenCompra = value; }

        private List<LineaFaltante> lineaFaltante; 
        public List<LineaFaltante> LineaFaltante { get => lineaFaltante; set => lineaFaltante = value; }

        public bool AgregarLineaFaltante(Entidades.Sistema.LineaFaltante LF)
        {
            if (lineaFaltante.Find(x => x.Producto == LF.Producto) == null)
            {
                lineaFaltante.Add(LF);
                return true;
            }
            else return false; 
        }
    }
}
