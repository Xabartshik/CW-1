using System.ComponentModel.DataAnnotations;

namespace EShop.Domain
{
    public class Shop
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public string Address { get; set; }
        public double Area { get; set; }

        public DateTime CreatedAt { get; set; }


    }
}
