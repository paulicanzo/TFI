using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora.Sistema
{
    public class ControladoraReportes
    {
        private static ControladoraReportes instancia; 
        public static ControladoraReportes ObtenerInstancia()
        {
            if (instancia == null) instancia = new ControladoraReportes();
            return instancia;
        }
        
        private ControladoraReportes() { }

        public List<Entidades.Sistema.CompraMensual>RecuperarCompraMensual(DateTime desde, DateTime hasta)
        {
            List<Entidades.Sistema.CompraMensual> compraMensual = new List<Entidades.Sistema.CompraMensual>();
            try
            {
                compraMensual = Modelo.Sistema.CatReportes.ObtenerInstancia().ConsultarCompraMensual(desde, hasta); 
            }
            catch (Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
            }
            return compraMensual;
        }

        public List<Entidades.Sistema.CategoriaProducto> RecuperarCategoriaProducto()
        {
            List<Entidades.Sistema.CategoriaProducto> categoriaProducto = new List<Entidades.Sistema.CategoriaProducto>();
            try
            {
                categoriaProducto = Modelo.Sistema.CatCategoriasProducto.ObtenerInstancia().ConsultarCategoriaProducto(); 
            }
            catch (Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex); 
            }
            return categoriaProducto;
        }

        public List<Entidades.Sistema.ProductosMasVendidos> RecuperarProducto(Entidades.Sistema.CategoriaProducto categoria)
        {
            List<Entidades.Sistema.ProductosMasVendidos> Producto = new List<Entidades.Sistema.ProductosMasVendidos>();
            try
            {
                Producto = Modelo.Sistema.CatReportes.ObtenerInstancia().RecuperarProductos(categoria);
            }
            catch (Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
            }
            return Producto;
        }

        public List<Entidades.Sistema.MayoresCompradores> RecuperarMayoresCompradores()
        {
            List<Entidades.Sistema.MayoresCompradores> mayoresCompradores = new List<Entidades.Sistema.MayoresCompradores>();
            try
            {
                mayoresCompradores = Modelo.Sistema.CatReportes.ObtenerInstancia().RecuperarMayoresCompradores();
            }
            catch (Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
            }
            return mayoresCompradores;
        }

        public List<Entidades.Sistema.MayoresDeudores> RecuperarMayoresDeudores()
        {
            List<Entidades.Sistema.MayoresDeudores> mayoresDeudores = new List<Entidades.Sistema.MayoresDeudores>();
            try
            {
                mayoresDeudores = Modelo.Sistema.CatReportes.ObtenerInstancia().RecuperarMayoresDeudores();
            }
            catch (Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
            }
            return mayoresDeudores;
        }
    }
}

