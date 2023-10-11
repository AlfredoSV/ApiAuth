using ApiAuth.Aplicacion.Dtos;
using ApiAuth.Aplicacion.IServicios;
using ApiAuth.Dominio;
using Dominio.ExcepcionComun;

//It is necessary to move all the code to English.

namespace ApiAuth.Aplicacion.Servicios
{
    public class ServicioUsuario : IServicioUsuario
    {
        private readonly IRepositorioUsuarios _usuarios;
        private readonly IServicioCifrado _servicioCifrado;

        public ServicioUsuario(IRepositorioUsuarios consultarUsuarios, IServicioCifrado servicioCifrado)
        {
            _usuarios = consultarUsuarios;
            _servicioCifrado = servicioCifrado;
            
        }


        public void CrearUsuario(DtoUsuario dtoUsuario)
        {
            string passwordEncrypted = _servicioCifrado.Cifrar(dtoUsuario.ContraseniaUsuario);

            Usuario usuario = _usuarios.GetUserByEmail(dtoUsuario.CorreoUsuario);

            if (usuario != null) {

                throw new ExcepcionComun("User was exist", "The user already exists, please enter another one.");
            }

            _usuarios.GuardarNuevoUsuario(Usuario.Crear(dtoUsuario.CorreoUsuario, passwordEncrypted));
            
        }

   
    }
}
