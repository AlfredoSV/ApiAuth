using ApiAuth.Aplicacion.Dtos;
using ApiAuth.Aplicacion.IServicios;
using Dominio.ExcepcionComun;
using log4net;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ApiAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IServiceUser _serviceUser;
        private readonly ILog _logger;

        public UserController(IServiceUser serviceUser)
        {
            _logger = LogManager.GetLogger(typeof(UserController));
            _serviceUser = serviceUser;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> Create(DtoUser dtoUser)
        {
            try
            {
                await _serviceUser.CreateUser(dtoUser);

                return ReturnResponseHttpSuccess();
            }
            catch (ExcepcionComun e)
            {
                _logger.Error(e.Message);
                return ReturnResponseIncorrectCommon("Create User", e);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
                return ReturnIncorrectResponseNotControlled("Create User", e);
            }
        }
    }
}
