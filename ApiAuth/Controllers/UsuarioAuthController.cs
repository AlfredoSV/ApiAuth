using Microsoft.AspNetCore.Mvc;
using ApiAuth.Aplicacion; 

namespace ApiAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioAuthController : Controller
    {
        public readonly  IServicioUsuarioAuth _ServicioUsuarioAuth;
        public UsuarioAuthController(IServicioUsuarioAuth servicioUsuarioAuth)
        {
                _ServicioUsuarioAuth = servicioUsuarioAuth;
        }
        [HttpGet("[action]")]
        public IActionResult Index()
        {
            //_ServicioUsuarioAuth.ValidarUsuario();
            return Json(new { Nombre = "Alfredo" });
        }

        [HttpPost("[action]")]
        public IActionResult UsuarioAuth(DtoUsuarioLogin dtoUsuatioLogin)
        {
            _ServicioUsuarioAuth.ValidarUsuario(dtoUsuatioLogin.CorreoUsuario,dtoUsuatioLogin.ContrasenaUsuario);
            return Json(new { Nombre = "Alfredo" });
        }
    }
}
