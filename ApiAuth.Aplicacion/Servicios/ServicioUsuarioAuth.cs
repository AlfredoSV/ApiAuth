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
        public ServicioUsuarioAuth(IConsultarUsuarios consultarUsuarios)
        {
            _consultarUsuarios = consultarUsuarios;
        }
        public DtoUsuarioLoginRespuesta ValidarUsuario(string usuario, string contrasenia)
        {
            var usuarioRes = _consultarUsuarios.validarUsuarioPorUsuarioYContrasenia(usuario, contrasenia);

            if (usuarioRes == null)
                throw new Exception("Credenciales no validas");

            var dtoUsuarioRes = new DtoUsuarioLoginRespuesta()
            {
                Id = usuarioRes.Id,
                Correo = usuarioRes.Correo,
                TokenSesion = string.Empty
            };

            return null;

        }
    }
}
