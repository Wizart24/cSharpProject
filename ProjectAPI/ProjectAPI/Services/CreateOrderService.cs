using DataAccess.Entities;
using DataAccess.Repositories;
using ProjectAPI.Models.Customers;
using ProjectAPI.Models.Orders;

namespace ProjectAPI.Services
{
	public class CreateOrderService
	{
		private IRepository<Order> _orderRepository;

		public CreateOrderService(IRepository<Order> orderRepository)
		{
			_orderRepository = orderRepository;
		}

		public async Task<OrderModel> CallAsync(CreateOrderModel model)
		{
			var orderEntity = new Order()
			{
				GameName = model.GameName,
				CustomerEmail = model.CustomerEmail,
				DeliveryAddress = model.DeliveryAddress,
				OrderDate = model.OrderDate,
			};

			await _orderRepository.CreateAsync(orderEntity);

			return new OrderModel(
				orderEntity.Id,
				orderEntity.GameName,
				orderEntity.CustomerEmail,
				orderEntity.DeliveryAddress,
				orderEntity.OrderDate
			);
		}
	}
}
