
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
            return Ok(new { detalle = "Todo correcta" });
        }

        protected ActionResult RegresarRespuestaIncorrecta(string controlador, ExcepcionComun e)
        {
            var result = StatusCode(StatusCodes.Status500InternalServerError, new { Detalle = e.Detalle });
            return result;
        }


        protected ActionResult RegresarRespuestaIncorrecta(string controlador, Exception e)
        {
            var result = StatusCode(StatusCodes.Status500InternalServerError, new { Detalle = e.Message });
            return result;
        }

    }

}