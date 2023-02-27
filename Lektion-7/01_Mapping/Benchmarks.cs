using _01_Mapping.AutoMapper.Profiles;
using _01_Mapping.Contexts;
using _01_Mapping.DirectMapping.Models;
using _01_Mapping.DirectMapping.Models.Entitites;
using AutoMapper;
using BenchmarkDotNet.Attributes;

namespace _01_Mapping;

public class Benchmarks
{
    #region Initializing
    private CustomerEntity[] directmapping_customers;
    private IMapper mapper;

    [Params(1)]
    public int InstanceCount { get; set; }


    [GlobalSetup]
    public void InitializeSetup()
    {        
        //directmapping_customers = Enumerable.Range(1, InstanceCount).Select(customerEntity => new CustomerEntity()).ToArray();
        //mapper = new AutoMapperProfile().Configuration.CreateMapper();
    }

    #endregion


    [Benchmark]
    public void DirectMapping()
    {
        var context = new DataContext();
        var customers = new List<Customer>();

        foreach (var customerEntity in context.Customers)
        {
            customers.Add(new Customer
            {
                CustomerId = customerEntity.Id,
                FirstName = customerEntity.FirstName,
                LastName = customerEntity.LastName,
                EmailAddress = customerEntity.Email,
            });
        }
    }

    [Benchmark]
    public void AutoMapper()
    {
        var context = new DataContext();
        var customers = new List<Customer>();
        IMapper mapper = new AutoMapperProfile().Configuration.CreateMapper();

        foreach (var customerEntity in context.Customers)
        {
            customers.Add(mapper.Map<Customer>(customerEntity));
        }
    }


    [Benchmark]
    public void Implicit()
    {
        var context = new DataContext();
        var customers = new List<Customer>();

        foreach (var customerEntity in context.Customers)
        {
            customers.Add(customerEntity);
        }
    }


}
