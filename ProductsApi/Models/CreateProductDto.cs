using System.ComponentModel.DataAnnotations;

namespace ProductsApi.Models
{
    public class CreateProductDto
    {

        public string Name { get; set; }
        public int Number { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
