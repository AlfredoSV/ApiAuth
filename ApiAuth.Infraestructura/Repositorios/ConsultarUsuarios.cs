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
            var sql = @"SELECT idUsuario, correoUsuario from usuario where correoUsuario = @correoUsuario and contraseniaUsuario = @contraseniaUsuario";
            try
            {
                using (var con = new SqlConnection(_cadConex))
                {
                    return con.Query<Usuario>(sql, new { correoUsuario = correo, contraseniaUsuario = contrasenia }).FirstOrDefault();

                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
