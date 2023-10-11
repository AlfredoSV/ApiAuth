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
        public readonly IServiceUser _serviceUser;

        public UserController(IServiceUser serviceUser)
        {
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

                return ReturnResponseIncorrectCommon("Create User", e);
            }
            catch (Exception e)
            {
                return RegresarRespuestaIncorrectaNoControlada("Create User", e);
            }
        }
    }
}
