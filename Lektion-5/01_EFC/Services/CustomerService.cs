using _01_EFC.Models.Entities;
using _01_EFC.Models;
using _01_EFC.Contexts;
using Microsoft.EntityFrameworkCore;

namespace _01_EFC.Services
{
    internal class CustomerService
    {
        private static DataContext _context = new DataContext();

        public static async Task SaveAsync(Customer customer)
        {
            var _customerEntity = new CustomerEntity
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
            };

            var _addressEntity = await _context.Addresses.FirstOrDefaultAsync(x => x.StreetName == customer.StreetName && x.PostalCode == customer.PostalCode && x.City == customer.City);
            if (_addressEntity != null)
                _customerEntity.AddressId = _addressEntity.Id;
            else
                _customerEntity.Address = new AddressEntity
                {
                    StreetName = customer.StreetName,
                    PostalCode = customer.PostalCode,
                    City = customer.City
                };

            _context.Add(_customerEntity);
            await _context.SaveChangesAsync();
        }

        public static async Task<IEnumerable<Customer>> GetAllAsync()
        {
            var _customers = new List<Customer>();

            foreach (var _customer in await _context.Customers.Include(x => x.Address).ToListAsync())
                _customers.Add(new Customer
                {
                    Id = _customer.Id,
                    FirstName = _customer.FirstName,
                    LastName = _customer.LastName,
                    Email = _customer.Email,
                    PhoneNumber = _customer.PhoneNumber,
                    StreetName = _customer.Address.StreetName,
                    PostalCode = _customer.Address.PostalCode,
                    City = _customer.Address.City
                });
            
            return _customers;
        }

        public static async Task<Customer> GetAsync(string email)
        {
            var _customer = await _context.Customers.Include(x => x.Address).FirstOrDefaultAsync(x => x.Email == email);
            if (_customer != null)
                return new Customer
                {
                    Id = _customer.Id,
                    FirstName = _customer.FirstName,
                    LastName = _customer.LastName,
                    Email = _customer.Email,
                    PhoneNumber = _customer.PhoneNumber,
                    StreetName = _customer.Address.StreetName,
                    PostalCode = _customer.Address.PostalCode,
                    City = _customer.Address.City
                };

            else
                return null!;
        }

        public static async Task UpdateAsync(Customer customer)
        {
            var _customerEntity = await _context.Customers.Include(x => x.Address).FirstOrDefaultAsync(x => x.Id == customer.Id);
            if (_customerEntity != null)
            {
                if (!string.IsNullOrEmpty(customer.FirstName))
                    _customerEntity.FirstName = customer.FirstName;

                if (!string.IsNullOrEmpty(customer.LastName))
                    _customerEntity.LastName = customer.LastName;

                if (!string.IsNullOrEmpty(customer.Email))
                    _customerEntity.Email = customer.Email;

                if (!string.IsNullOrEmpty(customer.PhoneNumber))
                    _customerEntity.PhoneNumber = customer.PhoneNumber;

                if (!string.IsNullOrEmpty(customer.StreetName) || !string.IsNullOrEmpty(customer.PostalCode) || !string.IsNullOrEmpty(customer.City)) 
                {
                    var _addressEntity = await _context.Addresses.FirstOrDefaultAsync(x => x.StreetName == customer.StreetName && x.PostalCode == customer.PostalCode && x.City == customer.City);
                    if (_addressEntity != null)
                        _customerEntity.AddressId = _addressEntity.Id;
                    else
                        _customerEntity.Address = new AddressEntity
                        {
                            StreetName = customer.StreetName,
                            PostalCode = customer.PostalCode,
                            City = customer.City
                        };
                }

                _context.Update(_customerEntity);
                await _context.SaveChangesAsync();

            }
        }

        public static async Task DeleteAsync(string email)
        {
            var customer = await _context.Customers.Include(x => x.Address).FirstOrDefaultAsync(x => x.Email == email);
            if (customer != null)
            {
                _context.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }
    }
}
