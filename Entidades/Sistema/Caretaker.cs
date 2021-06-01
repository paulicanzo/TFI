using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Sistema
{
    public class Caretaker
    {
        private List<Memento> Mementos; 
        public List<Memento> Memento { get => Mementos; }
        
        public Caretaker()
        {
            Mementos = new List<Memento>(); 
        }
        public void AgregarMemento (Entidades.Sistema.Memento Memento)
        {
            Mementos.Add(Memento); 
        }
        public Memento QuitarMemento()
        {
            int indice = Mementos.Count - 1;
            if (indice >= 0)
            {
                Entidades.Sistema.Memento Memento = Mementos[indice];
                Mementos.RemoveAt(indice);
                return Memento;
            }
            else return null; 
        }
    }
}
