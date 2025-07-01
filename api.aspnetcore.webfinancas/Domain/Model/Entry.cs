using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace api.aspnetcore.webfinancas.Domain.Model
{
    [Table("entry")]
    public class Entry
    {
        [Key]
        public int id { get; set; }

        // payable or receivable
        [Required]
        public String type { get; set; }

        [Required]
        public int person_id { get; set; }

        [ForeignKey("person_id")]
        public Person person { get; set; }

        [Required]
        public int purpose_id { get; set; }

        [ForeignKey("purpose_id")]
        public Purpose purpose { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime issue_date { get; set; }

        public String observation { get; set; }

        // Predicted or regular
        [Required]
        public String mode { get; set; }

        [Required]
        public int bank_account_id { get; set; }

        [ForeignKey("bank_account_id")]
        public BankAccount bankAccount { get; set; }

        [NotNull]
        public double total { get; set; }
    }
}
