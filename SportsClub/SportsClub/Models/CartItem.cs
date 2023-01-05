namespace SportsClub.Models
{
	public class CartItem
	{
		public long ProductId { get; set; }
		public string ProductName { get; set; }
		public int Quantity { get; set; }
		public decimal Price { get; set; }
		public decimal Total 
		{ 
			get { return Quantity * Price; }
		}
		public string Image { get; set; }
		public CartItem()
		{

		}
		public CartItem(Service service)
		{
			ProductId = service.Id;
			ProductName = service.Name;
			Price = service.Price;
			Quantity = 1;
			Image = service.Image;
		}
	}
}
