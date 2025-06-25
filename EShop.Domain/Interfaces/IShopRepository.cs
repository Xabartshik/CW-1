using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Domain.Interfaces
{
    public interface IShopRepository
    {
        Shop? GetById(int id);
        IEnumerable<Shop> GetAll();
        void Add(Shop shop);
        bool Remove(int id);
        bool Update(Shop shop);
    }
}
