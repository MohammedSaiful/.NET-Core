using System.ComponentModel.DataAnnotations;

namespace SecureProductCreationModule.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [Range(0.01, 100000, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
