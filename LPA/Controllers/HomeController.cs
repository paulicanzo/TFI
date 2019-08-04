using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LPA.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Productos()
        {
            return View("View");
        }
        public IActionResult Producto(int id)
        {
            return View("Producto", id);
        }

        public IActionResult ModificarProducto(int id)
        {
            return View("ModificarProducto", id);
        }

        public IActionResult AgregarProducto()
        {
            return View("ModificarProducto", -99);
        }

    }
}