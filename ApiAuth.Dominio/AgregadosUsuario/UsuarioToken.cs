using Dominio.ExcepcionComun;
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

        private UsuarioToken(Guid idToken, Guid idUsuario, string token, DateTime fechaAltaToken, DateTime fechaVencimientoToken)
        {
            //idToken.CampoRequerido()
            if (idToken == Guid.Empty)
                throw new ExcepcionComun("Valor requerido", "El IdToken es requerido");
            IdToken = idToken;
            if (token.Equals("") || token == null)
                throw new ExcepcionComun("Valor requerido", "El Token es requerido");
            Token = token;
            if (fechaAltaToken == DateTime.MinValue || fechaAltaToken == DateTime.MaxValue)
                throw new ExcepcionComun("Valor invalido", "La FechaAltaToken no es valida");
            FechaAltaToken = fechaAltaToken;
            if (fechaVencimientoToken == DateTime.MinValue || fechaVencimientoToken == DateTime.MaxValue)
                throw new ExcepcionComun("Valor invalido", "La FechaVencimientoToken no es valida");
            FechaVencimientoToken = fechaVencimientoToken;
            if (idUsuario == Guid.Empty)
                throw new ExcepcionComun("Valor requerido", "El IdUsuario es requerido");
            IdUsuario = idUsuario;
        }


        public static UsuarioToken Create(Guid idToken, Guid idUsuario, string token, DateTime fechaAltaToken, DateTime fechaVencimientoToken)
        {
            return new UsuarioToken(idToken, idUsuario, token, fechaAltaToken, fechaVencimientoToken);
        }

    }
}
