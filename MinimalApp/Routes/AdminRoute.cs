using Microsoft.EntityFrameworkCore;
using MinimalApp.Data;
using MinimalApp.Models;

namespace MinimalApp.Routes;

public static class AdminRoute
{
    public static void AdminRoutes(this WebApplication app)
    {
        var route = app.MapGroup("admin");

        route.MapPost("",
            async (AdminRequest req, AppDbContext context) =>
            {
                var admin = new AdminModel(req.Name, req.Email, req.Password);
                await context.Admins.AddAsync(admin);
                await context.SaveChangesAsync();
            }
        );

        route.MapGet("", 
            async (AppDbContext context) =>
            {
                var admin = await context.Admins.ToListAsync();
                return Results.Ok(admin);
            }
        );

        route.MapGet("{id:guid}", 
            async (Guid id, AppDbContext context) =>
            {
                var admin = await context.Admins.FirstOrDefaultAsync(x => x.Id == id);

                if (admin == null)
                {
                    return Results.NotFound();
                } else {
                    return Results.Ok(admin);
                }
            }
        );

        route.MapPut("{id:guid}",
            async (Guid id, AdminRequest req, AppDbContext context) =>
            {
                var admin = await context.Admins.FirstOrDefaultAsync(x => x.Id == id);

                if (admin == null)
                    return Results.NotFound();
                
                admin.Change(req.Name, req.Email, req.Password);
                await context.SaveChangesAsync();

                return Results.Ok(admin);
            }
        );

        route.MapDelete("{id:guid}",
            async (Guid id, AppDbContext context) =>
            {
                var admin = await context.Admins.FirstOrDefaultAsync(x => x.Id == id);

                if (admin == null)
                    return Results.NotFound();
                
                context.Admins.Remove(admin);
                await context.SaveChangesAsync();

                return Results.NoContent();
            }
        );
    }
}