﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAuth.Aplicacion
{
    public interface IServicioUsuarioAuth
    {
        DtoUsuarioLoginRespuesta ValidarUsuario(string usuario, string contrasena);

        void ValidarToken(Guid idUsuario, string correo, string token);
    }
}
