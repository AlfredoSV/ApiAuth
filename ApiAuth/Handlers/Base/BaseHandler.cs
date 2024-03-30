
using System;
using System.Threading.Tasks;
using Dominio.ExcepcionComun;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ApiAuth.Controllers
{
    public class BaseHandler
    {
        protected Results<Ok,ProblemHttpResult> ReturnResponseHttpSuccess()
        {
            return TypedResults.Ok();
        }

        protected Results<Ok, BadRequest<object>> ReturnResponseIncorrectCommon(string controller, ExcepcionComun e)
        {

            return TypedResults.BadRequest((object)new { Detalle = e.Detalle, Controlador = controller });
        }


        //protected Results<Ok, Inter<object>> ReturnIncorrectResponseNotControlled(string controller, Exception e)
        //{
        //    return StatusCode(StatusCodes.Status500InternalServerError, new { Detalle = e.Message, Controlador = controller });
            
        //}

    }

}