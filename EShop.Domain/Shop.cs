using System.ComponentModel.DataAnnotations;

namespace EShop.Domain
{
    public class Shop
    {
        public int Id { get; set; }
        public required string Name { get; set; }


        public double Area { get; set; }


    }
}
