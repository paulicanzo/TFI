using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LPA.Comunicacion.Request;
using LPA.Context;
using LPA.Seguridad;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LPA.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly ProductosDbContext _context;


        public UsuariosController(IPasswordHasher passwordHasher, ProductosDbContext context)
        {
            _passwordHasher = passwordHasher;
            _context = context;
        }

        // POST: api/Usuarios/Autenticar
        [HttpPost, Route("Autenticar")]
        public IActionResult Post([FromBody] LoginRequest request)
        {
            //Buscar el usuario con el mismo nombre de usuario
            //Si lo encuentra comparar la contrase;a con el hash de la base de datos
            //Si son iguales devolver true
            //Sino false

            //Buscamos el usuario que corresponda
            //Solo puede haber uno solo con el mismo nombre de usuario
            var usuario = _context.Usuarios.Where(x=>x.NombreUsuario== request.nombreUsuario).FirstOrDefault();

            if (usuario == null) return new JsonResult(new { resultado= false });

            var validaPass = _passwordHasher.CheckPasswords(usuario.ContrasenaUsuario, request.contrasenaUsuario);

            if (validaPass) return new JsonResult(new { resultado = true, usuario= usuario.NombreUsuario });

            return new JsonResult(new { resultado = false });

        }       
    }
}
