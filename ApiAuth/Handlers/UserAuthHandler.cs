using Microsoft.AspNetCore.Mvc;
using ApiAuth.Aplicacion;
using System;
using System.Threading.Tasks;
using ApiAuth.Application;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Http;

namespace ApiAuth.Controllers
{
    public static class UserAuthHandler
    {
        public static async Task<Results<Ok<DtoUsuarioLoginRespuesta>,ProblemHttpResult>>UserAuth(DtoUserLogin dtoUserLogin , IServiceUserAuth serviceUserAuth)
        {
            try
            {
                return TypedResults.Ok(await serviceUserAuth.ValidateUser(dtoUserLogin.Email, dtoUserLogin.Password));
            }
            catch (Exception e)
            {
                return TypedResults.Problem(new ProblemDetails() { Title = "UserAuthHandler", Detail = e.StackTrace});
            }

        }

        public  static async Task<Results<Ok, ProblemHttpResult>> ValidateToken(DtoUserToken dtoUserToken, IServiceUserAuth serviceUserAuth)
        {
            try
            {
                serviceUserAuth.ValidateToken(dtoUserToken.Id, dtoUserToken.Token);
                return TypedResults.Ok();
            }
            catch (Exception e)
            {
                return TypedResults.Problem(new ProblemDetails() { Title = "UsuarioAuth", Detail = e.StackTrace});
            }
        }
    }
}
