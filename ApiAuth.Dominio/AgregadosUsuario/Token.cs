using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAuth.Dominio
{
    public class Token
    {
        public string Valor { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public Guid IdUsuario { get; set; }

        public Token(string valor, DateTime fechaExpiracion, Guid idUsuario)
        {

            Valor = valor;
            FechaExpiracion = fechaExpiracion;
            IdUsuario = idUsuario;
        }

        public static Token Create(string valor, DateTime fechaExpiracion, Guid idUsuario)
        {
            return new Token(valor, fechaExpiracion, idUsuario);
        }
    }
}
