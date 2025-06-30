using EShop.Application.DTOs;
using EShop.Domain;
using EShop.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace EShop.Application.Services
{
    public class ProductService
    {
        private readonly IProductRepository _repository;
        private readonly ILogger<ProductService> _logger;

        public ProductService(
            IProductRepository repository,
            ILogger<ProductService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        private ProductDto ToDto(Product product)
            => new ProductDto(product.Id, product.Name, product.Price);

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            _logger.LogInformation("Запрос списка всех продуктов");

            try
            {
                var products = await _repository.GetAllAsync();
                _logger.LogInformation("Получено {ProductCount} продуктов", products.ToList().Count);

                return products.Select(ToDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при получении списка продуктов");
                throw;
            }
        }

        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            _logger.LogInformation("Запрос продукта с ID: {ProductId}", id);

            try
            {
                var product = await _repository.GetByIdAsync(id);
                if (product != null)
                {
                    _logger.LogInformation("Найден продукт: {ProductName}", product.Name);
                    return ToDto(product);
                }
                _logger.LogWarning("Продукт с ID {ProductId} не найден", id);
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при получении продукта с ID {ProductId}", id);
                throw;
            }
        }

        public async Task AddAsync(ProductDto dto)
        {
            _logger.LogInformation("Создание нового продукта: {ProductName} с ценой {Price}",
                dto.Name, dto.Price);

            var product = new Product
            {
                Id = dto.Id,
                Name = dto.Name,
                Price = dto.Price
            };

            try
            {
                await _repository.AddAsync(product);
                _logger.LogInformation("Продукт {ProductId} успешно создан", product.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при создании продукта {ProductName}", product.Name);
                throw;
            }
        }

        public async Task<bool> RemoveAsync(int id)
        {
            _logger.LogInformation("Удаление продукта с ID: {ProductId}", id);

            try
            {
                var result = await _repository.RemoveAsync(id);
                if (result)
                {
                    _logger.LogInformation("Продукт {ProductId} успешно удален", id);
                }
                else
                {
                    _logger.LogWarning("Продукт с ID {ProductId} не найден для удаления", id);
                }
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при удалении продукта с ID {ProductId}", id);
                throw;
            }
        }

        public async Task<bool> UpdateAsync(int id, ProductDto dto)
        {
            _logger.LogInformation("Обновление продукта с ID: {ProductId}", dto.Id);

            var product = new Product
            {
                Id = id,
                Name = dto.Name,
                Price = dto.Price
            };

            try
            {
                var result = await _repository.UpdateAsync(product);
                if (result)
                {
                    _logger.LogInformation("Продукт {ProductId} успешно обновлен", product.Id);
                }
                else
                {
                    _logger.LogWarning("Продукт с ID {ProductId} не найден для обновления", product.Id);
                }
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при обновлении продукта с ID {ProductId}", product.Id);
                throw;
            }
        }
    }
}