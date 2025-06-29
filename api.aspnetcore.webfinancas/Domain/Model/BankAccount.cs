using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.aspnetcore.webfinancas.Domain.Model
{
    [Table("bank_account")]
    public class BankAccount
    {
        [Key]
        public int id { get; set; }

        [MaxLength(50)]
        public string description { get; set; }
    }
}
