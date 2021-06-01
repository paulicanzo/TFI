using System;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Servicios
{
    public static class Encriptacion
    {
        static byte[] bytes = ASCIIEncoding.ASCII.GetBytes(System.Configuration.ConfigurationManager.AppSettings["EncryptionString"].ToString()); 

        public static void EncriptarConnectionStrings() //metodo que encripta la cadena de conexion especificada en app.config.
        {
            //obtengo el archivo de configuracion.
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            //crear el proveedor de encriptacion.
            String provider = "DataProtectionConfigurationProvider";

            //obtengo la seccion de configuracion
            ConfigurationSection connstrings = config.ConnectionStrings;

            //encriptar
            connstrings.SectionInformation.ProtectSection(provider);
            connstrings.SectionInformation.ForceSave = true;

            //guardar
            config.Save(ConfigurationSaveMode.Full); 
        }

        public static void DesencriptarConnectionStrings() //metodo que desencripta la cadena de conexion especificada en app.config
        {
            //obtengo el archivo de configuracion
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            //obtener la seccion de configuracion 
            ConfigurationSection connstrings = config.ConnectionStrings;

            //desencriptar
            connstrings.SectionInformation.UnprotectSection();
            connstrings.SectionInformation.ForceSave = true;

            //guardar
            config.Save(ConfigurationSaveMode.Full); 
        }

        public static void EncriptarAppSettings()
        {
            //obtener el archivo de configuracion
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            //crear el proveedor de encriptacion
            String provider = "DataProtectionConfigurationProvider";

            //obtener la seccion de configuracion
            ConfigurationSection appSettings = config.AppSettings;

            //encriptar
            appSettings.SectionInformation.ProtectSection(provider);
            appSettings.SectionInformation.ForceSave = true;

            //guardar
            config.Save(ConfigurationSaveMode.Full); 
        }

        public static void DesencriptarAppSettings()
        {
            //obtener el archivo de configuracion
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            //obtener la seccion de configuracion
            ConfigurationSection appSettings = config.AppSettings;

            //desencriptar
            appSettings.SectionInformation.UnprotectSection();
            appSettings.SectionInformation.ForceSave = true;

            //guardar
            config.Save(ConfigurationSaveMode.Full); 
        }

        public static string EncriptarPassword(string value)
        {
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateEncryptor(bytes, bytes), CryptoStreamMode.Write);
            StreamWriter writer = new StreamWriter(cryptoStream);
            writer.Write(value);
            writer.Flush();
            cryptoStream.FlushFinalBlock();
            writer.Flush();
            string clave = Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
            memoryStream.Dispose();
            cryptoProvider.Dispose();
            return clave; 
        }

        public static string DesencriptarPassword(string pwdEncriptado)
        {
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(pwdEncriptado));
            CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateDecryptor(bytes, bytes), CryptoStreamMode.Read);
            StreamReader reader = new StreamReader(cryptoStream);

            return reader.ReadToEnd(); 

        }
    }
}
