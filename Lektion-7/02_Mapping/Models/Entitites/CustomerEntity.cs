using System.Security.Cryptography;
using System.Text;

namespace _02_Mapping.Models.Entitites;

internal class CustomerEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Email { get; set; } = null!;
    public byte[]? Password { get; private set; }
    public byte[]? SecurityStamp { get;  private set; }
    public virtual ICollection<CustomerProfileEntity> Profiles { get; set; } = new HashSet<CustomerProfileEntity>();

    public void SetSecurePassword(string password)
    {
        using var hmac = new HMACSHA512();
        SecurityStamp = hmac.Key;
        Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
    }


    public static implicit operator CustomerEntity(Customer customer)
    {
        return new CustomerEntity
        {
            Email = customer.Email
        };
    }

    public static implicit operator Customer(CustomerEntity customerEntity)
    {
        return new Customer
        {
            Id = customerEntity.Id,
            Email = customerEntity.Email
        };
    }

}
