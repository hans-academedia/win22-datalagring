using _01_Mapping;
using _01_Mapping.Contexts;
using _01_Mapping.DirectMapping.Models.Entitites;
using BenchmarkDotNet.Running;


var context = new DataContext();
if (!context.Customers.Any())
{
    Console.WriteLine("Adding users to Database....");

    for (int i = 0; i < 1000; i++)
    {
        context.Add(new CustomerEntity());
        context.SaveChanges();
    }

}

var result = BenchmarkRunner.Run<Benchmarks>();