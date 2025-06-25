using EShop.Application.DTOs;
using EShop.Domain;

namespace EShop.Application.Services
{
    public class ProductService
    {
        private ProductDto ToDto(Product product)
            => new ProductDto(product.Id, product.Name, product.Price);

        private static readonly List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 70000 },
            new Product { Id = 2, Name = "Smartphone", Price = 35000 },
            new Product { Id = 3, Name = "Headphones", Price = 5000 }
        };

        public IEnumerable<ProductDto> GetAll() => _products.Select(ToDto);

        public ProductDto? GetById(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            return product == null ? null : ToDto(product);
        }

        // Для добавления и обновления — наоборот, нужен маппинг из DTO в Product
        public void Add(ProductDto dto)
        {
            var product = new Product
            {
                Id = dto.Id,
                Name = dto.Name,
                Price = dto.Price
            };
            _products.Add(product);
        }

        public bool Remove(int id)
        {
            var p = _products.FirstOrDefault(x => x.Id == id);
            if (p != null) return _products.Remove(p);

            return false;
        }

        public bool Update(int id, ProductDto dto)
        {
            var p = _products.FirstOrDefault(x => x.Id == id);
            if (p == null)
                return false;

            p.Name = dto.Name;
            p.Price = dto.Price;

            return true;
        }
    }
}
