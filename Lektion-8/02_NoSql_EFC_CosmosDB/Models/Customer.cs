﻿using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;

namespace _02_NoSql_EFC_CosmosDB.Models;

internal class Customer
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public byte[] Password { get; private set; } = null!;
    public byte[] SecurityKey { get; private set; } = null!;
    public string PartitionKey { get; set; } = "Customer";



    public void SetSecurePassword(string password)
    {
        using var hmac = new HMACSHA512();
        SecurityKey = hmac.Key;
        Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
    }
}
