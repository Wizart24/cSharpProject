namespace ProjectAPI.Models.Orders
{
	public class OrderBaseModel
	{
		public OrderBaseModel(
			string gameName, 
			string customerEmail, 
			string deliveryAddress, 
			DateTime orderDate)
		{
			GameName = gameName;
			CustomerEmail = customerEmail;
			DeliveryAddress = deliveryAddress;
			OrderDate = orderDate;
		}

		public string GameName { get; }
		public string CustomerEmail { get; }
		public string DeliveryAddress { get; }
		public DateTime OrderDate { get; set; }
	}
}
