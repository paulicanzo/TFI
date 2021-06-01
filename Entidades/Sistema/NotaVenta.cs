using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Sistema
{
    [Serializable]
    public class NotaVenta
    {
        public NotaVenta() { lineaNotaVenta = new List<LineaNotaVenta>(); }

        private int nroNotaVenta; 
        public int NroNotaVenta { get => nroNotaVenta; set => nroNotaVenta = value; }

        private DateTime fecha; 
        public DateTime Fecha { get => fecha; set => fecha = value; }

        private Cliente cliente; 
        public Cliente Cliente { get => cliente; set => cliente = value; }

        private int cantidad; 
        public int Cantidad { get => cantidad; set => cantidad = value; }

        private decimal precioTotal; 
        public decimal PrecioTotal { get => precioTotal; set => precioTotal = value; }

        private string estado; 
        public string Estado { get => estado; set => estado = value; }

        private List<LineaNotaVenta> lineaNotaVenta; 
        public List<LineaNotaVenta> LineaNotaVenta { get => lineaNotaVenta; }

        public bool AgregarLineaNotaVenta(Entidades.Sistema.LineaNotaVenta LNT)
        {
            if (lineaNotaVenta.Find(x => x.Producto == LNT.Producto) == null)
            {
                precioTotal = precioTotal + LNT.Subtotal;
                lineaNotaVenta.Add(LNT);
                return true;
            }
            else return false; 
        }
        public void QuitarLineaNotaVenta(Entidades.Sistema.LineaNotaVenta LNT)
        {
            precioTotal = precioTotal - LNT.Subtotal;
            lineaNotaVenta.Remove(LNT); 
        }
        public override string ToString()
        {
            return nroNotaVenta.ToString();
        }
        public Memento CrearMemento()
        {
            return new Memento(this); 
        }
        public void setMemento(Entidades.Sistema.Memento Memento)
        {
            this.cantidad = Memento.NotaVenta.cantidad;
            this.cliente = Memento.NotaVenta.cliente;
            this.estado = Memento.NotaVenta.estado;
            this.fecha = Memento.NotaVenta.fecha;
            this.lineaNotaVenta = Memento.NotaVenta.lineaNotaVenta;
            this.nroNotaVenta = Memento.NotaVenta.nroNotaVenta;
            this.precioTotal = Memento.NotaVenta.precioTotal; 
        }

    }
}
