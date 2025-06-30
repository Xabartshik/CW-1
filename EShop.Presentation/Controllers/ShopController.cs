using EShop.Application.DTOs;
using EShop.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Domain.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShopController : Controller
    {
        private readonly ShopService _service;
        private readonly IConfiguration _configuration;
        private readonly ILogger<ShopController> _logger;

        public ShopController(ShopService service, IConfiguration configuration, ILogger<ShopController> logger) { 
            _service = service;
            _configuration = configuration;
            _logger = logger;
        }

        [HttpGet("page")]
        public async Task<ActionResult<List<Shop>>> GetProductsPaged(int page = 1)
        {
            _logger.LogInformation("Запрос страницы {Page} магазинов", page);

            try
            {
                var products = await _service.GetProductsPageAsync(page);
                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при получении страницы магазинов");

                return StatusCode(500, "Внутренняя ошибка сервера");
            }
        }



        [HttpGet]
        public async Task<IEnumerable<ShopDto>> GetAll()
        {
            return await _service.GetAll();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ShopDto?>> Get(int id)
        {
            ShopDto? result = await _service.GetById(id);
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<ShopDto>> Add([FromBody] ShopDto shopDto)
        {
            if (!ShopService.ValidateDto(shopDto))
                return BadRequest("Некорректные данные");
            await _service.Add(shopDto);
            return CreatedAtAction(nameof(GetAll), new { id = shopDto.Id }, shopDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _service.Remove(id))
                return NoContent(); // 204
            return BadRequest("Некорректные данные");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ShopDto updatedShopDto)
        {
            if (!ShopService.ValidateDto(updatedShopDto))
                return BadRequest("Некорректные данные");
            var result = await _service.Update(id, updatedShopDto);
            if (!result)
                return NotFound();
            return NoContent();
        }

    }
}
