using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAuth.Dominio
{
    public interface IConsultarUsuarios
    {
        Usuario validarUsuarioPorUsuarioYContrasenia(string correo, string contrasenia);
    }
}
