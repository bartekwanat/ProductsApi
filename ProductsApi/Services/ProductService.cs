using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductsApi.Entities;
using ProductsApi.Exceptions;
using ProductsApi.Models;

namespace ProductsApi.Services
{
    
    public class ProductService : IProductService
    {
       
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProductService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            var products = await _context
                .Products
                .ToListAsync();

            var productsDtos = _mapper.Map<List<ProductDto>>(products);

            return productsDtos;
        }

        public async Task<ProductDto> GetById(Guid id)
        {
            var product = await _context
                .Products
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
                throw new NotFoundException("Product not found");

            var productDto = _mapper.Map<ProductDto>(product);

            return productDto;
        }

        public async Task<Guid> Create(CreateProductDto dto)
        {
            var newProduct = _mapper.Map<Product>(dto);
            _context.Products.AddAsync(newProduct);
            _context.SaveChangesAsync();

            return newProduct.Id;
        }

        public async Task Update(Guid id, UpdateProductDto dto)
        {
            var product = await _context
                .Products
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
                throw new NotFoundException("Product not found");

            product.Description = dto.Description;
            product.Quantity = dto.Quantity;
            
            _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var product = await _context
                .Products
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
                throw new NotFoundException("Product not found");

           _context.Products.Remove(product);
           await _context.SaveChangesAsync();
        }
    }
}
