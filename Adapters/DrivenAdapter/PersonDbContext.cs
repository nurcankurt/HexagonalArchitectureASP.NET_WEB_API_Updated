using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Adapters.DrivenAdapter
{
    public class PersonDbContext : DbContext
    {
        public PersonDbContext(DbContextOptions options) :
            base(options)
        {

        }
        public DbSet<Person> People { get; set; }

    }
}
