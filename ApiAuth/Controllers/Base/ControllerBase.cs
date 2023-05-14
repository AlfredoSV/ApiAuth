
using System;
using Dominio.ExcepcionComun;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAuth.Controllers
{
    public class ControllerBase : Controller
    {

        protected ActionResult ReturnResponseHttpSuccess()
        {
            return Ok();
        }

        protected ActionResult ReturnResponseIncorrectCommon(string controller, ExcepcionComun e)
        {

            return BadRequest(new { Detalle = e.Detalle, Controlador = controller });
        }


        protected ActionResult RegresarRespuestaIncorrectaNoControlada(string controller, Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { Detalle = e.Message, Controlador = controller });
            
        }

    }

}