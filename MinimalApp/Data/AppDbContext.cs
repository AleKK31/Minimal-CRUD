using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MinimalApp.Models.Admin;
using MinimalApp.Models.Person;

namespace MinimalApp.Data;

public class AppDbContext : DbContext
{
    public DbSet<AdminModel> Admins { get; set; }
    public DbSet<PersonModel> Persons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=WebApp.sqlite");
        base.OnConfiguring(optionsBuilder);
    }
}