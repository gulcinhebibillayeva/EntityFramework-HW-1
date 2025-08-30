
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ADO_NET_03_Homework;

internal class UserContext : DbContext
{


    private readonly string _connectionString;

    public UserContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
    }


    public UserContext()
    {
  
    }

}