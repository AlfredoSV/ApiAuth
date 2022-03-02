using ApiAuth.Dominio;
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

            var idToken = Guid.Empty;
            var idToken2 = Guid.NewGuid();
            var idUsuario = Guid.NewGuid();
            var token = string.Empty;
            var token2 = "PruebaTok";
            var fechaAltaToken = DateTime.Now;
            var fechaVencimientoToken = DateTime.Now;

            //Act y Assert

            Assert.Throws<ExcepcionComun>(() =>
            {
                var usuarioToken = UsuarioToken.Create(idToken, idUsuario, token2, fechaAltaToken, fechaVencimientoToken);
            });

            Assert.Throws<ExcepcionComun>(() =>
            {
                var usuarioToken = UsuarioToken.Create(idToken2, idUsuario, token, fechaAltaToken, fechaVencimientoToken);
            });

        }
    }
}
