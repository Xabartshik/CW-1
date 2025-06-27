using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.DTOs
{
    public record ShopDto(int Id, string Name, double Area, string Address, DateTime CreatedAt);
}
