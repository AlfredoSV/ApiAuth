using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApiAuth.Dominio;
using System.Threading.Tasks;
using Dominio.ExcepcionComun;

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
                throw new ExcepcionComun("Usuario no valido", "Credenciales no validas");


            var fechaExpiracion = DateTime.Now.AddDays(1);
            var fechaAlta = DateTime.Now;
            var idToken = Guid.NewGuid();

            var tokenUsuario = UsuarioToken.Create(idToken, usuarioRes.IdUsuario, _servicioToken.GenerarToken(), fechaAlta, fechaExpiracion);


            _servicioToken.GuardarTokenUsuario(tokenUsuario);

            var dtoUsuarioRes = new DtoUsuarioLoginRespuesta()
            {
                Id = usuarioRes.IdUsuario,
                Correo = usuarioRes.CorreoUsuario,
                TokenSesion = tokenUsuario.Token
            };

            return dtoUsuarioRes;

        }

        public void ValidarToken(Guid idUsuario, string token)
        {

            var usuario = _usuarios.ObtenerTokenPorIdUsuario(idUsuario);
            var fechaActual = DateTime.Now;


            if (usuario == null)
                throw new ExcepcionComun("Usuario no valido", "Este usuario no se encuentra registrado");

            if (token != usuario.Token)
                throw new ExcepcionComun("Token no valido", "Este usuario no se encuentra asociado a este token");

            if (fechaActual > usuario.FechaVencimientoToken)
                throw new ExcepcionComun("Token no valido", "Este token no es valido, favor de generar otro");



        }
    }
}
