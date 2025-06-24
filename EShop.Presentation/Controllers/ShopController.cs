using Microsoft.AspNetCore.Mvc;

namespace EShop.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShopController : Controller
    {
        private static readonly List<Shop> Shops = new List<Shop>()
        { 
          new Shop { Name = "Однёрочка", Area = 100, Id = 1 },
          new Shop { Name = "Дварочка", Area = 200, Id = 2 },
          new Shop { Name = "Тернарочка", Area = 300, Id = 3 },
          new Shop { Name = "Квадрёрочка", Area = 400, Id = 4 },
          new Shop { Name = "Пентарочка", Area = 500, Id = 5 },
        };

        [HttpGet]
        public IEnumerable<Shop> GetAll()
        {
            return Shops;
        }

        [HttpPost]
        public ActionResult<Shop> Add([FromBody] Shop shop)
        {
            if (!Shop.Validate(shop))
                return BadRequest("Некорректные данные");
            Shops.Add(shop);
            return CreatedAtAction(nameof(GetAll), null, shop);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var shop = Shops.FirstOrDefault(p => p.Id == id);
            if (shop == null)
                return NotFound();

            Shops.Remove(shop);
            return NoContent(); // 204
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Shop updatedShop)
        {
            var shop = Shops.FirstOrDefault(p => p.Id == id);
            if (shop == null)
                return NotFound();

            // Валидация входных данных
            if (!Shop.Validate(updatedShop))
                return BadRequest("Некорректные данные");

            // Полное обновление
            shop.Name = updatedShop.Name;
            shop.Area = updatedShop.Area;
            return NoContent();
        }

    }
}
