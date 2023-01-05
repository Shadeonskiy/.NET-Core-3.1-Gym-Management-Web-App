using SportsClub.Models.Order;
using System.Collections.Generic;

namespace SportsClub.ViewModels
{
    public class OrderViewModel
    {
        public OrderHeader OrderHeader { get; set; }
        public IEnumerable<OrderDetails> OrderDetails { get; set; }
    }
}
