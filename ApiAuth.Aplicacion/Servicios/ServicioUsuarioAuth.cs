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
        private readonly IServiceEncrypted _servicioCifrado;
        public ServicioUsuarioAuth(IRepositorioUsuarios consultarUsuarios, IServicioToken servicioToken,IServiceEncrypted servicioCifrado)
        {
            _usuarios = consultarUsuarios;
            _servicioToken = servicioToken;
            _servicioCifrado = servicioCifrado;
        }

        public async Task<DtoUsuarioLoginRespuesta> ValidarUsuario(string usuario, string contrasenia)
        {
            DateTime fechaAlta = DateTime.Now;
            Guid idToken = Guid.NewGuid();
            User usuarioRes = await _usuarios.GetUserByEmail(usuario);
            DateTime fechaExpiracion = DateTime.Now.AddDays(1);
            string token = _servicioCifrado.Encrypted(_servicioToken.GenerarToken());

            if (usuarioRes == null)
                throw new ExcepcionComun("Usuario no valido", "Credenciales no validas.");

            if(!contrasenia.Equals(_servicioCifrado.Decrypt(usuarioRes.Password)))
                throw new ExcepcionComun("Usuario no valido", "Credenciales no validas.");

            UserToken userToken = UserToken.Create(idToken, usuarioRes.Id, token, fechaAlta, fechaExpiracion);

            _servicioToken.EliminarTokensAnterioresPorIdUsuario(usuarioRes.Id);
            _servicioToken.GuardarNuevoTokenUsuario(userToken);

            DtoUsuarioLoginRespuesta dtoUsuarioRes = new DtoUsuarioLoginRespuesta()
            {
                Id = usuarioRes.Id,
                Correo = usuarioRes.Email,
                TokenSesion = userToken.Token
            };

            return dtoUsuarioRes;

        }

        public void ValidarToken(Guid idUsuario, string token)
        {

            UserToken usuario = _servicioToken.ObtenerTokenPorIdUsuario(idUsuario);
            DateTime fechaActual = DateTime.Now;

            if (!_servicioCifrado.StrIsBase64(token))
                throw new ExcepcionComun("Token no valido", "Este token no es valido, favor de generar otro");

            string tokenEnviado = _servicioCifrado.Decrypt(token);
            string tokenUsuario = _servicioCifrado.Decrypt(usuario.Token);

            if (usuario == null)
                throw new ExcepcionComun("Usuario no valido", "Este usuario no se encuentra registrado");

            if (tokenEnviado != tokenUsuario )
                throw new ExcepcionComun("Token no valido", "Este usuario no se encuentra asociado a este token");

            if (fechaActual > usuario.DateExpired)
                throw new ExcepcionComun("Token no valido", "Este token no es valido, favor de generar otro");


        }
    }
}
