using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAuth.Dominio
{
    public class AgregadoToken
    {
        public Guid IdToken { get; private set; }
        public string Token { get; private set; }
        public DateTime FechaAltaToken { get; private set; }
        public DateTime FechaVencimientoToken { get; private set; }
        public Guid IdUsuario { get; private set; }

        public AgregadoToken(Guid idToken, string token, DateTime fechaAltaToken, DateTime fechaVencimientoToken, Guid idUsuario)
        {
            IdToken = idToken;
            Token = token;
            FechaAltaToken = fechaAltaToken;
            FechaVencimientoToken = fechaVencimientoToken;
            IdUsuario = idUsuario;
        }


        public static AgregadoToken Create(Guid idToken, string token, DateTime fechaAltaToken, DateTime fechaVencimientoToken, Guid idUsuario)
        {
            return new AgregadoToken(idToken, token, fechaAltaToken, fechaVencimientoToken, idUsuario);
        }

    }
}
