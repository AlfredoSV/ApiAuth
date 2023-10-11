using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ApiAuth.Dominio;
using Dapper;
using Dominio.ExcepcionComun;

namespace ApiAuth.Infrastructure
{
    public class RepositorioUsuarios : IRepositorioUsuarios
    {
        private string _cadConex { get; set; }
        public RepositorioUsuarios(string cadConex)
        {
            _cadConex = cadConex;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            string  sql =
            @"SELECT id, email,password from userApi where email = @email";
            try
            {
                using (var con = new SqlConnection(_cadConex))
                {
                    return (await con.QueryAsync<User>(sql, new { email })).FirstOrDefault();

                }
            }
            catch (Exception e)
            {
                throw new ExcepcionComun("GetUserByEmail", e.Message);
            }
        }

        public void SaveToken(UserToken userToken)
        {
            string sql = @"INSERT INTO userToken VALUES(@id,@userid,@token,@dateCreated,@dateExpired);";
            try
            {
                using (SqlConnection con = new SqlConnection(_cadConex))
                {
                    con.Query(sql, userToken);
                }
            }
            catch (Exception e)
            {
                throw new ExcepcionComun("SaveToken", e.Message);
            }
        }

        public UserToken GetTokenByUserId(Guid userId)
        {
            var sql = @"SELECT id ,userId ,token ,dateCreated ,dateExpired  FROM userToken where userId = @userId;";
            try
            {
                using (var con = new SqlConnection(_cadConex))
                {
                    return con.Query<UserToken>(sql, new { userId }).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                throw new ExcepcionComun("GetTokenByUserId", e.Message);
            }
        }

        public void DeleteTokensByUserId(Guid userId)
        {
            var sql = @"delete from userToken where userId = @userId;";
            try
            {
                using (var con = new SqlConnection(_cadConex))
                {
                    con.Query(sql, new { userId });
                }
            }
            catch (Exception e)
            {
                throw new ExcepcionComun("DeleteTokensByUserId", e.Message);
            }
        }

        public void SaveUser(User user)
        {
            var sql = @"INSERT INTO userApi VALUES(@id, @email, @password);";
            try
            {
                using (var con = new SqlConnection(_cadConex))
                {
                    con.Query(sql, user );
                }
            }
            catch (Exception e)
            {
                throw new ExcepcionComun("SaveUser", e.Message);
            }
        }

  
    }
}
