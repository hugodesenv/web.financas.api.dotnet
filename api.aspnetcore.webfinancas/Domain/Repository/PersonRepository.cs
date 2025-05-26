using api.aspnetcore.webfinancas.Domain.Model;
using api.aspnetcore.webfinancas.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace api.aspnetcore.webfinancas.Domain.Repository
{
    public class PersonRepository(DatabaseContext database) : IPersonRepository
    {
        public async Task<bool> Delete(Person person)
        {
            database.Person.Remove(person);
            int rowsAffected = await database.SaveChangesAsync();
                
            return rowsAffected > 0;          
        }

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

        public async Task<bool> Update(Person person)
        {
            database.Person.Update(person);

            int rowsAffected = database.SaveChanges();
            
            return rowsAffected > 0;
        }
    }
}
