using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAuth.Dominio
{
    public class Usuario
    {
        Guid Id { get; set; }
        string TokenSesion { get; set; }
        string Correo { get; set; }
        string Contrasenia { get; set; }

        public Usuario(Guid id, string tokenSesion, string correo, string contrasenia)
        {
            Id = id;
            TokenSesion = tokenSesion;
            Correo = correo;
            Contrasenia = contrasenia;
        }


    }
}
