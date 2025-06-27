using EShop.Application.DTOs;
using EShop.DAL.Repositories;
using EShop.Domain;
using EShop.Domain.Interfaces;

namespace EShop.Application.Services
{
    public class ProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        private ProductDto ToDto(Product product)
            => new ProductDto(product.Id, product.Name, product.Price);

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await _repository.GetAllAsync();
            return products.Select(ToDto);
        }

        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            return product == null ? null : ToDto(product);
        }

        public async Task AddAsync(ProductDto dto)
        {
            var product = new Product
            {
                Id = dto.Id,
                Name = dto.Name,
                Price = dto.Price
            };
            await _repository.AddAsync(product);
        }

        public async Task<bool> RemoveAsync(int id)
        {
            return await _repository.RemoveAsync(id);
        }

        public async Task<bool> UpdateAsync(int id, ProductDto dto)
        {
            var product = new Product
            {
                Id = id,
                Name = dto.Name,
                Price = dto.Price
            };

            return await _repository.UpdateAsync(product);
        }
    }
}