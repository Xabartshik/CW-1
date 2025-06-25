using EShop.Domain;

namespace EShop.Domain.Interfaces
{
    public interface IProductRepository
    {
        Product? GetById(int id);
        IEnumerable<Product> GetAll();
        void Add(Product product);
        bool Remove(int id);
        bool Update(Product product);
    }
}