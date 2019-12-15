using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LPA.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Productos()
        {
            return View("Index");
        }

        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public void PostLogin()
        {
            //te devuelve en bytes la cadena de string del usuario y eso se guarda en la sesion.
            HttpContext.Session.Set("usuario", Encoding.ASCII.GetBytes(""));
        }

        public IActionResult Producto(int id)
        {
            var existe = HttpContext.Session.TryGetValue("usuario", out byte[] val);
            if(existe) return View("Producto", id);

            return RedirectToAction("Login", controllerName:"Home");
            
        }

        public IActionResult ModificarProducto(int id)
        {
            var existe = HttpContext.Session.TryGetValue("usuario", out byte[] val);
            if (existe) return View("ModificarProducto", id);
            return RedirectToAction("Login", controllerName: "Home");
        }

        public IActionResult AgregarProducto()
        {
            var existe = HttpContext.Session.TryGetValue("usuario", out byte[] val);
            if (existe) return View("ModificarProducto", -99);
            return RedirectToAction("Login", controllerName: "Home");
        }

    }
}