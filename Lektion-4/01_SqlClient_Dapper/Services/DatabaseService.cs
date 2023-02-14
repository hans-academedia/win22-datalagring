using _01_SqlClient_Dapper.Models.Entitites;
using Microsoft.Data.SqlClient;
using Dapper;
using _01_SqlClient_Dapper.Models;

namespace _01_SqlClient_Dapper.Services
{
    internal class DatabaseService
    {
        private readonly string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HansMattin-Lassei\Documents\Utbildning\WIN22\win22-datalagring\Lektion-4\01_SqlClient_Dapper\Data\local_sql_db.mdf;Integrated Security=True;Connect Timeout=30";

        public async Task SaveCustomerAsync(CustomerEntity customerEntity)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.ExecuteAsync("IF NOT EXISTS (SELECT Id FROM Customers WHERE Email = @Email) INSERT INTO Customers VALUES (@FirstName, @LastName, @Email, @PhoneNumber, @AddressId)", customerEntity);
        }


        public async Task<int> GetOrSaveAddressAsync(AddressEntity addressEntity)
        {
            using var conn = new SqlConnection(_connectionString);
            return await conn.ExecuteScalarAsync<int>("IF NOT EXISTS (SELECT Id FROM Addresses WHERE StreetName = @StreetName AND PostalCode = @PostalCode AND City = @City) INSERT INTO Addresses OUTPUT INSERTED.Id VALUES (@StreetName, @PostalCode, @City) ELSE SELECT Id FROM Addresses WHERE StreetName = @StreetName AND PostalCode = @PostalCode AND City = @City", addressEntity);
        }


        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            using var conn = new SqlConnection(_connectionString);
            return await conn.QueryAsync<Customer>("SELECT c.Id, c.FirstName, c.LastName, c.Email, PhoneNumber, a.StreetName, a.PostalCode, a.City FROM Customers c JOIN Addresses a ON c.AddressId = a.Id");
        }


        public async Task<Customer> GetCustomerAsync(string email)
        {
            using var conn = new SqlConnection(_connectionString);
            return await conn.QueryFirstOrDefaultAsync<Customer>("SELECT c.Id, c.FirstName, c.LastName, c.Email, PhoneNumber, a.StreetName, a.PostalCode, a.City FROM Customers c JOIN Addresses a ON c.AddressId = a.Id WHERE c.Email = @Email", new { Email = email });
        }


        public async Task<CustomerEntity> GetCustomerEntityByIdAsync(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            return await conn.QueryFirstOrDefaultAsync<CustomerEntity>("SELECT * FROM Customers WHERE Id = @Id", new { Id = id });
        }


        public async Task UpdateCustomerAsync(CustomerEntity customerEntity)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.ExecuteAsync("UPDATE Customers SET FirstName = @FirstName, LastName = @LastName, Email = @Email, PhoneNumber = @PhoneNumber, AddressId = @AddressId WHERE Id = @Id", customerEntity);
        }


        public async Task DeleteCustomerAsync(string email)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.ExecuteAsync("DELETE FROM Customers WHERE Email = @Email", new { Email = email });
        }

        public async Task<AddressEntity> GetAddressEntityByIdAsync(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            return await conn.QueryFirstOrDefaultAsync<AddressEntity>("SELECT * FROM Addresses WHERE Id = @Id", new { Id = id });
        }
    }
}
