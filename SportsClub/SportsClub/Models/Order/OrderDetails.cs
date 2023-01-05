using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsClub.Models.Order
{
    [Table("OrderDetails",Schema = "Order")]
    public class OrderDetails
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int OrderHeaderId { get; set; }
        [ForeignKey("OrderHeaderId")]
        public OrderHeader OrderHeader { get; set; }
        [Required]
        public long ServiceId { get; set; }
        [ForeignKey("ServiceId")]
        public Service Service { get; set; }
        [Required]
        public string ServiceName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
