using EShop.Application.DTOs;
using EShop.Application.Services;
using EShop.Domain;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ProductService _service;
    private readonly IConfiguration _configuration;
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(
        ProductService productService,
        IConfiguration configuration,
        ILogger<ProductsController> logger)
    {
        _service = productService;
        _configuration = configuration;
        _logger = logger;
    }

    [HttpGet("page")]
    public async Task<ActionResult<List<Product>>> GetProductsPaged(int page = 1)
    {
        _logger.LogInformation("Запрос страницы {Page} продуктов", page);

        try
        {
            var products = await _service.GetProductsPageAsync(page);
            return Ok(products);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при получении страницы продуктов");

            return StatusCode(500, "Внутренняя ошибка сервера");
        }
    }

    [HttpGet("info")]
    public ActionResult<object> GetApplicationInfo()
    {
        var appName = _configuration["AppSettings:ApplicationName"];
        var version = _configuration["AppSettings:Version"];
        var maxProducts = _configuration.GetValue<int>("AppSettings:MaxProductsPerPage");
        var enableDetailedLogging = _configuration.GetValue<bool>("AppSettings:EnableDetailedLogging");

        _logger.LogInformation("Запрос информации о приложении");

        return Ok(new
        {
            ApplicationName = appName,
            Version = version,
            MaxProductsPerPage = maxProducts,
            EnableDetailedLogging = enableDetailedLogging,
            Environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"
        });
    }

    // Метод для получения продукта по id
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto?>> Get(int id)
    {
        return await _service.GetByIdAsync(id);
    }

    // Метод для получения всех продуктов
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts()
    {
        var products = await _service.GetAllAsync();
        return Ok(products);
    }

    // Метод для добавления нового продукта
    [HttpPost]
    public async Task<ActionResult<ProductDto>> Add([FromBody] ProductDto productDto)
    {
        await _service.AddAsync(productDto);

        return CreatedAtAction(nameof(Get), new { id = productDto.Id }, productDto);
    }

    // Метод для удаления продукта
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _service.RemoveAsync(id);
        if (result == false)
            return NotFound();

        return NoContent();
    }

    // Метод для обновления продукта
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ProductDto updatedProductDto)
    {
        if (string.IsNullOrWhiteSpace(updatedProductDto.Name) || updatedProductDto.Price <= 0)
            return BadRequest("Некорректные данные");

        var updated = await _service.UpdateAsync(id, updatedProductDto);
        if (updated == false)
            return NotFound();

        return NoContent();
    }
}