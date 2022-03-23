using ApiAuth.Aplicacion.Dtos;
using ApiAuth.Aplicacion.IServicios;
using Dominio.ExcepcionComun;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControladorBase
    {
        public readonly IServicioUsuario _servicioUsuario;
        public UsuarioController(IServicioUsuario servicioUsuario)
        {
            _servicioUsuario = servicioUsuario;
        }

        [HttpPost("[action]")]
        public IActionResult CrearUsuario(DtoUsuario dtoUsuario)
        {
            try
            {
                _servicioUsuario.CrearUsuario(dtoUsuario);

                return RegresarRespuestaHttpCorrecta();
            }
            catch (ExcepcionComun e)
            {

                return RegresarRespuestaIncorrectaComun("CrearUsuario", e);
            }
            catch (Exception e)
            {
                return RegresarRespuestaIncorrectaNoControlada("CrearUsuario", e);
            }
        }
    }
}
