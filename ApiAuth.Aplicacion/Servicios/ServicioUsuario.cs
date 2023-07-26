using ApiAuth.Aplicacion.Dtos;
using ApiAuth.Aplicacion.IServicios;
using ApiAuth.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            string contraseniaCifrada = _servicioCifrado.Cifrar(dtoUsuario.ContraseniaUsuario);

            _usuarios.GuardarNuevoUsuario(Usuario.Crear(dtoUsuario.CorreoUsuario, contraseniaCifrada));
            
        }
    }
}
