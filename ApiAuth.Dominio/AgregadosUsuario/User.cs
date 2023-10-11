using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAuth.Dominio
{
    public class User
    {
        public Guid IdUser { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public User(Guid idUser, string email, string password)
        {
            IdUser = idUser;
            Email = email;
            Password = password;

        }

        public User( string correoUsuario, string contraseniaUsuario)
        {
            IdUser = Guid.NewGuid();
            Email = correoUsuario;
            Password = contraseniaUsuario;

        }

        public static User Create(string correoUsuario, string contraseniaUsuario)
        {
            return new User( correoUsuario,  contraseniaUsuario);
        }
    }
}
