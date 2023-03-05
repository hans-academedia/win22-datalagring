using _03_NoSql_MongoDB.Models;
using _03_NoSql_MongoDB.Services;

var customer = new Customer();
Console.Write("Förnamn: ");
customer.FirstName = Console.ReadLine() ?? "";

Console.Write("Efternamn: ");
customer.LastName = Console.ReadLine() ?? "";

Console.Write("E-postadress: ");
customer.Email = Console.ReadLine() ?? "";

Console.Write("Lösenord: ");
customer.SetSecurePassword(Console.ReadLine() ?? "");

var customerService = new CustomerService("WIN22", "Customers", "mongodb+srv://win22:BytMig123!@cluster0.ecyuuhq.mongodb.net/WIN22?retryWrites=true&w=majority");
customerService.Initialize();
await customerService.AddAsync(customer);

Console.ReadKey();
Console.Clear();

foreach (var _customer in await customerService.GetAllAsync())
{
    Console.WriteLine($"{_customer.FirstName} {_customer.LastName}");
    Console.WriteLine($"{_customer.Email}");
    Console.WriteLine("");
}
Console.ReadKey();