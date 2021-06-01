using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LPA.Models
{
    //Clase para modelar el usuario del sistema BASE DE DATOS MEMORIA
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }
        public string NombreUsuario { get; set; }
        public string ContrasenaUsuario { get; set; }

    }
}
