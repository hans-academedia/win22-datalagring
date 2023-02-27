using _01_Mapping.DirectMapping.Models.Entitites;
using Microsoft.EntityFrameworkCore;

namespace _01_Mapping.Contexts;

public class DataContext : DbContext
{
    public DataContext()
    {

    }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HansMattin-Lassei\Documents\Utbildning\WIN22\win22-datalagring\Lektion-7\01_Mapping\Contexts\local_sqldb.mdf;Integrated Security=True;Connect Timeout=30");
    }

    public DbSet<CustomerEntity> Customers { get; set; }
}
