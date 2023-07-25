using Application.Ports;
using Domain;


namespace Application
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public Task CreatePerson(Person person)
        {
            return _personRepository.CreatePerson(person);
        }

        public Task DeletePerson(int id)
        {
            return _personRepository.DeletePerson(id);
        }

        public Task<IEnumerable<Person>> GetAllPeople()
        {
            return _personRepository.GetAllPeople();
        }

        public Task<Person?> GetPersonById(int id)
        {
            return _personRepository.GetPersonById(id);
        }

        public Task UpdatePerson(int id, Person person)
        {
            return _personRepository.UpdatePerson(id, person);
        }
    }
}
