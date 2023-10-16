using ApiAuth.Aplicacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAuth.Application
{
    public interface IServiceUserAuth
    {
        Task<DtoUsuarioLoginRespuesta> ValidateUser(string user, string password);

        void ValidateToken(Guid userId, string token);
    }
}
