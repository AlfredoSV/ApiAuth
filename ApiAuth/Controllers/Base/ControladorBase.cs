
using System;
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

        /*protected ActionResult RegresarRespuestaExcepcionComun(string controlador, Exception e)
        {
            var result = StatusCode(StatusCodes.Status500InternalServerError, new { Detalle = "Excepcion no contemplada" });
            return result;
        }
        */

        protected ActionResult RegresarRespuestaExcepcionComun(string controlador, Exception e)
        {
            var result = StatusCode(StatusCodes.Status500InternalServerError, new { Detalle = "Excepcion no contemplada" });
            return result;
        }

    }

}