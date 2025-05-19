using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.aspnetcore.webfinancas.Domain.Model
{
    [Table("purpose")]
    public class Purpose
    {
        [Key]
        public int id { get; set; }

        [MaxLength(40)]
        public string description { get; set; }
    }
}
