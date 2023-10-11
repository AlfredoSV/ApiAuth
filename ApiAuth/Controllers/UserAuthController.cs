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
        private readonly ILog _logger;
        public UserAuthController(IServicioUsuarioAuth servicioUsuarioAuth)
        {
            _logger = LogManager.GetLogger(typeof(UserAuthController));
            _servicioUsuarioAuth = servicioUsuarioAuth;
            
        }

        [HttpPost("[action]")]
        public ActionResult<DtoUsuarioLoginRespuesta> UserAuth(DtoUserLogin dtoUserLogin)
        {
            try
            {

                return Ok(_servicioUsuarioAuth.ValidarUsuario(dtoUserLogin.Email, dtoUserLogin.Password));
            }
            catch (ExcepcionComun e)
            {
                _logger.Error(e.Message);
                return ReturnResponseIncorrectCommon("UsuarioAuth", e);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
                return ReturnIncorrectResponseNotControlled("UsuarioAuth", e);
            }

        }

        [HttpPost("[action]")]
        public ActionResult ValidateToken(DtoUserToken dtoUserToken)
        {
            try
            {
                _servicioUsuarioAuth.ValidarToken(dtoUserToken.Id, dtoUserToken.Token);
                return ReturnResponseHttpSuccess();
            }
            catch (ExcepcionComun e)
            {
                _logger.Error(e.Message);
                return ReturnResponseIncorrectCommon("ValidarToken", e);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
                return ReturnIncorrectResponseNotControlled("ValidarToken", e);
            }

        }
    }
}
