using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAuth.Aplicacion
{
    public class DtoUsuarioLogin
    {
        public string CorreoUsuario { get; set; }
        public string ContrasenaUsuario { get; set; }
    }

    public class DtoUsuarioToken
    {
        public Guid IdUsuario { get; set; }
        public string TokenUsuario { get; set; }

    }
}
