using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora.Auditoria
{
    public class ControladoraAuditoria
    {
        private static ControladoraAuditoria instancia; 
        public static ControladoraAuditoria ObtenerInstancia()
        {
            if (instancia == null) instancia = new ControladoraAuditoria();
            return instancia; 
        }
        private ControladoraAuditoria() { }
        
        public List<Entidades.Auditoria.Auditoria> RecuperarAuditoria()
        {
            List<Entidades.Auditoria.Auditoria> Auditoria = new List<Entidades.Auditoria.Auditoria>();
            try
            {
                Auditoria = Modelo.Auditoria.catAuditoria.ObtenerInstancia().ConsultarAuditoriaLog();
            }
            catch (Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
            }
            return Auditoria;
        }

        public List<Entidades.Auditoria.AuditoriaPerfil> RecuperarAuditoriaPerfil()
        {
            List<Entidades.Auditoria.AuditoriaPerfil> AuditoriaPerfil = new List<Entidades.Auditoria.AuditoriaPerfil>();
            try
            {
                AuditoriaPerfil = Modelo.Auditoria.catAuditoria.ObtenerInstancia().ConsultarAuditoriaPerfiles();
            }
            catch (Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex); 
            }
            return AuditoriaPerfil;
        }

        public List<Entidades.Auditoria.AuditoriaOrdenCompra> RecuperarAuditoriaOrdenCompra()
        {
            List<Entidades.Auditoria.AuditoriaOrdenCompra> AuditoriaOrdenCompra = new List<Entidades.Auditoria.AuditoriaOrdenCompra>();
            try
            {
                AuditoriaOrdenCompra = Modelo.Auditoria.catAuditoria.ObtenerInstancia().ConsultarAuditoriaOrdenesCompra(); 
            }
            catch (Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
            }
            return AuditoriaOrdenCompra;
        }

        public void AgregarAuditoriaOrdenCompra(Entidades.Auditoria.AuditoriaOrdenCompra AOC)
        {
            try
            {
                Modelo.Auditoria.catAuditoria.ObtenerInstancia().AgregarAuditoriaOrdenCompra(AOC);
            }
            catch (Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
            }
        }
    }
}