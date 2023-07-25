using Adapters.DrivenAdapter;
using API;
using Application;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



var optionsBuilder = new DbContextOptionsBuilder<PersonDbContext>();
optionsBuilder.UseSqlite("Data Source = sqlite.db");

PersonDbContext personDbContext = new(optionsBuilder.Options);
PersonRepository personRepository = new(personDbContext);
PersonService personService = new(personRepository);
PersonEndpoints personEndpoints = new(personService);


var app = builder.Build();

app.UseHttpsRedirection();


personEndpoints.Map(app);

app.Run();
