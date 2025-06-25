using EShop.Application.DTOs;
using EShop.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Domain.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShopController : Controller
    {
        private readonly ShopService _service = new ShopService();

        [HttpGet]
        public IEnumerable<ShopDto> GetAll()
        {
            return _service.GetAll();
        }
        [HttpGet("{id}")]
        public ActionResult<ShopDto?> Get(int id)
        {
            ShopDto? result = _service.GetById(id);
            return result;
        }

        [HttpPost]
        public ActionResult<ShopDto> Add([FromBody] ShopDto shopDto)
        {
            if (!ShopService.ValidateDto(shopDto))
                return BadRequest("Некорректные данные");
            _service.Add(shopDto);
            return CreatedAtAction(nameof(GetAll), new { id = shopDto.Id }, shopDto);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_service.Remove(id))
                return NoContent(); // 204
            return BadRequest("Некорректные данные");
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ShopDto updatedShopDto)
        {
            if (!ShopService.ValidateDto(updatedShopDto))
                return BadRequest("Некорректные данные");
            var result = _service.Update(id, updatedShopDto);
            if (!result)
                return NotFound();
            return NoContent();
        }

    }
}
