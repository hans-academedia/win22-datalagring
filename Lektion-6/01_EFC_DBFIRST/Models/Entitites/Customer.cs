using System;
using System.Collections.Generic;

namespace _01_EFC_DBFIRST.Models.Entitites;

public partial class Customer
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public int AddressId { get; set; }

    public virtual Address Address { get; set; } = null!;
}
