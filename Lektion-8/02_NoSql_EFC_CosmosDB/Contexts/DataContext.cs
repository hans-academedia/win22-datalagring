using _02_NoSql_EFC_CosmosDB.Models;
using Microsoft.EntityFrameworkCore;

namespace _02_NoSql_EFC_CosmosDB.Contexts;

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
        optionsBuilder.UseCosmos("AccountEndpoint=https://win22-cosmosdb.documents.azure.com:443/;AccountKey=Qf7EAJm24eBahAQzKapfFSHYDsRuqxaOWzK5WtZVek0aWDlSsLS5uPc1moTDoeaD9kPraIT3ChcdACDbHbLTwg==;", "WIN22");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().ToContainer("Customers").HasPartitionKey(x => x.PartitionKey);
    }

    #endregion

    public DbSet<Customer> Customers { get; set; }
}
