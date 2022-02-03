using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiAuth.Dominio;
using Dapper;

namespace ApiAuth.Infraestructura
{
    public class ConsultarUsuarios : IConsultarUsuarios
    {
        private string _cadConex { get; set; }
        public ConsultarUsuarios(string cadConex)
        {
            _cadConex = cadConex;
        }
        public Usuario validarUsuarioPorUsuarioYContrasenia(string correo, string contrasenia)
        {
            var sql = @"";
            try
            {
                using (var con = new SqlConnection(_cadConex))
                {
                    return con.Query<Usuario>(sql, new { correo, contrasenia }).FirstOrDefault();

                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
