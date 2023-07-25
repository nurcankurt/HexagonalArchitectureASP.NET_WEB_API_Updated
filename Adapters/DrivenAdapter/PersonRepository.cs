using Application.Ports;
using Domain;

using Microsoft.EntityFrameworkCore;

namespace Adapters.DrivenAdapter
{
    public class PersonRepository : IPersonRepository
    {
        private readonly PersonDbContext _dbContext;

        public PersonRepository(PersonDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Person>> GetAllPeople()
        {
            return await _dbContext.People.ToListAsync();
        }


        public async Task<Person?> GetPersonById(int id)
        {
            return await _dbContext.People.FindAsync(id);
        }

        public async Task CreatePerson(Person person)
        {
            _dbContext.People.Add(person);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdatePerson(int id, Person person)
        {
            var dbPerson = await _dbContext.People.FindAsync(id);
            if (dbPerson != null)
            {
                dbPerson.FirstName = person.FirstName;
                dbPerson.LastName = person.LastName;
                dbPerson.Email = person.Email;
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task DeletePerson(int id)
        {
            var dbPerson = await _dbContext.People.FindAsync(id);
            if (dbPerson != null)
            {
                _dbContext.Remove(dbPerson);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
