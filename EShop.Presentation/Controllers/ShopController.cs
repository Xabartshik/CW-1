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

        public ShopController(ShopService service) { 
            _service = service;
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
