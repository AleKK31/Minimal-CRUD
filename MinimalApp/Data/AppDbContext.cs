using Microsoft.EntityFrameworkCore;
using MinimalApp.Models;

namespace MinimalApp.Data;

public class AppDbContext : DbContext
{
    public DbSet<AdminModel> Admins { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=WebApp.sqlite");
        base.OnConfiguring(optionsBuilder);
    }
}