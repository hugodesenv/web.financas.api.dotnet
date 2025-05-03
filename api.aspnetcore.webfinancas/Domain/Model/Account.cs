using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.aspnetcore.webfinancas.Domain.Model
{
    [Table("account")]
    public class Account
    {
        [Key]
        [MaxLength(40)]
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        public bool active { get; set; }

        public Account() { }
    }
}
