using EShop.Application.DTOs;
using EShop.Application.Settings;
using EShop.DAL.Repositories;
using EShop.Domain;
using EShop.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
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
        private readonly ILogger<ShopService> _logger;
        private readonly ShopSettings _options;


        public ShopService(IShopRepository repository, ILogger<ShopService> logger, IOptions<ShopSettings> options)
        {
            _repo = repository;
            _logger = logger;
            _options = options.Value;
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
        private Shop FromDto(ShopDto shop) => new Shop
        {
            Id = shop.Id,
            Name = shop.Name,
            Area = shop.Area,
            Address = shop.Address,
            CreatedAt = shop.CreatedAt
        };

        public async Task<IEnumerable<ShopDto>> GetProductsPageAsync(int page)
        {
            var pageLength = _options.MaxShopsPerPage;
            _logger.LogInformation("Запрос страницы {Page} продуктов (размер страницы: {pageLength})", page, pageLength);

            try
            {
                var shops = await _repo.GetAllAsync();
                _logger.LogInformation("Получено {ProductCount} продуктов", shops.ToList().Count);

                var pagedShops = shops
                .Skip((page - 1) * pageLength)
                .Take(pageLength)
                .ToList();

                return pagedShops.Select(ToDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при получении постраничного списка продуктов");
                throw;
            }
        }

        public async Task<IEnumerable<ShopDto>> GetAll()
        {
            _logger.LogInformation("Запрос списка всех магазинов");
            _logger.LogTrace("Входим в метод GetAll");
            _logger.LogDebug("Вызываем репозиторий для получения магазинов");
            try
            {
                var shops = await _repo.GetAllAsync();
                _logger.LogInformation("Получено {shopCount} магазинов", shops.Count());
                return shops.Select(ToDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при получении списка всех магазинов");
                throw;
            }
        }
        public async Task<ShopDto?> GetById(int id)
        {
            _logger.LogInformation("Запрос магазина по ID");
            _logger.LogTrace("Входим в метод GetById");
            _logger.LogDebug("Вызываем репозиторий для получения магазина по ID");
            try
            {
                Shop? shop = await _repo.GetByIdAsync(id);
                if (shop != null)
                {
                    _logger.LogInformation("Найден магазин: {ShopName}", shop.Name);
                    return ToDto(shop);
                }
                _logger.LogWarning("Магазин с ID {ShopID} не найден", id);
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при получении магазина по ID");
                throw;
            }

        }
        public async Task Add(ShopDto dto)
        {
            _logger.LogInformation("Добавление магазина");
            _logger.LogTrace("Входим в метод Add");
            _logger.LogDebug("Вызываем репозиторий для добавления магазина");
            try
            {
                Shop shop = FromDto(dto);
                await _repo.AddAsync(shop);
                _logger.LogInformation("Магазин {ShopName} с ID: {ShopID} добавлен", dto.Name, dto.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при добавлении магазина");
                throw;
            }
        }
        public async Task<bool> Remove(int id)
        {
            _logger.LogInformation("Удаление магазина {ShopID}", id);
            _logger.LogTrace("Входим в метод Remove");
            _logger.LogDebug("Вызываем репозиторий для удаления магазина по ID");
            try
            {
                if (await _repo.RemoveAsync(id))
                {
                    _logger.LogInformation("Магазин с ID {ShopID} удален", id);
                    return true;
                }
                _logger.LogWarning("магазин с ID {ShopID} не найден", id);
                return false;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при удалении магазина");
                throw;
            }
        }

        public async Task<bool> Update(int id, ShopDto dto)
        {
            _logger.LogInformation("Обновление магазина {ShopID}", id);
            _logger.LogTrace("Входим в метод Update");
            _logger.LogDebug("Вызываем репозиторий для обновления магазина");
            try
            {
                Shop newShop = FromDto(dto);
                if (await _repo.UpdateAsync(newShop))
                {
                    _logger.LogInformation("Магазин с ID {ShopID} удален", id);
                    return true;
                }
                _logger.LogWarning("магазин с ID {ShopID} не найден", id);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при обновлении магазина {shopId}", id);
                throw;
            }
        }
    }
}
