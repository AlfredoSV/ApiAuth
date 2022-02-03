﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAuth.Dominio
{
    public class Usuario
    {
        public Guid Id { get; set; }

        public string Correo { get; set; }


        public Usuario(Guid id, string correo)
        {
            Id = id;
            Correo = correo;

        }


    }
}
