using ProductsApi.Models;

namespace ProductsApi.Services
{
    public interface IProductService
    {
        public Task<IEnumerable<ProductDto>> GetAll();
        public Task<ProductDto> GetById(Guid id);
        public Task<Guid> Create(CreateProductDto dto);
        public Task Update(Guid id, UpdateProductDto dto);
        public Task Delete(Guid id);
    }
}
