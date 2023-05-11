using DataAccess.Entities;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectAPI.Models.Games;
using ProjectAPI.Models.Orders;
using ProjectAPI.Services;

namespace ProjectAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrdersController : ControllerBase
	{
		private IRepository<Order> _orderRepository;
		private CreateOrderService _createOrderService;

		public OrdersController(
			IRepository<Order> orderRepository, 
			CreateOrderService createOrderService)
		{
			_orderRepository = orderRepository;
			_createOrderService = createOrderService;
		}

		[HttpGet]
		public async Task<IActionResult> ListAsync()
		{
			var orders = await _orderRepository.ListAsync();

			return Ok(orders);
		}

		[HttpPost]
		public async Task<IActionResult> CreateAsync(CreateOrderModel orderModel)
		{
			var order = await _createOrderService.CallAsync(orderModel);

			return Ok(order);
		}
	}
}
