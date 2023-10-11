using ApiAuth.Aplicacion.Dtos;
using ApiAuth.Aplicacion.IServicios;
using ApiAuth.Dominio;
using Dominio.ExcepcionComun;

//It is necessary to move all the code to English.

namespace ApiAuth.Aplicacion.Servicios
{
    public class ServiceUser: IServiceUser
    {
        private readonly IRepositorioUsuarios _usuarios;
        private readonly IServicioCifrado _servicioCifrado;

        public ServiceUser(IRepositorioUsuarios consultarUsuarios, IServicioCifrado servicioCifrado)
        {
            _usuarios = consultarUsuarios;
            _servicioCifrado = servicioCifrado;
            
        }


        public void CreateUser(DtoUser dtoUser)
        {
            string passwordEncrypted = _servicioCifrado.Cifrar(dtoUser.Password);

            User usuario = _usuarios.GetUserByEmail(dtoUser.Email);

            if (usuario != null) {

                throw new ExcepcionComun("User was exist", "The user already exists, please enter another one.");
            }

            _usuarios.GuardarNuevoUsuario(User.Create(dtoUser.Email, passwordEncrypted));
            
        }

   
    }
}
