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


        public Usuario(Guid idUsuario, string correoUsuario)
        {
            IdUsuario = idUsuario;
            CorreoUsuario = correoUsuario;

        }


    }
}
