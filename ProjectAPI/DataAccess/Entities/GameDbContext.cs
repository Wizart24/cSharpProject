using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
	public class GameDbContext : DbContext
	{
		public GameDbContext(DbContextOptions<GameDbContext> options) : base(options)
		{

		}

		public DbSet<Game> Games { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Order> Orders { get; set; }
	}
}
