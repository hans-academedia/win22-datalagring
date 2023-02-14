using _01_SqlClient_Dapper.Models;

namespace _01_SqlClient_Dapper.Services
{
    internal class MenuService
    {
        public async Task CreateNewContactAsync()
        {
            var customer = new Customer();

            Console.Write("Förnamn: ");
            customer.FirstName = Console.ReadLine() ?? "";

            Console.Write("Efternamn: ");
            customer.LastName = Console.ReadLine() ?? "";

            Console.Write("E-postadress: ");
            customer.Email = Console.ReadLine() ?? "";

            Console.Write("Telefonnummer: ");
            customer.PhoneNumber = Console.ReadLine() ?? "";

            Console.Write("Gatuadress: ");
            customer.StreetName = Console.ReadLine() ?? "";

            Console.Write("Postnummer: ");
            customer.PostalCode = Console.ReadLine() ?? "";

            Console.Write("Stad: ");
            customer.City = Console.ReadLine() ?? "";


            //save customer to database
            await CustomerService.SaveAsync(customer);

        }

        public async Task ListAllContactsAsync()
        {
            //get all customers+address from database
            var customers = await CustomerService.GetAllAsync();

            if (customers.Any())
            {

                foreach (Customer customer in customers)
                {
                    Console.WriteLine($"Kundnummer: {customer.Id}");
                    Console.WriteLine($"Namn: {customer.FirstName} {customer.LastName}");
                    Console.WriteLine($"E-postadress: {customer.Email}");
                    Console.WriteLine($"Telefonnummer: {customer.PhoneNumber}");
                    Console.WriteLine($"Address: {customer.StreetName}, {customer.PostalCode} {customer.City}");
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine("Inga kunder finns i databasen.");
                Console.WriteLine("");
            }

        }

        public async Task ListSpecificContactAsync()
        {
            Console.Write("Ange e-postadress på kunden: ");
            var email = Console.ReadLine();

            if (!string.IsNullOrEmpty(email))
            {
                //get specific customer+address from database
                var customer = await CustomerService.GetAsync(email);

                if (customer != null)
                {
                    Console.WriteLine($"Kundnummer: {customer.Id}");
                    Console.WriteLine($"Namn: {customer.FirstName} {customer.LastName}");
                    Console.WriteLine($"E-postadress: {customer.Email}");
                    Console.WriteLine($"Telefonnummer: {customer.PhoneNumber}");
                    Console.WriteLine($"Address: {customer.StreetName}, {customer.PostalCode} {customer.City}");
                    Console.WriteLine("");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"Ingen kund med den angivna e-postadressen {email} hittades.");
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine($"Ingen e-postadressen angiven.");
                Console.WriteLine("");
            }

        }

        public async Task UpdateSpecificContactAsync()
        {
            Console.Write("Ange e-postadress på kunden: ");
            var email = Console.ReadLine();

            if (!string.IsNullOrEmpty(email))
            {

                var customer = await CustomerService.GetAsync(email);

                Console.WriteLine("Skriv in information på de fält som du vill uppdatera. \n");

                Console.Write("Förnamn: ");
                customer.FirstName = Console.ReadLine() ?? null!;

                Console.Write("Efternamn: ");
                customer.LastName = Console.ReadLine() ?? null!;

                Console.Write("E-postadress: ");
                customer.Email = Console.ReadLine() ?? null!;

                Console.Write("Telefonnummer: ");
                customer.PhoneNumber = Console.ReadLine() ?? null!;

                Console.Write("Gatuadress: ");
                customer.StreetName = Console.ReadLine() ?? null!;

                Console.Write("Postnummer: ");
                customer.PostalCode = Console.ReadLine() ?? null!;

                Console.Write("Stad: ");
                customer.City = Console.ReadLine() ?? null!;

                //update specific customer from database
                await CustomerService.UpdateAsync(customer);
            }
            else
            {
                Console.WriteLine($"Ingen e-postadressen angiven.");
                Console.WriteLine("");
            }

        }


        public async Task DeleteSpecificContactAsync()
        {
            Console.Write("Ange e-postadress på kunden: ");
            var email = Console.ReadLine();

            if (!string.IsNullOrEmpty(email))
            {
                //delete specific customer from database
                await CustomerService.DeleteAsync(email); 
            }
            else
            {
                Console.WriteLine($"Ingen e-postadressen angiven.");
                Console.WriteLine("");
            }

        }
    }
}
