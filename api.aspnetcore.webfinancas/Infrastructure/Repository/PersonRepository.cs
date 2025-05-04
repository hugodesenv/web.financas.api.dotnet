using api.aspnetcore.webfinancas.Domain.Model;
using api.aspnetcore.webfinancas.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace api.aspnetcore.webfinancas.Infrastructure.Repository
{
    public class PersonRepository(DatabaseContext database) : IPersonRepository
    {
        public async Task<List<Person>> FindAll()
        {
            List<Person> people = await database.Person.ToListAsync();
            return people;
        }

        public async Task<Person?> FindByID(int id)
        {
            Person? person = await database.Person.SingleOrDefaultAsync(p => p.id == id);
            return person;
        }

        public async Task<int> Insert(Person person)
        {
            await database.Person.AddAsync(person);
            await database.SaveChangesAsync();

            return person.id;
        }
    }
}
