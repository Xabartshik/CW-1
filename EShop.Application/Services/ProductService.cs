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

        public IEnumerable<ProductDto> GetAll()
            => _repository.GetAll().Select(ToDto);

        public ProductDto? GetById(int id)
        {
            var product = _repository.GetById(id);
            return product == null ? null : ToDto(product);
        }

        public void Add(ProductDto dto)
        {
            var product = new Product
            {
                Id = dto.Id,
                Name = dto.Name,
                Price = dto.Price
            };
            _repository.Add(product);
        }

        public bool Remove(int id) => _repository.Remove(id);

        public bool Update(int id, ProductDto dto)
        {
            var product = new Product
            {
                Id = id,
                Name = dto.Name,
                Price = dto.Price
            };
            return _repository.Update(product);
        }
    }
}