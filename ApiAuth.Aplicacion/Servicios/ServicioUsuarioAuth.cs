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
            DateTime fechaAlta = DateTime.Now;
            Guid idToken = Guid.NewGuid();
            User usuarioRes = _usuarios.GetUserByEmail(usuario);
            DateTime fechaExpiracion = DateTime.Now.AddDays(1);
            string token = _servicioCifrado.Cifrar(_servicioToken.GenerarToken());

            if (usuarioRes == null)
                throw new ExcepcionComun("Usuario no valido", "Credenciales no validas.");

            if(!contrasenia.Equals(_servicioCifrado.Descifrar(usuarioRes.Password)))
                throw new ExcepcionComun("Usuario no valido", "Credenciales no validas.");

            UsuarioToken tokenUsuario = UsuarioToken.Create(idToken, usuarioRes.IdUser, token, fechaAlta, fechaExpiracion);

            _servicioToken.EliminarTokensAnterioresPorIdUsuario(usuarioRes.IdUser);
            _servicioToken.GuardarNuevoTokenUsuario(tokenUsuario);

            DtoUsuarioLoginRespuesta dtoUsuarioRes = new DtoUsuarioLoginRespuesta()
            {
                Id = usuarioRes.IdUser,
                Correo = usuarioRes.Email,
                TokenSesion = tokenUsuario.Token
            };

            return dtoUsuarioRes;

        }

        public void ValidarToken(Guid idUsuario, string token)
        {

            UsuarioToken usuario = _servicioToken.ObtenerTokenPorIdUsuario(idUsuario);
            DateTime fechaActual = DateTime.Now;

            if (!_servicioCifrado.CadenaEsBase64(token))
                throw new ExcepcionComun("Token no valido", "Este token no es valido, favor de generar otro");

            string tokenEnviado = _servicioCifrado.Descifrar(token);
            string tokenUsuario = _servicioCifrado.Descifrar(usuario.Token);

            if (usuario == null)
                throw new ExcepcionComun("Usuario no valido", "Este usuario no se encuentra registrado");

            if (tokenEnviado != tokenUsuario )
                throw new ExcepcionComun("Token no valido", "Este usuario no se encuentra asociado a este token");

            if (fechaActual > usuario.FechaVencimientoToken)
                throw new ExcepcionComun("Token no valido", "Este token no es valido, favor de generar otro");


        }
    }
}
