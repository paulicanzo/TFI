using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Sistema
{
    [Serializable]
    public class MayoresDeudores
    {
        private string cliente; 
        public string Cliente { get => cliente; set => cliente = value; }

        private int total; 
        public int Total { get => total; set => total = value; }
    }
}
