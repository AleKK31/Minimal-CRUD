using Microsoft.EntityFrameworkCore;
using MinimalApp.Data;
using MinimalApp.Models.Admin;

namespace MinimalApp.Routes;

public static class AdminRoute
{
    public static void AdminRoutes(this WebApplication app)
    {
        var route = app.MapGroup("admin");

        route.MapPost("",
            async (AdminRequest req, AppDbContext context, CancellationToken ct) =>
            {
                var admin = new AdminModel(req.Name, req.Email, req.Password);
                await context.Admins.AddAsync(admin, ct);
                await context.SaveChangesAsync(ct);
            }
        );

        route.MapGet("", 
            async (AppDbContext context, CancellationToken ct) =>
            {
                var admin = await context.Admins.ToListAsync(ct);
                return Results.Ok(admin);
            }
        );

        route.MapGet("{id:guid}", 
            async (Guid id, AppDbContext context, CancellationToken ct) =>
            {
                var admin = await context.Admins.FirstOrDefaultAsync(x => x.Id == id, ct);

                if (admin == null)
                {
                    return Results.NotFound();
                } else {
                    return Results.Ok(admin);
                }
            }
        );

        route.MapPut("{id:guid}",
            async (Guid id, AdminRequest req, AppDbContext context, CancellationToken ct) =>
            {
                var admin = await context.Admins.FirstOrDefaultAsync(x => x.Id == id, ct);

                if (admin == null)
                    return Results.NotFound();
                
                admin.Change(req.Name, req.Email, req.Password);
                await context.SaveChangesAsync(ct);

                return Results.Ok(admin);
            }
        );

        route.MapDelete("{id:guid}",
            async (Guid id, AppDbContext context, CancellationToken ct) =>
            {
                var admin = await context.Admins.FirstOrDefaultAsync(x => x.Id == id, ct);

                if (admin == null)
                    return Results.NotFound();
                
                context.Admins.Remove(admin);
                await context.SaveChangesAsync(ct);

                return Results.NoContent();
            }
        );
    }
}