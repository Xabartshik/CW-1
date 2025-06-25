using EShop.Application.DTOs;
using EShop.DAL.Repositories;
using EShop.Domain;
using EShop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Services
{
    public class ShopService
    {
        private readonly IShopRepository _repo;

        public ShopService(IShopRepository repository)
        {
            _repo = repository;
        }

        public static bool Validate(Shop shop)
        {
            if (string.IsNullOrWhiteSpace(shop.Name) || shop.Area <= 0)
            {
                return false;
            }
            return true;
        }

        public static bool ValidateDto(ShopDto shop)
        {
            if (string.IsNullOrWhiteSpace(shop.Name) || shop.Area <= 0)
            {
                return false;
            }
            return true;
        }

        private ShopDto ToDto(Shop shop) => new ShopDto(shop.Id, shop.Name, shop.Area);
        private Shop FromDto(ShopDto shop) => new Shop { Id = shop.Id, Name = shop.Name, Area = shop.Area };
        public IEnumerable<ShopDto> GetAll() => _repo.GetAll().Select(ToDto);
        public ShopDto? GetById(int id)
        {
            Shop? shop = _repo.GetById(id);
            return shop == null ? null : ToDto(shop);

        }
        public void Add(ShopDto dto)
        {
            Shop shop = FromDto(dto);
            _repo.Add(shop);
        }
        public bool Remove(int id)
        {
            return _repo.Remove(id);
        }

        public bool Update(int id, ShopDto dto)
        {
            Shop newShop = FromDto(dto);
            return _repo.Update(newShop);
        }
    }
}
