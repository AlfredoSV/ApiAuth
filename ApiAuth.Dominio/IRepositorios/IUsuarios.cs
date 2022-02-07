using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAuth.Dominio
{
    public interface IUsuarios
    {
        Usuario ValidarUsuarioPorUsuarioYContrasenia(string correo, string contrasenia);

        void GuardarTokenUsuario(AgregadoToken tokenUsuario);


    }
}
