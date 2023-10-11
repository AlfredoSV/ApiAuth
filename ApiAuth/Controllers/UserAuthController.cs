using Microsoft.AspNetCore.Mvc;
using ApiAuth.Aplicacion;
using System;
using Dominio.ExcepcionComun;
using log4net;

namespace ApiAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthController : ControllerBase
    {
        public readonly IServicioUsuarioAuth _servicioUsuarioAuth;
        private readonly ILog _logger = LogManager.GetLogger(typeof(UserAuthController));
        public UserAuthController(IServicioUsuarioAuth servicioUsuarioAuth)
        {
            _servicioUsuarioAuth = servicioUsuarioAuth;
            
        }

        [HttpPost("[action]")]
        public IActionResult UsuarioAuth(DtoUsuarioLogin dtoUsuatioLogin)
        {
            try
            {

                return Json(_servicioUsuarioAuth.ValidarUsuario(dtoUsuatioLogin.Email, dtoUsuatioLogin.Password));
            }
            catch (ExcepcionComun e)
            {
                
                return ReturnResponseIncorrectCommon("UsuarioAuth", e);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
                return RegresarRespuestaIncorrectaNoControlada("UsuarioAuth", e);
            }

        }

        [HttpPost("[action]")]
        public IActionResult ValidateToken(DtoUsuarioToken dtoUsuarioToken)
        {
            try
            {
                _servicioUsuarioAuth.ValidarToken(dtoUsuarioToken.Id, dtoUsuarioToken.Token);
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
