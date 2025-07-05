using System.ComponentModel.DataAnnotations;

namespace api.aspnetcore.webfinancas.Application.DTO.BankAccount
{
    public class BankAccountUpdateDTO : BankAccountUpInsertDTO
    {
        [Required]
        public int id { get; set; }
    }
}
