using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAuth.Dominio
{
    public class User
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public User(Guid id, string email, string password)
        {
            Id = id;
            Email = email;
            Password = password;

        }

        public User( string email, string password)
        {
            Id = Guid.NewGuid();
            Email = email;
            Password = password;

        }

        public static User Create(string email, string password)
        {
            return new User( email,  password);
        }
    }
}
