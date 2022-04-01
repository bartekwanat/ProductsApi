using AutoMapper;
using ProductsApi.Entities;
using ProductsApi.Models;

namespace ProductsApi.Services
{
    public interface IProductService
    {
        public IEnumerable<Product> GetAll();
        public Product GetById(Guid id);
        public Guid Create(CreateProductDto dto);
        public void Update(UpdateProductDto dto, Guid id);
        public void Delete(Guid id);
    }
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProductService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<Product> GetAll()
        {
            var products = _context
                .Products
                .ToList();

                return products;
        }
        
        public Product GetById (Guid id)
        {
            var product = _context
                .Products
                .FirstOrDefault(p => p.Id == id);


            return product;
        }

        public Guid Create(CreateProductDto dto)
        {
            var newProduct = _mapper.Map<Product>(dto);
            _context.Products.Add(newProduct);
            _context.SaveChanges();

            return newProduct.Id;       
        }

        public void Update (UpdateProductDto dto, Guid id)
        {
            var product = _context
                .Products
                .FirstOrDefault(p => p.Id == id);   

            product.Description = dto.Description;
            product.Quantity = dto.Quantity;

            _context.SaveChanges();
        } 

        public void Delete(Guid id)
        {
            var product = _context
                .Products
                .FirstOrDefault(p => p.Id == id);

            _context.Products.Remove(product);
            _context.SaveChanges();
        }
        
        



    }
}
