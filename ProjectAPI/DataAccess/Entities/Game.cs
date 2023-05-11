using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
	public class Game : Entity
	{
		public string Title { get; set; }
		public string Genre { get; set; }
		public int Year { get; set; }
		public string Publisher { get; set; }
		public decimal Price { get; set; }
		public bool InStock { get; set; }
	}
}
