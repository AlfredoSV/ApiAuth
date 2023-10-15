using System.ComponentModel.DataAnnotations;


namespace ApiAuth.Aplicacion.Dtos
{
    public class DtoUser
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
