using _03_EFC_DependencyInjection.Models.Entitites;
using Microsoft.EntityFrameworkCore;

namespace _03_EFC_DependencyInjection.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<CustomerEntity> Customers { get; set; }
    }
}
