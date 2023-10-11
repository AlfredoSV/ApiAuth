using Dominio.ExcepcionComun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAuth.Dominio
{
    public class UserToken
    {
        public Guid Id { get; private set; }
        public string Token { get; private set; }
        public DateTime DateCreated { get; private set; }
        public DateTime DateExpired { get; private set; }
        public Guid UserId { get; private set; }

        private UserToken(Guid id, Guid userId, string token, DateTime dateCreated, DateTime dateExpired)
        {
            
            if (id == Guid.Empty)
                throw new ExcepcionComun("Valor requerido", "El IdToken es requerido");
            Id = id;
            if (token.Equals("") || token == null)
                throw new ExcepcionComun("Valor requerido", "El Token es requerido");
            Token = token;
            if (dateCreated == DateTime.MinValue || dateCreated == DateTime.MaxValue)
                throw new ExcepcionComun("Valor invalido", "La FechaAltaToken no es valida");
            DateCreated = dateCreated;
            if (dateExpired == DateTime.MinValue || dateExpired == DateTime.MaxValue)
                throw new ExcepcionComun("Valor invalido", "La FechaVencimientoToken no es valida");
            DateExpired = dateExpired;
            if (userId == Guid.Empty)
                throw new ExcepcionComun("Valor requerido", "El IdUsuario es requerido");
            UserId = userId;
        }


        public static UserToken Create(Guid id, Guid userId, string token, DateTime dateCreated, DateTime dateExpired)
        {
            return new UserToken(id, userId, token, dateCreated, dateExpired);
        }

    }
}
