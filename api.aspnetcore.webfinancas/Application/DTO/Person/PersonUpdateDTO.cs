using System.ComponentModel.DataAnnotations;

namespace api.aspnetcore.webfinancas.Application.DTO.Person
{
     public class PersonUpdateDTO
    {
        [Required]
        public int id { get; set; }
        public PersonData data { get; set; }

        public PersonType type { get; set; }
    }

    public class PersonData
    {
        public string name { get; set; }
        public string nickname { get; set; }
        public bool active { get; set; }
    }
    
    public class PersonType
    {
        public bool client { get; set; }
        public bool company { get; set; }
        public bool employee { get; set; }
    }
}
