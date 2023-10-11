using ApiAuth.Aplicacion.Dtos;
using ApiAuth.Aplicacion.IServicios;
using Dominio.ExcepcionComun;
using Microsoft.AspNetCore.Mvc;
using System;


namespace ApiAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IServicioUsuario _servicioUsuario;
        public UserController(IServicioUsuario servicioUsuario)
        {
            _servicioUsuario = servicioUsuario;
        }

        [HttpPost("[action]")]
        public IActionResult CrearUsuario(DtoUsuario dtoUsuario)
        {
            try
            {
                _servicioUsuario.CrearUsuario(dtoUsuario);

                return ReturnResponseHttpSuccess();
            }
            catch (ExcepcionComun e)
            {

                return ReturnResponseIncorrectCommon("CrearUsuario", e);
            }
            catch (Exception e)
            {
                return RegresarRespuestaIncorrectaNoControlada("CrearUsuario", e);
            }
        }
    }
}
