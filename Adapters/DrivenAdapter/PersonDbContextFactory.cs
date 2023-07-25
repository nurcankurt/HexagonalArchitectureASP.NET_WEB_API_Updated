using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;


namespace Adapters.DrivenAdapter
{
   
        public class PersonDbContextFactory : IDesignTimeDbContextFactory<PersonDbContext>
        {
            public PersonDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<PersonDbContext>();
                optionsBuilder.UseSqlite("Data Source = sqlite.db");

                return new PersonDbContext(optionsBuilder.Options);
            }
        }
    
}
