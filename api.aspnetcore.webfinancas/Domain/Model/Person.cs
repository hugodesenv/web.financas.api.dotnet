using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.aspnetcore.webfinancas.Domain.Model
{
    [Table("person")]
    public class Person
    {
        [Key]
        public int id { get; set; }

        [Required]
        [MaxLength(80)]
        public string name { get; set; }

        [MaxLength(80)]
        public string? nickname { get; set; }

        public bool active { get; set; }

        public bool is_client { get; set; }

        public bool is_company { get; set; }

        public bool is_employee { get; set; }
    }
}
