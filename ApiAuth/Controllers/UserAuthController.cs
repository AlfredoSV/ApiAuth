using Microsoft.AspNetCore.Mvc;
using ApiAuth.Aplicacion;
using System;
using Dominio.ExcepcionComun;
using log4net;
using System.Threading.Tasks;
using ApiAuth.Application;

namespace ApiAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthController : ControllerBase
    {
        public readonly IServiceUserAuth _serviceUserAuth;
        private readonly ILog _logger;
        public UserAuthController(IServiceUserAuth serviceUserAuth)
        {
            _logger = LogManager.GetLogger(typeof(UserAuthController));
            _serviceUserAuth = serviceUserAuth;
            
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<DtoUsuarioLoginRespuesta>>UserAuth(DtoUserLogin dtoUserLogin)
        {
            try
            {

                return Ok(await _serviceUserAuth.ValidateUser(dtoUserLogin.Email, dtoUserLogin.Password));
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
                _serviceUserAuth.ValidateToken(dtoUserToken.Id, dtoUserToken.Token);
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
