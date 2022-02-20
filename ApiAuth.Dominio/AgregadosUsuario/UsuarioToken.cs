using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAuth.Dominio
{
    public class UsuarioToken
    {
        public Guid IdToken { get; private set; }
        public string Token { get; private set; }
        public DateTime FechaAltaToken { get; private set; }
        public DateTime FechaVencimientoToken { get; private set; }
        public Guid IdUsuario { get; private set; }

        public UsuarioToken(Guid idToken, Guid idUsuario, string token, DateTime fechaAltaToken, DateTime fechaVencimientoToken)
        {
            IdToken = idToken;
            Token = token;
            FechaAltaToken = fechaAltaToken;
            FechaVencimientoToken = fechaVencimientoToken;
            IdUsuario = idUsuario;
        }


        public static UsuarioToken Create(Guid idToken, Guid idUsuario, string token, DateTime fechaAltaToken, DateTime fechaVencimientoToken)
        {
            return new UsuarioToken(idToken, idUsuario, token, fechaAltaToken, fechaVencimientoToken);
        }

    }
}
