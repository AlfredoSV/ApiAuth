using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAuth.Dominio
{
    public class Token
    {
        public string Valor { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public Guid IdUsuario { get; set; }

    }
}
