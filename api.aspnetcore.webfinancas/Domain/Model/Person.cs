using api.aspnetcore.webfinancas.Application.DTO.Person;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.aspnetcore.webfinancas.Domain.Model
{
    [Table("person")]
    public class Person : PersonUpInsertDTO
    {
    }
}
