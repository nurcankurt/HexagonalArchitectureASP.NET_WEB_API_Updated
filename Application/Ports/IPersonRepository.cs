using Domain;

namespace Application.Ports
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAllPeople();
        Task<Person?> GetPersonById(int id);
        Task UpdatePerson(int id, Person person);
        Task CreatePerson(Person person);
        Task DeletePerson(int id);

    }
}
