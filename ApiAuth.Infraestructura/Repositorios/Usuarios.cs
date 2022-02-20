﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiAuth.Dominio;
using Dapper;
using Dominio.ExcepcionComun;

namespace ApiAuth.Infraestructura
{
    public class Usuarios : IUsuarios
    {
        private string _cadConex { get; set; }
        public Usuarios(string cadConex)
        {
            _cadConex = cadConex;
        }
        public Usuario ValidarUsuarioPorUsuarioYContrasenia(string correo, string contrasenia)
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

        public void GuardarTokenUsuario(UsuarioToken tokenUsuario)
        {
            var sql = @"INSERT INTO usuarioToken VALUES(@idToken,@idUsuario,@token,@fechaAltaToken,@fechaVencimientoToken);";
            try
            {
                using (var con = new SqlConnection(_cadConex))
                {
                    con.Query(sql, tokenUsuario);
                }
            }
            catch (Exception e)
            {
                throw new ExcepcionComun("GuardarTokenUsuario", e.Message);
            }
        }

        public UsuarioToken ObtenerTokenPorIdUsuario(Guid idUsuario)
        {
            var sql = @"SELECT idToken ,idUsuario ,token ,fechaAltaToken ,fechaVencimientoToken  FROM usuarioToken;";
            try
            {
                using (var con = new SqlConnection(_cadConex))
                {
                    return con.Query<UsuarioToken>(sql, idUsuario).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                throw new ExcepcionComun("ObtenerTokenPorIdUsuario", e.Message);
            }
        }
    }
}
