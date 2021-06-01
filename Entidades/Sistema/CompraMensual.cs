using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Sistema
{
    [Serializable]
    public class CompraMensual
    {
        private decimal monto; 
        public decimal Monto { get => monto; set => monto = value; }

        private string denominacionLegal; 
        public string DenominacionLegal { get => denominacionLegal; set => denominacionLegal = value; }
    }
}
