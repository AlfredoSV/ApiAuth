﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAuth.Aplicacion
{
    public interface IServicioUsuarioAuth
    {
        public void ValidarUsuario(string usuario, string contrasena);
    }
}
