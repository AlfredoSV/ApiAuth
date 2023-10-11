using ApiAuth.Aplicacion.Dtos;
using ApiAuth.Dominio;
using System.Threading.Tasks;

namespace ApiAuth.Aplicacion.IServicios
{
    public interface IServiceUser
    {
        public Task CreateUser(DtoUser dtoUser);
    }
}
