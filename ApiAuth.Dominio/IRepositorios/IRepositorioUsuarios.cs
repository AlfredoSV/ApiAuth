using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAuth.Dominio
{
    public interface IRepositorioUsuarios
    {
        Usuario ObtenerUsuarioPorUsuarioYContrasenia(string correo);

        void GuardarNuevoTokenUsuario(UsuarioToken tokenUsuario);

        UsuarioToken ObtenerTokenPorIdUsuario(Guid idUsuario);

        void EliminarTokensAnterioresPorIdUsuario(Guid idUsuario);

        void GuardarNuevoUsuario(Usuario usuario);
    }
}
