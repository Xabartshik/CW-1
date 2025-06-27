using EShop.Application.DTOs;
using EShop.Application.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly ProductService _service;

    public ProductController(ProductService service)
    {
        _service = service;
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