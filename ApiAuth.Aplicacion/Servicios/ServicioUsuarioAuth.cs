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
        private IRepositorioUsuarios _usuarios { get; set; }
        private IServicioToken _servicioToken { get; set; }
        public ServicioUsuarioAuth(IRepositorioUsuarios consultarUsuarios, IServicioToken servicioToken)
        {
            _usuarios = consultarUsuarios;
            _servicioToken = servicioToken;
        }
        public DtoUsuarioLoginRespuesta ValidarUsuario(string usuario, string contrasenia)
        {
            var fechaAlta = DateTime.Now;
            var idToken = Guid.NewGuid();
            var usuarioRes = _usuarios.ValidarUsuarioPorUsuarioYContrasenia(usuario, contrasenia);
            var fechaExpiracion = DateTime.Now.AddDays(1);
            var token = _servicioToken.GenerarToken();


            if (usuarioRes == null)
                throw new ExcepcionComun("Usuario no valido", "Credenciales no validas.");

            var tokenUsuario = UsuarioToken.Create(idToken, usuarioRes.IdUsuario, token, fechaAlta, fechaExpiracion);

            _servicioToken.EliminarTokensAnterioresPorIdUsuario(usuarioRes.IdUsuario);
            _servicioToken.GuardarNuevoTokenUsuario(tokenUsuario);

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

            var usuario = _servicioToken.ObtenerTokenPorIdUsuario(idUsuario);
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
