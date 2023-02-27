namespace _01_Mapping.DirectMapping.Models.Entitites;

public class CustomerEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; } = "Hans";
    public string LastName { get; set; } = "Mattin-Lassei";
    public string Email { get; set; } = "hans.mattin-lassei@domain.com";
    public string UserName { get; set; } = "hans.mattin-lassei";
    public string NormalizedUserName => UserName.ToUpper();
    public string NormalizedEmail => Email.ToUpper();
    public string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();
    public string Password { get; set; } = "AQAAAAIAAYagAAAAEJ5NSXDv/+C2i9PU3S3EQ8qZMxlo4X9hARO6pfUoqN12L56BG9NkYPIpu9wpUGREDQ==";
    public string SecurityStamp { get; set; } = "ZLD24WGEIQ2HNWDYMXNEA4LMVFXRXRYW";
    public bool AccountIsValidated { get; set; } = false;

    public static implicit operator Customer(CustomerEntity entity)
    {
        return new Customer
        {
            CustomerId = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            EmailAddress = entity.Email
        };
    }
}
