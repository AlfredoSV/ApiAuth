using ApiAuth.Aplicacion;
using ApiAuth.Dominio;
using ApiAuth.Infrastructure;
using Dominio.ExcepcionComun;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Tests
{
    public class AgregadoUsuarioTokenTest
    {
        [Fact]
        public void CrearObjetoUsuarioToken_IdTokenEmptyYTokenEmpty_ExcepcionComunValoresRequerido()
        {
            //Arrange

            //var idToken = Guid.Empty;
            //var idToken2 = Guid.NewGuid();
            //var idUsuario = Guid.Parse("37B1A359-4A2A-4A2F-B06A-64C88B07F54A");
            //var token = string.Empty;
            //var token2 = "PruebaTok";
            //var fechaAltaToken = DateTime.Now;
            //var fechaVencimientoToken = DateTime.Now;

            //Act y Assert

            /*Assert.Throws<ExcepcionComun>(() =>
            {
                var usuarioToken = (new ServicioToken(new RepositorioUsuarios("Server=Alfredo;Database=ApiAuth;Trusted_Connection=True;"))).GenerarToken();
                (new ServicioToken(new RepositorioUsuarios("Server=Alfredo;Database=ApiAuth;Trusted_Connection=True;"))).
                GuardarNuevoTokenUsuario(usuarioToken);
            });*/

            //Assert.Throws<ExcepcionComun>(() =>
            //{
            //    var usuarioToken = UsuarioToken.Create(idToken2, idUsuario, token, fechaAltaToken, fechaVencimientoToken);
            //});

        }
    }
}
