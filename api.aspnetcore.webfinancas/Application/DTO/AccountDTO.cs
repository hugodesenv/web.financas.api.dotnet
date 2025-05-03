using System.ComponentModel.DataAnnotations;

namespace api.aspnetcore.webfinancas.Application.DTO
{
    public class AuthenticationDTO
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
    }
}
