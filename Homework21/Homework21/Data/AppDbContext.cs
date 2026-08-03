using Homework21.Models;
using Microsoft.EntityFrameworkCore;

namespace Homework21.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Person> Persons { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Person>()
            .OwnsOne(p => p.PersonAddress);
        
        modelBuilder.Entity<Person>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();
    }
}