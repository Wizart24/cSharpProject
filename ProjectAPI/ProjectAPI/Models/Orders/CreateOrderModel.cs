namespace ProjectAPI.Models.Orders
{
	public class CreateOrderModel : OrderBaseModel
	{
		public CreateOrderModel(
			string gameName, 
			string customerEmail, 
			string deliveryAddress, 
			DateTime orderDate) 
			: base(
				  gameName, 
				  customerEmail, 
				  deliveryAddress, 
				  orderDate)
		{
		}
	}
}
