using Microsoft.AspNetCore.Mvc;
using ApiAuth.Aplicacion;
using System;
using Dominio.ExcepcionComun;

namespace ApiAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthController : ControllerBase
    {
        public readonly IServicioUsuarioAuth _servicioUsuarioAuth;
        public UserAuthController(IServicioUsuarioAuth servicioUsuarioAuth)
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

                return ReturnResponseIncorrectCommon("UsuarioAuth", e);
            }
            catch (Exception e)
            {
                return RegresarRespuestaIncorrectaNoControlada("UsuarioAuth", e);
            }

        }

        [HttpPost("[action]")]
        public IActionResult ValidarToken(DtoUsuarioToken dtoUsuarioToken)
        {
            try
            {
                _servicioUsuarioAuth.ValidarToken(dtoUsuarioToken.IdUsuario, dtoUsuarioToken.TokenUsuario);
                return ReturnResponseHttpSuccess();
            }
            catch (ExcepcionComun e)
            {

                return ReturnResponseIncorrectCommon("ValidarToken", e);
            }
            catch (Exception e)
            {
                return RegresarRespuestaIncorrectaNoControlada("ValidarToken", e);
            }

        }
    }
}
