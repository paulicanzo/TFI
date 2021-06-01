using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Entidades.Sistema
{
    [Serializable]
    public class Memento
    {
        private NotaVenta notaVenta; 
        public NotaVenta NotaVenta { get => notaVenta; }
        public Memento(Entidades.Sistema.NotaVenta NotaVenta)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, notaVenta);
                ms.Position = 0;
                this.notaVenta = (Entidades.Sistema.NotaVenta)formatter.Deserialize(ms); 
            }
        }
    }
}
