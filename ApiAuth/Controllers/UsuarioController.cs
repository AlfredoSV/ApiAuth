using ApiAuth.Aplicacion.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAuth.Controllers
{
    public class UsuarioController : ControladorBase
    {
        public IActionResult CrearUsuario(DtoUsuario dtoUsuario)
        {
            return View();
        }
    }
}
