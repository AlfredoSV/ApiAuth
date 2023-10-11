using ApiAuth.Aplicacion.IServicios;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;


namespace ApiAuth.Aplicacion.Services
{
    public class ServiceEncrypted : IServiceEncrypted
    {
        private string _key = "#$/77KL$$¡";

        public bool StrIsBase64(string str)
        {

            str = str.Trim();
            return (str.Length % 4 == 0) && Regex.IsMatch(str, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);

        }

        public string Encrypted(string str)
        {
            byte[] llave; 
            byte[] arreglo = UTF8Encoding.UTF8.GetBytes(str); 
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            llave = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(_key));
            md5.Clear();
            TripleDESCryptoServiceProvider tripledes = new TripleDESCryptoServiceProvider();
            tripledes.Key = llave;
            tripledes.Mode = CipherMode.ECB;
            tripledes.Padding = PaddingMode.PKCS7;
            ICryptoTransform convertir = tripledes.CreateEncryptor(); 
            byte[] resultado = convertir.TransformFinalBlock(arreglo, 0, arreglo.Length); 
            tripledes.Clear();
            return Convert.ToBase64String(resultado, 0, resultado.Length); 
        
        }

     
        public string Decrypt(string str)
        {
            byte[] llave;
            byte[] arreglo = Convert.FromBase64String(str); 
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            llave = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(_key));
            md5.Clear();
            TripleDESCryptoServiceProvider tripledes = new TripleDESCryptoServiceProvider();
            tripledes.Key = llave;
            tripledes.Mode = CipherMode.ECB;
            tripledes.Padding = PaddingMode.PKCS7;
            ICryptoTransform convertir = tripledes.CreateDecryptor();
            byte[] resultado = convertir.TransformFinalBlock(arreglo, 0, arreglo.Length);
            tripledes.Clear();
            string cadena_descifrada = UTF8Encoding.UTF8.GetString(resultado); 
            return cadena_descifrada; 
        }



    }
}
