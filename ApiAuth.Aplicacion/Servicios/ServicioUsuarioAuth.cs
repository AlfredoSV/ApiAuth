using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApiAuth.Dominio;
using System.Threading.Tasks;

namespace ApiAuth.Aplicacion
{
    public class ServicioUsuarioAuth : IServicioUsuarioAuth
    {
        private IUsuarios _usuarios { get; set; }
        private IServicioToken _servicioToken { get; set; }
        public ServicioUsuarioAuth(IUsuarios consultarUsuarios, IServicioToken servicioToken)
        {
            _usuarios = consultarUsuarios;
            _servicioToken = servicioToken;
        }
        public DtoUsuarioLoginRespuesta ValidarUsuario(string usuario, string contrasenia)
        {
            var usuarioRes = _usuarios.ValidarUsuarioPorUsuarioYContrasenia(usuario, contrasenia);

            if (usuarioRes == null)
                throw new Exception("Credenciales no validas");


            var fechaExpiracion = DateTime.Now.AddDays(1);
            var fechaAlta = DateTime.Now;
            var idToken = Guid.NewGuid();

            var tokenUsuario = AgregadoToken.Create(idToken, _servicioToken.GenerarToken(), fechaAlta, fechaExpiracion, usuarioRes.IdUsuario);


            _servicioToken.GuardarTokenUsuario(tokenUsuario);

            var dtoUsuarioRes = new DtoUsuarioLoginRespuesta()
            {
                Id = usuarioRes.IdUsuario,
                Correo = usuarioRes.CorreoUsuario,
                TokenSesion = tokenUsuario.Token
            };

            return dtoUsuarioRes;

        }

        public void ValidarToken(Guid idUsuario, string correo, string token)
        {

            var usuario = _usuarios.ObtenerUsuarioPorId(idUsuario);



        }
    }
}
