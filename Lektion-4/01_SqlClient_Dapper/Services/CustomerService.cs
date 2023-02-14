using _01_SqlClient_Dapper.Models;
using _01_SqlClient_Dapper.Models.Entitites;

namespace _01_SqlClient_Dapper.Services
{
    internal class CustomerService
    {
        public static async Task SaveAsync(Customer customer)
        {
            var database = new DatabaseService();

            await database.SaveCustomerAsync(new CustomerEntity
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                AddressId = await database.GetOrSaveAddressAsync(new AddressEntity
                {
                    StreetName = customer.StreetName,
                    PostalCode = customer.PostalCode,
                    City = customer.City
                })
            });
        }

        public static async Task<IEnumerable<Customer>> GetAllAsync()
        {
            var database = new DatabaseService();
            return await database.GetAllCustomersAsync();
        }

        public static async Task<Customer> GetAsync(string email)
        {
            var database = new DatabaseService();
            return await database.GetCustomerAsync(email);
        }

        public static async Task UpdateAsync(Customer customer)
        {
            var database = new DatabaseService();

            var customerEntity = await database.GetCustomerEntityByIdAsync(customer.Id);
            if (!string.IsNullOrEmpty(customer.FirstName)) { customerEntity.FirstName = customer.FirstName; }
            if (!string.IsNullOrEmpty(customer.LastName)) { customerEntity.LastName = customer.LastName; }
            if (!string.IsNullOrEmpty(customer.Email)) { customerEntity.Email = customer.Email; }
            if (!string.IsNullOrEmpty(customer.PhoneNumber)) { customerEntity.PhoneNumber = customer.PhoneNumber; }

            var addressEntity = await database.GetAddressEntityByIdAsync(customerEntity.AddressId);
            if (!string.IsNullOrEmpty(customer.StreetName)) { addressEntity.StreetName = customer.StreetName; }
            if (!string.IsNullOrEmpty(customer.PostalCode)) { addressEntity.PostalCode = customer.PostalCode; }
            if (!string.IsNullOrEmpty(customer.City)) { addressEntity.City = customer.City; }
            
            customerEntity.AddressId = await database.GetOrSaveAddressAsync(addressEntity);

            await database.UpdateCustomerAsync(customerEntity);
        }

        public static async Task DeleteAsync(string email)
        {
            var database = new DatabaseService();
            await database.DeleteCustomerAsync(email);
        }
    }
}
