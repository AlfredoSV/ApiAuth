
using ApiAuth.Dominio;
using System.Threading.Tasks;
using Dominio.ExcepcionComun;
using ApiAuth.Aplicacion.IServicios;
using ApiAuth.Aplicacion;
using System;

namespace ApiAuth.Application
{
    public class ServiceUserAuth : IServiceUserAuth
    {
        private readonly IRepositorioUsuarios _usuarios;
        private readonly IServiceToken _servicioToken;
        private readonly IServiceEncrypted _servicioCifrado;
        public ServiceUserAuth(IRepositorioUsuarios consultarUsuarios, IServiceToken servicioToken,IServiceEncrypted servicioCifrado)
        {
            _usuarios = consultarUsuarios;
            _servicioToken = servicioToken;
            _servicioCifrado = servicioCifrado;
        }

        public async Task<DtoUsuarioLoginRespuesta> ValidateUser(string user, string password)
        {
            DateTime fechaAlta = DateTime.Now;
            Guid idToken = Guid.NewGuid();
            User usuarioRes = await _usuarios.GetUserByEmail(user);
            DateTime fechaExpiracion = DateTime.Now.AddDays(1);
            string token = _servicioCifrado.Encrypted(_servicioToken.GenerateToken());

            if (usuarioRes == null)
                throw new ExcepcionComun("Usuario no valido", "Credenciales no validas.");

            if(!password.Equals(_servicioCifrado.Decrypt(usuarioRes.Password)))
                throw new ExcepcionComun("Usuario no valido", "Credenciales no validas.");

            UserToken userToken = UserToken.Create(idToken, usuarioRes.Id, token, fechaAlta, fechaExpiracion);

            _servicioToken.DeleteTokensPreviousByUserId(usuarioRes.Id);
            _servicioToken.SaveNewToken(userToken);

            DtoUsuarioLoginRespuesta dtoUsuarioRes = new DtoUsuarioLoginRespuesta()
            {
                Id = usuarioRes.Id,
                Correo = usuarioRes.Email,
                TokenSesion = userToken.Token
            };

            return dtoUsuarioRes;

        }

        public void ValidateToken(Guid userId, string token)
        {

            UserToken usuario = _servicioToken.GetTokenByUserId(userId);
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
