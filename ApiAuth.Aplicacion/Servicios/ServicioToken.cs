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
        private IRepositorioUsuarios _usuarios { get; set; }

        public ServicioToken(IRepositorioUsuarios consultarUsuarios)
        {
            _usuarios = consultarUsuarios;

        }
        public string GenerarToken()
        {
            string token = string.Empty;
            DateTime fecha = DateTime.Now;

            token = string.Concat(Guid.NewGuid().ToString(),".");

            token = fecha.Minute.ToString() + fecha.Second + fecha.Millisecond;
            token = string.Concat(token,fecha.Minute.ToString(),fecha.Second,fecha.Millisecond);

            return token;
        }

        public void GuardarNuevoTokenUsuario(UserToken token)
        {
            _usuarios.SaveToken(token);
        }

        public void EliminarTokensAnterioresPorIdUsuario(Guid idUsuario)
        {
            _usuarios.DeleteTokensByUserId(idUsuario);
        }

        public UserToken ObtenerTokenPorIdUsuario(Guid idUsuario)
        {
            return _usuarios.GetTokenByUserId(idUsuario);
        }
    }
}
