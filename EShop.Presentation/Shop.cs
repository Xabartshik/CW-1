using System.ComponentModel.DataAnnotations;

namespace EShop.Presentation
{
    public class Shop
    {
        public int Id { get; set; }
        public required string Name { get; set; }


        public double Area { get; set; }

        public static bool Validate(Shop shop)
        {
            if (string.IsNullOrWhiteSpace(shop.Name) || shop.Area <= 0)
            {
                return false;
            }
            return true;
        }
    }
}
