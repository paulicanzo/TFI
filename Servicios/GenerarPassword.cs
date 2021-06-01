using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servicios
{
    public static class GenerarPassword
    {
        ///<summary>
        /// crea un string que contiene una clave generada automaticamente, y va a depender del tamaño que se le asigne
        /// </summary>
        /// <param name="tamañoClave">La cantidad de caracteres de la clave</param>
        /// <returns>String: string generado con la clave</returns> 
        
        public static string CrearContraseñaAleatoria(int tamaño)
        {
            int tamañoClave = tamaño;
            string _allowedChars = "abcdefghijkmnpqrstuvwxyzABCDEFGHJKLMNPQRSTUVWXYZ23456789!@$?";
            Byte[] randomBytes = new Byte[tamañoClave];
            char[] chars = new char[tamañoClave];
            int allowedCharCount = _allowedChars.Length;

            for (int i = 0; i < tamañoClave; i++)
            {
                Random randomObj = new Random();
                randomObj.NextBytes(randomBytes);
                chars[i] = _allowedChars[(int)randomBytes[i] % allowedCharCount]; 
            }
            return new string(chars); 
        }
    }
}
