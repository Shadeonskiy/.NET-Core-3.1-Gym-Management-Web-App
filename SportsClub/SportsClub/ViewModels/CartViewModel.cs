using SportsClub.Models;
using SportsClub.Models.Order;
using System.Collections.Generic;

namespace SportsClub.ViewModels
{
    public class CartViewModel
    {
        public OrderHeader OrderHeader { get; set; }
        public List<CartItem> CartItems { get; set; }
        public decimal GrandTotal { get; set; }
    }
}
