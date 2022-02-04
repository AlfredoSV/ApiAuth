using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAuth.Aplicacion
{
    public class ServicioToken : IServicioToken
    {
        public string GenerarToken()
        {
            var token = string.Empty;
            var fecha = DateTime.Now;

            token = Guid.NewGuid().ToString() + ".";

            token += fecha.Minute.ToString() + fecha.Second + fecha.Millisecond;

            return token;
        }
    }
}
