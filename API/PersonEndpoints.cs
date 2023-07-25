
using Application.Ports;
using Domain;


namespace API
{
    public class PersonEndpoints
    {
        private readonly IPersonService _service;

        public PersonEndpoints(IPersonService personService)
        {
            _service = personService;
        }

        public void Map(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/api/people", GetAllPeopleAsync);

            endpoints.MapGet("/api/people/{id:int}", GetPersonByIdAsync);

            endpoints.MapPost("/api/people", CreatePersonAsync);

            endpoints.MapPut("/api/people/{id:int}", UpdatePersonAsync);

            endpoints.MapDelete("/api/people/{id:int}", DeletePersonAsync);
        }

        private async Task GetAllPeopleAsync(HttpContext context)
        {
            var people = await _service.GetAllPeople();
            await context.Response.WriteAsJsonAsync(people);
        }

        private async Task GetPersonByIdAsync(HttpContext context)
        {
            var routeData = context.GetRouteData();
            int id = Convert.ToInt32(routeData.Values["id"]);
            var person = await _service.GetPersonById(id);

            if (person is null)
            {
                context.Response.StatusCode = 404;
                return;
            }

            await context.Response.WriteAsJsonAsync(person);
        }

        private async Task CreatePersonAsync(HttpContext context)
        {
            var person = await context.Request.ReadFromJsonAsync<Person>();

            if (person is null)
            {
                context.Response.StatusCode = 400;
                return;
            }

            await _service.CreatePerson(person);

            context.Response.StatusCode = 201;
            context.Response.Headers["Location"] = $"/api/people/{person.Id}";
            await context.Response.WriteAsJsonAsync(person);
        }

        private async Task UpdatePersonAsync(HttpContext context)
        {
            var routeData = context.GetRouteData();
            int id = Convert.ToInt32(routeData.Values["id"]);
            var person = await context.Request.ReadFromJsonAsync<Person>();

            var entity = await _service.GetPersonById(id);

            if (entity is null)
            {
                context.Response.StatusCode = 404;
                return;
            }

            await _service.UpdatePerson(id, person);
            var updatedPeople = await _service.GetAllPeople();
            await context.Response.WriteAsJsonAsync(updatedPeople);
        }

        private async Task DeletePersonAsync(HttpContext context)
        {
            var routeData = context.GetRouteData();
            int id = Convert.ToInt32(routeData.Values["id"]);
            var entity = await _service.GetPersonById(id);

            if (entity is null)
            {
                context.Response.StatusCode = 404;
                return;
            }

            await _service.DeletePerson(id);
            context.Response.StatusCode = 200;
        }
    }
}