using ApiAuth.Aplicacion.Dtos;
using ApiAuth.Dominio;


namespace ApiAuth.Aplicacion.IServicios
{
    public interface IServiceUser
    {
        public void CreateUser(DtoUser dtoUser);
    }
}
