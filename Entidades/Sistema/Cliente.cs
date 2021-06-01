using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Sistema
{
    [Serializable]
    public class Cliente
    {
        private Localidad localidad; 
        public Localidad Localidad { get => localidad; set => localidad = value; }

        private int codigo; 
        public int Codigo { get => codigo; set => codigo = value; }

        private string telefono; 
        public string Telefono { get => telefono; set => telefono = value; }

        private string razonSocial; 
        public string RazonSocial { get => razonSocial; set => razonSocial = value; }

        private string titular; 
        public string Titular { get => titular; set => titular = value; }

        private string correoElectronico;
        public string CorreoElectronico { get => correoElectronico; set => correoElectronico = value; }

        private int codigoPostal; 
        public int CodigoPostal { get => codigoPostal; set => codigoPostal = value; }

        private int cuit; 
        public int Cuit { get => cuit; set => cuit = value; }

        public string tipoCliente;
        public string TipoCliente { get => tipoCliente; set => tipoCliente = value; }

        private bool estado = true; 
        public bool Estado { get => estado; set => estado = value; }

        private string direccion; 
        public string Direccion { get => direccion; set => direccion = value;  }

        private CategoriaIVA situacionFiscal;
        public CategoriaIVA SituacionFiscal { get => situacionFiscal; set => situacionFiscal = value; }

        public void CambiarEstado()
        {
            if (estado) estado = false;
            else estado = true; 
        }
        public override string ToString()
        {
            return this.RazonSocial; 
        }
    }
}
