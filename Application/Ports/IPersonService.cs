using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Ports
{
    public interface IPersonService
    {
        Task<IEnumerable<Person>> GetAllPeople();
        Task<Person?> GetPersonById(int id);
        Task UpdatePerson(int id, Person person);
        Task CreatePerson(Person person);
        Task DeletePerson(int id);
    }
}
