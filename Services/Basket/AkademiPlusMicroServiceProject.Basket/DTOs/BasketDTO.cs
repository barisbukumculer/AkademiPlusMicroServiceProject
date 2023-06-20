using System.Collections.Generic;
using System.Linq;

namespace AkademiPlusMicroServiceProject.Basket.DTOs
{
    public class BasketDTO
    {
        public string UserID { get; set; }
        public string? DiscountCode { get; set; }
        public int? DiscountRate { get; set; }
        public List<BasketItemDTO> basketItems { get; set; }
        public decimal TotalPrice { get => basketItems.Sum(x => x.Price * x.Quantity); }
    }
}
