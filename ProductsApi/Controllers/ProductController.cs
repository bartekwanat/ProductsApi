
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Models;
using ProductsApi.Services;

namespace ProductsApi.Controllers
{
    [Route("/product/api")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
        {
            var productsDtos = await _service.GetAll();

            return Ok(productsDtos);
    
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetById ([FromRoute] Guid id)
        {
            var productDto = await _service.GetById(id);
            return Ok(productDto);
        }

        [HttpPost]
        public async Task<Guid> CreateProduct([FromBody] CreateProductDto dto)
        {
            if(!ModelState.IsValid)
            {
                throw new Exception("Product with this Id not exist");
            }

            var id = await _service.Create(dto);
            return id;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute] Guid id, [FromBody] UpdateProductDto dto)
        {
           await _service.Update(id, dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            _service.Delete(id);
            return Ok();
        }
    }
}
