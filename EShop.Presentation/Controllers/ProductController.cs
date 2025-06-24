using Microsoft.AspNetCore.Mvc;

namespace EShop.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        // Статический массив продуктов
        private static readonly Product[] Products = new[]
        {
            new Product { Id = 1, Name = "Laptop", Price = 70000 },
            new Product { Id = 2, Name = "Smartphone", Price = 35000 },
            new Product { Id = 3, Name = "Headphones", Price = 5000 }
        };

        // Метод для получения продукта по id
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();
            return product;
        }

        // Метод для получения продуктов по id
        [HttpGet()]
        public IEnumerable<Product> Get()
        {
            return Products.ToList();
        }
    }
}