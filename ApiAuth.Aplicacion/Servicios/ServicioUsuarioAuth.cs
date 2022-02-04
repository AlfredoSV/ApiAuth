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
        private IConsultarUsuarios _consultarUsuarios { get; set; }
        private IServicioToken _servicioToken { get; set; }
        public ServicioUsuarioAuth(IConsultarUsuarios consultarUsuarios, IServicioToken servicioToken)
        {
            _consultarUsuarios = consultarUsuarios;
            _servicioToken = servicioToken;
        }
        public DtoUsuarioLoginRespuesta ValidarUsuario(string usuario, string contrasenia)
        {
            var usuarioRes = _consultarUsuarios.validarUsuarioPorUsuarioYContrasenia(usuario, contrasenia);

            if (usuarioRes == null)
                throw new Exception("Credenciales no validas");



            var token = _servicioToken.GenerarToken();


            var dtoUsuarioRes = new DtoUsuarioLoginRespuesta()
            {
                Id = usuarioRes.IdUsuario,
                Correo = usuarioRes.CorreoUsuario,
                TokenSesion = token
            };

            return dtoUsuarioRes;

        }
    }
}
