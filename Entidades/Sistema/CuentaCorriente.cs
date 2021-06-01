using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Sistema
{
    public class CuentaCorriente
    {
        public CuentaCorriente()
        {
            movimiento = new List<Movimiento>();
        }
        private Cliente cliente; 
        public Cliente Cliente { get => cliente; set => cliente = value; }
        private int codigo; 
        public int Codigo { get => codigo; set => codigo = value; }

        private List<Movimiento> movimiento; 
        public List<Movimiento> Movimiento { get => movimiento; }

        private decimal saldo; 
        public decimal Saldo { get => saldo; set => saldo = value;  }

        public void AgregarMovimiento(Entidades.Sistema.Movimiento Movimiento)
        {
            saldo = saldo + Movimiento.Monto;
            movimiento.Add(Movimiento); 
        }
        public void RestarMovimiento (Entidades.Sistema.Movimiento Movimiento)
        {
            saldo = saldo + Movimiento.Monto;
            movimiento.Add(Movimiento); 
        }

        public override string ToString()
        {
            return Convert.ToString(Cliente); 
        }
    }
}
