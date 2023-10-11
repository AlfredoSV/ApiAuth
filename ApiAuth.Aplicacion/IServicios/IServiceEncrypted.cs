using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAuth.Aplicacion.IServicios
{
    public interface IServiceEncrypted
    {
        string Encrypted(string str);
        string Decrypt(string str);
        bool StrIsBase64(string str);
    }
}
