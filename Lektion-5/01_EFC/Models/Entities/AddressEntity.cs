using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _01_EFC.Models.Entities
{
    internal class AddressEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string StreetName { get; set; } = null!;

        [Required]
        [Column(TypeName = "char(6)")]
        public string PostalCode { get; set; } = null!;

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string City { get; set; } = null!;


        public ICollection<CustomerEntity> Customers = new HashSet<CustomerEntity>();

    }
}
