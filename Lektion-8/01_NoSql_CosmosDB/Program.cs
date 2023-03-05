using _01_NoSql_CosmosDB.Models;
using _01_NoSql_CosmosDB.Services;

var customerService = new CustomerService("WIN22", "Customers", "AccountEndpoint=https://win22-cosmosdb.documents.azure.com:443/;AccountKey=Qf7EAJm24eBahAQzKapfFSHYDsRuqxaOWzK5WtZVek0aWDlSsLS5uPc1moTDoeaD9kPraIT3ChcdACDbHbLTwg==;");
await customerService.InitializeAsync();

var customer = new Customer();

Console.Write("Förnamn: ");
customer.FirstName = Console.ReadLine() ?? "";

Console.Write("Efternamn: ");
customer.LastName = Console.ReadLine() ?? "";

Console.Write("E-postadress: ");
customer.Email = Console.ReadLine() ?? "";

Console.Write("Lösenord: ");
customer.SetSecurePassword(Console.ReadLine() ?? "");

await customerService.AddAsync(customer);

Console.ReadKey();
Console.Clear();

var customers = await customerService.GetAsync("select * from c");
foreach(var _customer in customers)
{
    Console.WriteLine($"{_customer.FirstName} {_customer.LastName}");
    Console.WriteLine($"{_customer.Email}");
    Console.WriteLine("");
}
Console.ReadKey();