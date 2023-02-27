using _02_Mapping.Models.Entitites;
using Microsoft.EntityFrameworkCore;

namespace _02_Mapping.Contexts;

internal class DataContext : DbContext
{
    #region constructors & overrides
    public DataContext()
    {

    }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HansMattin-Lassei\Documents\Utbildning\WIN22\win22-datalagring\Lektion-7\02_Mapping\Contexts\sql_db.mdf;Integrated Security=True;Connect Timeout=30");
    }

    #endregion

    public DbSet<CustomerEntity> Customers { get; set; } = null!;
    public DbSet<CustomerProfileEntity> CustomersProfiles { get; set; } = null!;
}
