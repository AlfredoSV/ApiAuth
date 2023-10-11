using ApiAuth.Aplicacion.Dtos;
using ApiAuth.Aplicacion.IServicios;
using ApiAuth.Dominio;
using Dominio.ExcepcionComun;
using System.Threading.Tasks;

//It is necessary to move all the code to English.

namespace ApiAuth.Aplicacion.Services
{
    public class ServiceUser: IServiceUser
    {
        private readonly IRepositorioUsuarios _users;
        private readonly IServiceEncrypted _serviceEncryp;

        public ServiceUser(IRepositorioUsuarios consultarUsuarios, IServiceEncrypted servicioCifrado)
        {
            _users = consultarUsuarios;
            _serviceEncryp = servicioCifrado;
            
        }

        public async Task CreateUser(DtoUser dtoUser)
        {
            string passwordEncrypted = _serviceEncryp.Encrypted(dtoUser.Password);

            User user = await _users.GetUserByEmail(dtoUser.Email);

            if (user != null) {

                throw new ExcepcionComun("User was exist", "The user already exists, please enter another one.");
            }

            _users.SaveUser(User.Create(dtoUser.Email, passwordEncrypted));
            
        }

   
    }
}
