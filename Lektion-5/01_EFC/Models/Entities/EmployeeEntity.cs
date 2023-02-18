using Microsoft.EntityFrameworkCore;

namespace _01_EFC.Models.Entities
{
    [Index(nameof(Email), IsUnique = true)]
    internal class EmployeeEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
