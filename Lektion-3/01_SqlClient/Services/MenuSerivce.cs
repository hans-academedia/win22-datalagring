using _01_SqlClient.Models;

namespace _01_SqlClient.Services
{
    internal class MenuSerivce
    {
        public void CreateNewContact()
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
            customer.Address.StreetName = Console.ReadLine() ?? "";

            Console.Write("Postnummer: ");
            customer.Address.PostalCode = Console.ReadLine() ?? "";

            Console.Write("Stad: ");
            customer.Address.City = Console.ReadLine() ?? "";

            
            //save customer to database
            var database = new DatabaseService();
            database.SaveCustomer(customer);

        }

        public void ListAllContacts()
        {
            //get all customers+address from database
            var database = new DatabaseService();
            var customers = database.GetCustomers();
            
            if(customers.Any())
            {

                foreach (Customer customer in customers)
                {
                    Console.WriteLine($"Kundnummer: {customer.Id}");
                    Console.WriteLine($"Namn: {customer.FirstName} {customer.LastName}");
                    Console.WriteLine($"E-postadress: {customer.Email}");
                    Console.WriteLine($"Telefonnummer: {customer.PhoneNumber}");
                    Console.WriteLine($"Address: {customer.Address.StreetName}, {customer.Address.PostalCode} {customer.Address.City}");
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine("Inga kunder finns i databasen.");
                Console.WriteLine("");
            }
                
        }

        public void ListSpecificContact()
        {
            //get specific customer+address from database
            var database = new DatabaseService();

            Console.Write("Ange e-postadress på kunden: ");
            var email = Console.ReadLine();
            
            if (!string.IsNullOrEmpty(email)) 
            {
                var customer = database.GetCustomer(email);

                if (customer != null)
                {
                    Console.WriteLine($"Kundnummer: {customer.Id}");
                    Console.WriteLine($"Namn: {customer.FirstName} {customer.LastName}");
                    Console.WriteLine($"E-postadress: {customer.Email}");
                    Console.WriteLine($"Telefonnummer: {customer.PhoneNumber}");
                    Console.WriteLine($"Address: {customer.Address.StreetName}, {customer.Address.PostalCode} {customer.Address.City}");
                    Console.WriteLine("");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"Ingen kund med den angivna e-postadressen {email} hittades.");
                    Console.WriteLine("");
                }
            } else
            {
                Console.WriteLine($"Ingen e-postadressen angiven.");
                Console.WriteLine("");
            }

        }

    }
}
