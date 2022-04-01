
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
        public ActionResult<IEnumerable<ProductDto>> GetAll()
        {
            var productsDtos = _service.GetAll();

            return Ok(productsDtos);
    
        }

        [HttpGet("{id}")]
        public ActionResult<ProductDto> GetById ([FromRoute] Guid id)
        {
            var productDto = _service.GetById(id);
            return Ok(productDto);
        }

        [HttpPost]
        public Guid CreateProduct([FromBody] CreateProductDto dto)
        {
            if(!ModelState.IsValid)
            {
                throw new Exception("Product with this Id not exist");
            }

            var id = _service.Create(dto);
            return id;
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateProductDto dto, [FromRoute] Guid id)
        {
            _service.Update(dto, id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] Guid id)
        {
            _service.Delete(id);
            return Ok();
        }
    }
}
