using System.ComponentModel.DataAnnotations;

namespace api.aspnetcore.webfinancas.Application.DTO.BankAccount
{
    public class BankAccountInsertDTO
    {
        [Required]
        public string description { get; set; }
    }
}
