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

        public ServicioUsuario(IRepositorioUsuarios consultarUsuarios)
        {
            _usuarios = consultarUsuarios;
            
        }
        public void CrearUsuario(DtoUsuario dtoUsuario)
        {
            _usuarios.GuardarNuevoUsuario(Usuario.Crear(dtoUsuario.CorreoUsuario, dtoUsuario.ContraseniaUsuario));
            
        }
    }
}
