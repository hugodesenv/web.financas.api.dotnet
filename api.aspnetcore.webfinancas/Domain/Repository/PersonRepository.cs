using api.aspnetcore.webfinancas.Application.DTO.Person;
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

        public async Task<bool> Update(PersonUpdateDTO person)
        {
            Person? _person = database.Person.FirstOrDefault(p => p.id == person.id);

            if (_person == null)
            {
                throw new Exception("Person not found");
            }

            _person.name = person.name;
            _person.is_client = person.is_client;
            _person.is_employee = person.is_employee;
            _person.is_customer = person.is_customer;
            _person.active = person.active;

            database.Person.Update(_person);

            int rowsAffected = database.SaveChanges();
            
            return rowsAffected > 0;
        }
    }
}
