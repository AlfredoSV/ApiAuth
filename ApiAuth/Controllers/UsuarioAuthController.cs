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
        public readonly IServicioUsuarioAuth _servicioUsuarioAuth;
        public UsuarioAuthController(IServicioUsuarioAuth servicioUsuarioAuth)
        {
            _servicioUsuarioAuth = servicioUsuarioAuth;
        }

        [HttpPost("[action]")]
        public IActionResult UsuarioAuth(DtoUsuarioLogin dtoUsuatioLogin)
        {
            try
            {

                return Json(_servicioUsuarioAuth.ValidarUsuario(dtoUsuatioLogin.CorreoUsuario, dtoUsuatioLogin.ContrasenaUsuario));
            }
            catch (ExcepcionComun e)
            {

                return RegresarRespuestaIncorrecta("UsuarioAuth", e);
            }
            catch (Exception e)
            {
                return RegresarRespuestaIncorrecta("UsuarioAuth", e);
            }

        }

        [HttpPost("[action]")]
        public IActionResult ValidarToken(DtoUsuarioToken dtoUsuarioToken)
        {
            try
            {
                _servicioUsuarioAuth.ValidarToken(dtoUsuarioToken.IdUsuario, dtoUsuarioToken.CorreoUsuario, dtoUsuarioToken.TokenUsuario);
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
