namespace _02_Mapping.Models.Entitites;

internal class CustomerProfileEntity
{
    public int Id { get; set; }
    public Guid CustomerId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? StreetName { get; set; }
    public string? PostalCode { get; set; }
    public string? City { get; set; }

    public virtual CustomerEntity Customer { get; set; } = null!;

    public static implicit operator Customer(CustomerProfileEntity entity)
    {
        return new Customer
        {
            Id = entity.CustomerId,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            StreetName = entity.StreetName,
            PostalCode = entity.PostalCode,
            City = entity.City
        };
    }

    public static implicit operator CustomerProfileEntity(Customer customer)
    {
        return new CustomerProfileEntity
        {
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            StreetName = customer.StreetName,
            PostalCode = customer.PostalCode,
            City = customer.City
        };
    }
}
