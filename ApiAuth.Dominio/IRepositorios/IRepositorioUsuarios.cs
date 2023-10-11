using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAuth.Dominio
{
    public interface IRepositorioUsuarios
    {
        void SaveToken(UserToken userToken);

        UserToken GetTokenByUserId(Guid userId);

        void DeleteTokensByUserId(Guid userId);

        void SaveUser(User user);

        User GetUserByEmail(string email);
    }
}
