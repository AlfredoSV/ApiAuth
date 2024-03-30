using ApiAuth.Aplicacion.IServicios;
using ApiAuth.Aplicacion.Services;
using ApiAuth.Application;
using ApiAuth.Controllers;
using ApiAuth.Dominio;
using ApiAuth.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddTransient<IServiceUserAuth, ServiceUserAuth>();

builder.Services.AddTransient<IRepositorioUsuarios, RepositorioUsuarios>();

builder.Services.AddTransient<IServiceToken, ServiceToken>();

builder.Services.AddTransient<IServiceEncrypted, ServiceEncrypted>();

builder.Services.AddTransient<IServiceUser, ServiceUser>();

builder.Services.AddScoped(cadConex => new string(builder.Configuration.GetSection("ConnectionStrings:bd").Value));

//builder.

//builder.Services.AddCors(options =>
//{

//    options.AddPolicy(name: MyAllowSpecificOrigins,
//        builder =>
//        {
//            builder.WithOrigins("https://localhost:44357/");
//        });

//});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

//app.UseDeveloperExceptionPage();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiAuth v1"));

var versionGroup = app.MapGroup("version").WithTags("version");

versionGroup.MapGet("/", () =>
{
    return TypedResults.Ok("1.0.0");
});

var userAuth = app.MapGroup("userAuth").WithTags("userAuth");

userAuth.MapPost("/", UserAuthHandler.UserAuth);

var userApi = app.MapGroup("user").WithTags("user");

userApi.MapPost("/", UserHandler.Create);

app.UseHttpsRedirection();

app.UseRouting();


//app.UseCors(MyAllowSpecificOrigins);

app.Run();