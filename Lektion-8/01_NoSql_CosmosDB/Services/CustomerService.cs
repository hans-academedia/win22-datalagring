using _01_NoSql_CosmosDB.Models;
using Microsoft.Azure.Cosmos;

namespace _01_NoSql_CosmosDB.Services;

internal class CustomerService
{
    private string _containerName;
    private string _databaseName;
    private string _connectionString;
    private Database _cosmosdb;
    private Container _container;
    private CosmosClient _cosmosClient;

    public CustomerService(string databaseName, string containerName, string connectionString)
    {
        _databaseName = databaseName;
        _containerName = containerName;
        _connectionString = connectionString;      
    }

    public async Task InitializeAsync()
    {
        _cosmosClient = new CosmosClient(_connectionString);
        _cosmosdb = await _cosmosClient.CreateDatabaseIfNotExistsAsync(_databaseName);
        _container = await _cosmosdb.CreateContainerIfNotExistsAsync(_containerName, "/partitionKey");
    }

    public async Task<Customer> AddAsync(Customer customer)
    {
        var res = await _container.CreateItemAsync(customer);
        return res.Resource;
    }

    public async Task<IEnumerable<Customer>> GetAsync(string query)
    {
        var iterator = _container.GetItemQueryIterator<Customer>(new QueryDefinition(query));

        var records = new List<Customer>();
        while (iterator.HasMoreResults)
        {
            var result = await iterator.ReadNextAsync();
            foreach (var item in result)
                records.Add(item);
        }

        return records;
    }
}
