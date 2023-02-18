using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _01_EFC.Models.Entities
{
    internal class ProductEntity
    {
        [Key]
        public string ArticleNumber { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }
    }
}
