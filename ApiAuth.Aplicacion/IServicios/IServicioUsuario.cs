using ApiAuth.Aplicacion.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAuth.Aplicacion.IServicios
{
    public interface IServicioUsuario
    {
        public void CrearUsuario(DtoUsuario dtoUsuario);
    }
}
