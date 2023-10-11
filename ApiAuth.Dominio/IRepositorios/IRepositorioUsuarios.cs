using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAuth.Dominio
{
    public interface IRepositorioUsuarios
    {
        void GuardarNuevoTokenUsuario(UsuarioToken tokenUsuario);

        UsuarioToken ObtenerTokenPorIdUsuario(Guid idUsuario);

        void EliminarTokensAnterioresPorIdUsuario(Guid idUsuario);

        void GuardarNuevoUsuario(User usuario);

        User GetUserByEmail(string email);
    }
}
