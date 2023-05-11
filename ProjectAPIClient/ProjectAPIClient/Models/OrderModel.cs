using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAPIClient.Models
{
	public class OrderModel
	{
        public int Id { get; set; }
        public string GameName { get; set; }
        public string CustomerEmail { get; set; }
        public string DeliveryAddress { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
