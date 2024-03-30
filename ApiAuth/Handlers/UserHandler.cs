using ApiAuth.Aplicacion.Dtos;
using ApiAuth.Aplicacion.IServicios;
using Dominio.ExcepcionComun;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ApiAuth.Controllers
{
    public static class UserHandler
    {
        public static async Task<Results<Ok, ProblemHttpResult>> Create(
            DtoUser dtoUser, 
            IServiceUser serviceUser)
        {
            try
            {
                await serviceUser.CreateUser(dtoUser);
                return TypedResults.Ok();
            }
            catch (Exception e)
            {
                return TypedResults.
                    Problem(
                    new ProblemDetails() { Title = "UserHandler", Detail = e.StackTrace });
            }

        }
    }
}
