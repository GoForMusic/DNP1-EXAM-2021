using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess;

public class Context : DbContext
{
    public DbSet<Player> Players {get;set;}
    public DbSet<Team> Teams { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = ..\DataAccess\Forum.db");
            optionsBuilder.EnableSensitiveDataLogging();
        }
}