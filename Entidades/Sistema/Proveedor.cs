using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Sistema
{
    [Serializable]
    public class Proveedor
    {
        public Proveedor() { condicionesPago = new List<CondicionesPago>(); }

        private int codigo; 
        public int Codigo { get => codigo; set => codigo = value; }
        
        private Localidad localidad; 
        public Localidad Localidad { get => localidad; set => localidad = value; }

        private string telefono; 
        public string Telefono { get => telefono; set => telefono = value; }

        private string denominacionLegal; 
        public string DenominacionLegal { get => denominacionLegal; set => denominacionLegal = value; }

        private string titular; 
        public string Titular { get => titular; set => titular = value; }

        private string correoElectronico; 
        public string CorreoElectronico { get => correoElectronico; set => correoElectronico = value; }

        private int codigoPostal; 
        public int CodigoPostal { get => codigoPostal; set => codigoPostal = value;  }

        private string encargado; 
        public string Encargado { get => encargado; set => encargado = value; }

        private int cuit; 
        public int Cuit { get => cuit; set => cuit = value; }

        private int ingresosBrutos; 
        public int IngresosBrutos { get => ingresosBrutos; set => ingresosBrutos = value;  }

        private CategoriaIVA categoriaIVA; 
        public CategoriaIVA CategoriaIVA { get => categoriaIVA; set => categoriaIVA = value; }

        private List<CondicionesPago> condicionesPago; 
        public List<CondicionesPago> CondicionesPago { get => condicionesPago; set => condicionesPago = value; }

        private bool estado = true; 
        public bool Estado { get => estado; set => estado = value; }

        public void CambiarEstado()
        {
            if (estado) estado = false;
            else estado = true; 
        }
        private string direccion; 
        public string Direccion { get => direccion; set => direccion = value; }

        public void AgregarCondicionPago(Entidades.Sistema.CondicionesPago Pago)
        {
            condicionesPago.Add(Pago); 
        }
        public void EliminarCondicionPago(Entidades.Sistema.CondicionesPago Pago)
        {
            condicionesPago.Remove(Pago); 
        }
        public override string ToString()
        {
            return this.DenominacionLegal.ToString();
        }

    }
}
