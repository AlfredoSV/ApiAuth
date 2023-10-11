using ApiAuth.Aplicacion.Dtos;
using ApiAuth.Aplicacion.IServicios;
using Dominio.ExcepcionComun;
using log4net;
using Microsoft.AspNetCore.Mvc;
using System;


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
        public IActionResult Create(DtoUser dtoUser)
        {
            try
            {
                _serviceUser.CreateUser(dtoUser);

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
