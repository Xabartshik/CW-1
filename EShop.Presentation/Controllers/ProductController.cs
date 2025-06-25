using EShop.Application.DTOs;
using EShop.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _service = new ProductService();

        // Метод для получения продукта по id
        [HttpGet("{id}")]
        public ActionResult<ProductDto?> Get(int id)
        {
            return _service.GetById(id);
        }

        // Метод для получения всех продуктов
        [HttpGet]
        public IEnumerable<ProductDto> GetAll()
        {
            return _service.GetAll();
        }

        // Метод для добавления нового продукта
        [HttpPost]
        public ActionResult<ProductDto> Add([FromBody] ProductDto productDto)
        {
            _service.Add(productDto);
            return CreatedAtAction(nameof(Get), new { id = productDto.Id }, productDto);
        }

        // Метод для удаления продукта
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _service.Remove(id);
            if (product == false)
                return NotFound();

            return NoContent(); // 204
        }

        // Метод для обновления продукта
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ProductDto updatedProductDto)
        {
            // Валидация входных данных
            if (string.IsNullOrWhiteSpace(updatedProductDto.Name) || updatedProductDto.Price <= 0)
                return BadRequest("Некорректные данные");

            var updated = _service.Update(id, updatedProductDto);
            if (updated == false)
                return NotFound();

            return NoContent();
        }
    }
}