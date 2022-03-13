using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAuth.Aplicacion.IServicios
{
    public interface IServicioCifrado
    {
        string Cifrar(string cadena);
        string Descifrar(string cadena);
        bool CadenaEsBase64(string cadena);
    }
}
