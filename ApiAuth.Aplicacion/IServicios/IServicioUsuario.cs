using ApiAuth.Aplicacion.Dtos;
using ApiAuth.Dominio;


namespace ApiAuth.Aplicacion.IServicios
{
    public interface IServicioUsuario
    {
        public void CrearUsuario(DtoUsuario dtoUsuario);
    }
}
