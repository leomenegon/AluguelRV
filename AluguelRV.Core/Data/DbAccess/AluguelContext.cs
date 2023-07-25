using AluguelRV.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AluguelRV.Core.Data.DbAccess;
public class AluguelContext : DbContext
{
    public AluguelContext(DbContextOptions options) : base(options) { }

    public DbSet<Rent> Rents { get; set; }
    public DbSet<Expense> Expenses { get; set; }
    public DbSet<Person> People { get; set; }
    public DbSet<ExpensePerson> ExpensePeople { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

        var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => type.Namespace != null && type.Namespace.Contains("AluguelRV.Core.Data.EntityConfig"))
            .Where(type => type.BaseType != null)
            .Where(type => type.Name.Length > 5);

        foreach (var type in typesToRegister)
        {
            dynamic configInstance = Activator.CreateInstance(type);
            modelBuilder.ApplyConfiguration(configInstance);
        }
    }

    public string GetConnectionString()
    {
        return Database.GetDbConnection().ConnectionString;
    }
}