using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Domain.Interfaces
{
    public interface IShopRepository
    {
        Task<Shop?> GetByIdAsync(int id);
        Task<IEnumerable<Shop>> GetAllAsync();
        Task AddAsync(Shop shop);
        Task<bool> RemoveAsync(int id);
        Task<bool> UpdateAsync(Shop shop);
    }
}
