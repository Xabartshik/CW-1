namespace EShop.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<Product?> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllAsync();
        Task AddAsync(Product product);
        Task<bool> RemoveAsync(int id);
        Task<bool> UpdateAsync(Product product);
    }
}