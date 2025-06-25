using EShop.Domain;
using EShop.Domain.Interfaces;

namespace EShop.DAL.Repositories
{
    public class ShopRepository : IShopRepository
    {
        private static readonly List<Shop> _shops = new List<Shop>
        {
          new Shop { Name = "Однёрочка", Area = 100, Id = 1 },
          new Shop { Name = "Дварочка", Area = 200, Id = 2 },
          new Shop { Name = "Тернарочка", Area = 300, Id = 3 },
          new Shop { Name = "Квадрёрочка", Area = 400, Id = 4 },
          new Shop { Name = "Пентарочка", Area = 500, Id = 5 },
        };
        public Shop? GetById(int id)
        {
            return _shops.FirstOrDefault(x => x.Id == id);
        }
        public IEnumerable<Shop> GetAll()
        {
            return _shops;
        }
        public void Add(Shop shop)
        {
            _shops.Add(shop);
        }
        public bool Remove(int id)
        {
            var shop = GetById(id);
            if (shop is null)
                return false;
            return _shops.Remove(shop);
        }
        public bool Update(Shop shop)
        {
            var oldShop = GetById(shop.Id);
            if (oldShop is null) return false;
            oldShop.Name = shop.Name;
            oldShop.Area = shop.Area;
            return true;

        }
    }
}