using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAuth.Aplicacion
{
    public class DtoUserLogin
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class DtoUserToken
    {
        public Guid Id { get; set; }
        public string Token { get; set; }

    }
}
