using _01_EFC.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace _01_EFC.Contexts
{
    internal class DataContext : DbContext
    {
        private readonly string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HansMattin-Lassei\Documents\Utbildning\WIN22\win22-datalagring\Lektion-5\01_EFC\Contexts\sql_db.mdf;Integrated Security=True;Connect Timeout=30";

        #region constructors

        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        #endregion

        #region overrides

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        #endregion


        public DbSet<AddressEntity> Addresses { get; set; } = null!;
        public DbSet<CustomerEntity> Customers { get; set; } = null!;
        public DbSet<ProductEntity> Products { get; set; } = null!;
        public DbSet<EmployeeEntity> Employees { get; set; } = null!;

    }
}
