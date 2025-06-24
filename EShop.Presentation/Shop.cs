using System.ComponentModel.DataAnnotations;

namespace EShop.Presentation
{
    public class Shop
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        [Range(1, 100000)]
        public double Area { get; set; }
    }
}
