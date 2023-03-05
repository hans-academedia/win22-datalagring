using _02_NoSql_EFC_CosmosDB.Contexts;
using _02_NoSql_EFC_CosmosDB.Models;
using Microsoft.EntityFrameworkCore;

namespace _02_NoSql_EFC_CosmosDB.Services;

internal class CustomerService
{
    private readonly DataContext _context;

    public CustomerService()
    {
        _context = new DataContext();
    }

    public async Task AddAsync(Customer customer)
    {
        _context.Add(customer);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        return await _context.Customers.ToListAsync();
    }

    public async Task<Customer> GetAsync(Func<Customer, bool> predicate)
    {
        var customer = await _context.Customers.FindAsync(predicate);
        if (customer != null)
            return customer;

        return null!;
    }
}
