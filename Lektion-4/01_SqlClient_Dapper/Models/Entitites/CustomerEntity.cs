namespace _01_SqlClient_Dapper.Models.Entitites
{
    internal class CustomerEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public int AddressId { get; set; }
    }
}
