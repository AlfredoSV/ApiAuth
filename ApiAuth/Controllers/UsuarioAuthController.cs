using Microsoft.AspNetCore.Mvc;
using ApiAuth.Aplicacion;
using System;
using Dominio.ExcepcionComun;

namespace ApiAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioAuthController : ControladorBase
    {
        public readonly IServicioUsuarioAuth _ServicioUsuarioAuth;
        public UsuarioAuthController(IServicioUsuarioAuth servicioUsuarioAuth)
        {
            _ServicioUsuarioAuth = servicioUsuarioAuth;
        }

        [HttpPost("[action]")]
        public IActionResult UsuarioAuth(DtoUsuarioLogin dtoUsuatioLogin)
        {
            try
            {

                return Json(_ServicioUsuarioAuth.ValidarUsuario(dtoUsuatioLogin.CorreoUsuario, dtoUsuatioLogin.ContrasenaUsuario));
            }
            catch (Exception e)
            {

                throw;
            }

        }

        [HttpPost("[action]")]
        public IActionResult ValidarToken(DtoUsuarioToken dtoUsuarioToken)
        {
            try
            {
                throw new ExcepcionComun("Error", "DetalleError");
                return RegresarRespuestaHttpCorrecta();
            }
            catch (ExcepcionComun e)
            {

                return RegresarRespuestaIncorrecta("ValidarToken", e);
            }
            catch (Exception e)
            {
                return RegresarRespuestaIncorrecta("ValidarToken", e);
            }

        }
    }
}
