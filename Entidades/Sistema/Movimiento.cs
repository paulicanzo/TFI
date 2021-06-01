using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Sistema
{
    [Serializable]
    public class Movimiento
    {
        public Movimiento() { }
        private decimal monto; 
        public decimal Monto
        {
            get { return monto; }
            set
            {
                if (tipo == MovimientoTipo.Egreso) monto = value * -1;
                else monto = value; 
            }
        }
        public enum MovimientoTipo { Ingreso, Egreso };
        private MovimientoTipo tipo; 
        public MovimientoTipo Tipo { get => tipo; set => tipo = value; }

        private string concepto; 
        public string Concepto { get => concepto; set => concepto = value; }

        private DateTime fecha; 
        public DateTime Fecha { get => fecha; set => fecha = value; }

        private CondicionesPago formaPago; 
        public CondicionesPago FormaPago { get => formaPago; set => formaPago = value; }

        private int comprobanteAbonado; 
        public int ComprobanteAbonado { get => comprobanteAbonado; set => comprobanteAbonado = value;  }
    }
}
