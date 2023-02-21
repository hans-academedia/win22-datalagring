using System;
using System.Collections.Generic;

namespace _01_EFC_DBFIRST.Models.Entitites;

public partial class Address
{
    public int Id { get; set; }

    public string StreetName { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public string City { get; set; } = null!;

    public virtual ICollection<Customer> Customers { get; } = new List<Customer>();
}
