using Microsoft.AspNetCore.Mvc;

namespace EShop.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private static readonly List<Product> Products = new List<Product>
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

        // Метод для получения всех продуктов по id
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return Products.ToList();
        }

        [HttpPost]
        public ActionResult<Product> Add([FromBody] Product product)
        {
            Products.Add(product);
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }
    }
}