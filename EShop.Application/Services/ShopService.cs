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

        private ShopDto ToDto(Shop shop) => new ShopDto(shop.Id, shop.Name, shop.Area, shop.Address, shop.CreatedAt);
        private Shop FromDto(ShopDto shop) => new Shop { Id = shop.Id, Name = shop.Name, Area = shop.Area,
            Address = shop.Address, CreatedAt = shop.CreatedAt };
        public async Task<IEnumerable<ShopDto>> GetAll()
        {
            var shops = await _repo.GetAllAsync();
            return shops.Select(ToDto);
        }
        public async Task<ShopDto?> GetById(int id)
        {
            Shop? shop = await _repo.GetByIdAsync(id);
            return shop == null ? null : ToDto(shop);

        }
        public async Task Add(ShopDto dto)
        {
            Shop shop = FromDto(dto);
            await _repo.AddAsync(shop);
        }
        public async Task<bool> Remove(int id)
        {
            return await _repo.RemoveAsync(id);
        }

        public async Task<bool> Update(int id, ShopDto dto)
        {
            Shop newShop = FromDto(dto);
            return await _repo.UpdateAsync(newShop);
        }
    }
}
