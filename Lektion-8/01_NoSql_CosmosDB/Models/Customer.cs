using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;

namespace _01_NoSql_CosmosDB.Models;

internal class Customer
{
    [JsonProperty("id")]
    public Guid Id { get; set; } = Guid.NewGuid();

    [JsonProperty("firstName")]
    public string FirstName { get; set; } = null!;

    [JsonProperty("lastName")]
    public string LastName { get; set;} = null!;

    [JsonProperty("email")] 
    public string Email { get; set; } = null!;

    [JsonProperty("password")]
    public byte[] Password { get; private set; } = null!;

    [JsonProperty("securityKey")]
    public byte[] SecurityKey { get; private set; } = null!;

    [JsonProperty("partitionKey")]
    public string PartitionKey { get; set; } = "Customer";
    
    
    
    public void SetSecurePassword(string password)
    {
        using var hmac = new HMACSHA512();
        SecurityKey = hmac.Key;
        Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
    }
}
