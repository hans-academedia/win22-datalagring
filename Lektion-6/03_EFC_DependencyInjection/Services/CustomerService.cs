using _03_EFC_DependencyInjection.Contexts;
using _03_EFC_DependencyInjection.Models.Entitites;
using Microsoft.EntityFrameworkCore;

namespace _03_EFC_DependencyInjection.Services
{
    public class CustomerService
    {
        private readonly DataContext _context;

        public CustomerService(DataContext context)
        {
            _context = context;
        }

        public async Task SaveAsync(CustomerEntity customer)
        {
            _context.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CustomerEntity>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<CustomerEntity> GetAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
                return customer;

            return null!;
        }
    }
}
