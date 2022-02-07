using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApiAuth.Dominio;
using System.Threading.Tasks;

namespace ApiAuth.Aplicacion
{
    public class ServicioToken : IServicioToken
    {
        private IUsuarios _usuarios { get; set; }

        public ServicioToken(IUsuarios consultarUsuarios)
        {
            _usuarios = consultarUsuarios;

        }
        public string GenerarToken()
        {
            var token = string.Empty;
            var fecha = DateTime.Now;

            token = Guid.NewGuid().ToString() + ".";

            token += fecha.Minute.ToString() + fecha.Second + fecha.Millisecond;

            return token;
        }

        public void GuardarTokenUsuario(AgregadoToken token)
        {
            _usuarios.GuardarTokenUsuario(token);
        }
    }
}
