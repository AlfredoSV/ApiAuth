using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAuth.Dominio
{
    public class Usuario
    {
        public Guid IdUsuario { get; set; }

        public string CorreoUsuario { get; set; }

        public string ContraseniaUsuario { get; set; }

        public Usuario(Guid idUsuario, string correoUsuario)
        {
            IdUsuario = idUsuario;
            CorreoUsuario = correoUsuario;

        }

        public Usuario( string correoUsuario, string contraseniaUsuario)
        {
            IdUsuario = Guid.NewGuid();
            CorreoUsuario = correoUsuario;
            ContraseniaUsuario = contraseniaUsuario;

        }

        public static Usuario Crear(string correoUsuario, string contraseniaUsuario)
        {
            return new Usuario( correoUsuario,  contraseniaUsuario);
        }
    }
}
