using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApiAuth.Dominio;
using System.Threading.Tasks;
using Dominio.ExcepcionComun;
using ApiAuth.Aplicacion.IServicios;

namespace ApiAuth.Aplicacion
{
    public class ServicioUsuarioAuth : IServicioUsuarioAuth
    {
        private readonly IRepositorioUsuarios _usuarios;
        private readonly IServicioToken _servicioToken;
        private readonly IServicioCifrado _servicioCifrado;
        public ServicioUsuarioAuth(IRepositorioUsuarios consultarUsuarios, IServicioToken servicioToken,IServicioCifrado servicioCifrado)
        {
            _usuarios = consultarUsuarios;
            _servicioToken = servicioToken;
            _servicioCifrado = servicioCifrado;
        }
        public DtoUsuarioLoginRespuesta ValidarUsuario(string usuario, string contrasenia)
        {
            var fechaAlta = DateTime.Now;
            var idToken = Guid.NewGuid();
            var usuarioRes = _usuarios.ObtenerUsuarioPorUsuarioYContrasenia(usuario, contrasenia);
            var fechaExpiracion = DateTime.Now.AddDays(1);
            var token = _servicioCifrado.Cifrar(_servicioToken.GenerarToken());


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

            if (!_servicioCifrado.CadenaEsBase64(token))
                throw new ExcepcionComun("Token no valido", "Este token no es valido, favor de generar otro");

            var tokenEnviado = _servicioCifrado.Descifrar(token);
            var tokenUsuario = _servicioCifrado.Descifrar(usuario.Token);

            if (usuario == null)
                throw new ExcepcionComun("Usuario no valido", "Este usuario no se encuentra registrado");

            if (tokenEnviado != tokenUsuario )
                throw new ExcepcionComun("Token no valido", "Este usuario no se encuentra asociado a este token");

            if (fechaActual > usuario.FechaVencimientoToken)
                throw new ExcepcionComun("Token no valido", "Este token no es valido, favor de generar otro");


        }
    }
}
