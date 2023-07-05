using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademiPlusMicroServiceProject.Order.Domain.Entities
{
    public class Order
    {
        public string CustomerID { get; set; }
        public DateTime CreatedDate { get; set; }
        public Adress Adress { get; set; }
        private readonly List<OrderItem> orderItems;
    }
    
}
