using EShop.Domain;
using EShop.Domain.Interfaces;

namespace EShop.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private static readonly List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 70000 },
            new Product { Id = 2, Name = "Smartphone", Price = 35000 },
            new Product { Id = 3, Name = "Headphones", Price = 5000 }
        };

        public Product? GetById(int id)
            => _products.FirstOrDefault(p => p.Id == id);

        public IEnumerable<Product> GetAll()
            => _products;

        public void Add(Product product)
            => _products.Add(product);

        public bool Remove(int id)
        {
            var product = GetById(id);
            if (product != null)
                return _products.Remove(product);
            return false;
        }

        public bool Update(Product product)
        {
            var existing = GetById(product.Id);
            if (existing == null)
                return false;

            existing.Name = product.Name;
            existing.Price = product.Price;
            return true;
        }
    }
}