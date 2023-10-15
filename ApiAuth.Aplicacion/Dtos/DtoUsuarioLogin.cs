using System;
using System.ComponentModel.DataAnnotations;


namespace ApiAuth.Aplicacion
{
    public class DtoUserLogin
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }

    public class DtoUserToken
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Token { get; set; }

    }
}
