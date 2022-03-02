using ApiAuth.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAuth.Aplicacion
{
    public interface IServicioToken
    {
        string GenerarToken();

        void GuardarNuevoTokenUsuario(UsuarioToken token);

        void EliminarTokensAnterioresPorIdUsuario(Guid idUsuario);

        UsuarioToken ObtenerTokenPorIdUsuario(Guid idUsuario);
    }
}
