using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
	public class OrderRepository : BaseRepository<Order>
	{
		public OrderRepository(GameDbContext context) : base(context)
		{

		}
	}
}
