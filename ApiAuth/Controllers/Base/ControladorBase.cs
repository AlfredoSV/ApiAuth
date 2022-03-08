
using System;
using Dominio.ExcepcionComun;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAuth.Controllers
{
    public class ControladorBase : Controller
    {

        protected ActionResult RegresarRespuestaHttpCorrecta()
        {
            return Ok();
        }

        protected ActionResult RegresarRespuestaIncorrectaComun(string controlador, ExcepcionComun e)
        {

            return BadRequest(new { Detalle = e.Detalle, Controlador = controlador });
        }


        protected ActionResult RegresarRespuestaIncorrectaNoControlada(string controlador, Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { Detalle = e.Message, Controlador = controlador});
            
        }

    }

}