using System.ComponentModel.DataAnnotations;

namespace ProductsApi.Models
{
    public class UpdateProductDto
    {
        public Guid Id { get; set; }
        [Required] public string Name { get; set; }
        public int Number { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        [Required] public decimal Price { get; set; }
    }
}
