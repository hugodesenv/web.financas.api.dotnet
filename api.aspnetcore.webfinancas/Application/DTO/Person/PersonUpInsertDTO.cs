// Commom class between insert and update.

using System.ComponentModel.DataAnnotations;

namespace api.aspnetcore.webfinancas.Application.DTO.Person
{
    public class PersonUpInsertDTO
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

        public bool is_customer { get; set; }

        public bool is_employee { get; set; }
    }
}
