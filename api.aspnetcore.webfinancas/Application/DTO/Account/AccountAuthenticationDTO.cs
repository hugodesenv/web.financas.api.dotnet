using System.ComponentModel.DataAnnotations;

namespace api.aspnetcore.webfinancas.Application.DTO.Account
{
    public class AccountAuthenticationDTO
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
    }
}
