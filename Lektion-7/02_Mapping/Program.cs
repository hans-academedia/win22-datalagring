using _02_Mapping.Models;
using _02_Mapping.Models.Entitites;
using _02_Mapping.Services;

var customerService = new CustomerService();
var customerProfileService = new CustomerProfileService();

var customer = new Customer
{
    FirstName = "Hans",
    LastName = "Mattin-Lassei",
    Email = "hans.mattin-lassei@domain.com",
    StreetName = "Nordkapsvägen 1",
    PostalCode = "136 57",
    City = "Vega"
};


CustomerEntity customerEntity = customer;
customerEntity.SetSecurePassword("BytMig123!");
customerEntity = await customerService.CreateAsync(customerEntity);

CustomerProfileEntity customerProfileEntity = customer;
customerProfileEntity.CustomerId = customerEntity.Id;
customerProfileEntity = await customerProfileService.CreateAsync(customerProfileEntity);

Customer _customerProfile = customerProfileEntity;
_customerProfile.Email = customerEntity.Email;

Console.WriteLine($"{_customerProfile.FirstName} {_customerProfile.LastName}");
Console.WriteLine($"{_customerProfile.Email}");
Console.WriteLine($"{_customerProfile.StreetName}, {_customerProfile.PostalCode} {_customerProfile.City}");

Console.ReadKey();
