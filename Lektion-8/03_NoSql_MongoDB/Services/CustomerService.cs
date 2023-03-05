using _03_NoSql_MongoDB.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace _03_NoSql_MongoDB.Services;

internal class CustomerService
{
    private string _databaseName;
    private string _collectionName;
    private string _connectionString;
    private IMongoDatabase _mongoDB;
    private IMongoCollection<Customer> _collection;

    public CustomerService(string databaseName, string collectionName, string connectionString)
    {
        _databaseName = databaseName;
        _collectionName = collectionName;
        _connectionString = connectionString;
    }

    public void Initialize()
    {
        var settings = MongoClientSettings.FromConnectionString(_connectionString);
        var client = new MongoClient(settings);
        _mongoDB = client.GetDatabase(_databaseName);
        _collection = _mongoDB.GetCollection<Customer>(_collectionName);
    }

    public async Task AddAsync(Customer customer)
    {
        await _collection.InsertOneAsync(customer);
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        var result = await _collection.FindAsync(new BsonDocument());
        return await result.ToListAsync();
    }

    public async Task<Customer> GetAsync(string email)
    {
        var filter = Builders<Customer>.Filter.Eq(customer => customer.Email, email);
        var result = await _collection.FindAsync(filter);
        var customer = await result.FirstOrDefaultAsync();

        if (customer != null)
            return customer;

        return null!;
    }
}
