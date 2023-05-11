namespace ProjectAPI.Models.Orders
{
	public class OrderModel : OrderBaseModel
	{
		public OrderModel(
			int id,
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
			Id = id;
		}

		public int Id { get; }
	}
}
