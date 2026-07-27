using Homework16.Models;
using Microsoft.EntityFrameworkCore;

namespace Homework16.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    public DbSet<Person> Persons { get; set; }
    public DbSet<Address> Addresses { get; set; }
}