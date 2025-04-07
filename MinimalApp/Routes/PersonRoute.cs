using MinimalApp.Models.Person;
using Microsoft.EntityFrameworkCore;
using MinimalApp.Data;

namespace MinimalApp.Routes;

public static class PersonRoute
{
    public static void PersonRoutes(this WebApplication app)
    {
        var route = app.MapGroup("person");

        route.MapPost("",
            async (PersonRequest req, AppDbContext context, CancellationToken ct) =>
            {
                var person = new PersonModel(req.FirstName, req.LastName, req.DateOfBirth, req.Email, req.Password, req.DocumentNumber, req.Phone);
                await context.Persons.AddAsync(person, ct);
                await context.SaveChangesAsync(ct);
            }
        );

        route.MapGet("",
            async (AppDbContext context, CancellationToken ct) =>
            {
                var person = await context.Persons.ToListAsync(ct);
                return Results.Ok(person);
            }
        );

        route.MapGet("{id:guid}",
            async (Guid id, AppDbContext context, CancellationToken ct) =>
            {
                var person = await context.Persons.FirstOrDefaultAsync(x => x.Id == id, ct);

                if (person == null)
                {
                    return Results.NotFound();
                }
                else
                {
                    return Results.Ok(person);
                }
            }
        );

        route.MapPut("{id:guid}",
            async (Guid id, PersonRequest req, AppDbContext context, CancellationToken ct) =>
            {
                var person = await context.Persons.FirstOrDefaultAsync(x => x.Id == id, ct);

                if (person == null)
                    return Results.NotFound();

                person.Change(req.FirstName, req.LastName, req.DateOfBirth, req.Email, req.Password, req.DocumentNumber, req.Phone);
                await context.SaveChangesAsync(ct);

                return Results.Ok(person);
            }
        );

        route.MapDelete("{id:guid}",
            async (Guid id, AppDbContext context, CancellationToken ct) =>
            {
                var person = await context.Persons.FirstOrDefaultAsync(x => x.Id == id, ct);

                if (person == null)
                    return Results.NotFound();

                context.Persons.Remove(person);
                await context.SaveChangesAsync(ct);

                return Results.Ok(person);
            }
        );
    }
}