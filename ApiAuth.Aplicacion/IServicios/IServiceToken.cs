using ApiAuth.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAuth.Application
{
    public interface IServiceToken
    {
        string GenerateToken();

        void SaveNewToken(UserToken token);

        void DeleteTokensPreviousByUserId(Guid idUsuario);

        UserToken GetTokenByUserId(Guid idUsuario);
    }
}
