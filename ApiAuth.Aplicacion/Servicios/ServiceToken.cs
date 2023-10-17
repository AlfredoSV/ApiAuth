using System;
using ApiAuth.Dominio;


namespace ApiAuth.Application
{
    public class ServiceToken : IServiceToken
    {
        private IRepositorioUsuarios _usuarios { get; set; }

        public ServiceToken(IRepositorioUsuarios consultarUsuarios)
        {
            _usuarios = consultarUsuarios;

        }
        public string GenerateToken()
        {
            string token = string.Empty;
            DateTime fecha = DateTime.Now;

            token = string.Concat(Guid.NewGuid().ToString(),".");

            token = fecha.Minute.ToString() + fecha.Second + fecha.Millisecond;
            token = string.Concat(token,fecha.Minute.ToString(),fecha.Second,fecha.Millisecond);

            return token;
        }

        public void SaveNewToken(UserToken token)
        {
            _usuarios.SaveToken(token);
        }

        public void DeleteTokensPreviousByUserId(Guid idUsuario)
        {
            _usuarios.DeleteTokensByUserId(idUsuario);
        }

        public UserToken GetTokenByUserId(Guid idUsuario)
        {
            return _usuarios.GetTokenByUserId(idUsuario);
        }
    }
}
