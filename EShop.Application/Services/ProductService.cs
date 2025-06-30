using EShop.Application.DTOs;
using EShop.Application.Settings;
using EShop.Domain;
using EShop.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace EShop.Application.Services
{
    public class ProductService
    {
        private readonly IProductRepository _repository;
        private readonly ILogger<ProductService> _logger;
        private readonly AppSettings _appSettings;

        public ProductService(
            IProductRepository productRepository,
            ILogger<ProductService> logger,
            IOptions<AppSettings> appOptions)
        {
            _repository = productRepository;
            _logger = logger;
            _appSettings = appOptions.Value;
        }

        private ProductDto ToDto(Product product)
            => new ProductDto(product.Id, product.Name, product.Price);

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            if (_appSettings.EnableDetailedLogging)
            {
                _logger.LogTrace("Входим в метод GetProductsAsync");
            }

            _logger.LogInformation("Запрос списка всех продуктов");

            if (_appSettings.EnableDetailedLogging)
            {
                _logger.LogDebug("Вызываем репозиторий для получения продуктов");
            }

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

        public async Task<IEnumerable<ProductDto>> GetProductsPageAsync(int page)
        {
            var pageLength = _appSettings.MaxProductsPerPage;
            _logger.LogInformation("Запрос страницы {Page} продуктов (размер страницы: {pageLength})", page, pageLength);

            try
            {
                var products = await _repository.GetAllAsync();
                _logger.LogInformation("Получено {ProductCount} продуктов", products.ToList().Count);

                var pagedProducts = products
                .Skip((page - 1) * pageLength)
                .Take(pageLength)
                .ToList();

                return pagedProducts.Select(ToDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при получении постраничного списка продуктов");
                throw;
            }
        }

        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            _logger.LogInformation("Запрос продукта с ID: {ProductId}", id);
            _logger.LogDebug("Вызов репозитория для получения продукта по ID");
            _logger.LogTrace("Вход в GEtByIdsAsync");

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
            _logger.LogDebug("Добавление продукта в репозиторий");
            _logger.LogTrace("Вход в AddAsync");

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
            _logger.LogDebug("Вызов репозитория для удаления продукта по его Id");
            _logger.LogTrace("Вход в RemoveAsync");
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
            _logger.LogDebug("Вызов репозитория для обновления продукта");
            _logger.LogTrace("Вход в UpdateAsync");
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