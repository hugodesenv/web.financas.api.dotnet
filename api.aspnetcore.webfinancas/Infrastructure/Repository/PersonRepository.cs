using api.aspnetcore.webfinancas.Domain.Interface;
using api.aspnetcore.webfinancas.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace api.aspnetcore.webfinancas.Infrastructure.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly DatabaseContext _database;

        public PersonRepository(DatabaseContext database) => _database = database;

        public async Task<List<Person>> findAll()
        {
            List<Person> people = await _database.Person.ToListAsync();
            return people;
        }

        public async Task<Person?> findByID(int id)
        {
            Person? person = await _database.Person.SingleOrDefaultAsync(p => p.id == id);
            return person;
        }

        public async Task<int> insert(Person person)
        {
            await _database.Person.AddAsync(person);
            await _database.SaveChangesAsync();

            return person.id;
        }
    }
}
