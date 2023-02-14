using _01_SqlClient.Services;
var menu = new MenuSerivce();

while(true)
{
    Console.Clear();
    Console.WriteLine("1. Skapa en ny kontakt");
    Console.WriteLine("2. Visa alla kontakter");
    Console.WriteLine("3. Visa en specifik kontakt");
    Console.Write("Välj ett av följande alternativ (1-3): ");

    switch (Console.ReadLine())
    {
        case "1":
            Console.Clear();
            menu.CreateNewContact();
            break;

        case "2":
            Console.Clear();
            menu.ListAllContacts();
            break;

        case "3":
            Console.Clear();
            menu.ListSpecificContact();
            break;
    }

    Console.WriteLine("\nTryck på valfri knapp för att fortsätta...");
    Console.ReadKey();
}