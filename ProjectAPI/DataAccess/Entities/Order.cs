using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Order : Entity
    {
        public string GameName { get; set; }
        public string CustomerEmail { get; set; }
        public string DeliveryAddress { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
