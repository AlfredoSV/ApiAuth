using Microsoft.AspNetCore.Mvc;
using ApiAuth.Aplicacion;
using System;

namespace ApiAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioAuthController : Controller
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
                _ServicioUsuarioAuth.ValidarUsuario(dtoUsuatioLogin.CorreoUsuario, dtoUsuatioLogin.ContrasenaUsuario);
                return Json(new { Nombre = "Alfredo" });
            }
            catch (Exception e)
            {

                throw;
            }

        }
    }
}
