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
            Shops.Add(shop);
            return CreatedAtAction(nameof(GetAll), null, shop);
        }

    }
}
