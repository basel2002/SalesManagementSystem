using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Models
{
    public class Order
    {
        public int ID { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int? Status { get; set; }
        public string? Comments { get; set; }


        //relation with order_product
        public virtual ICollection<Order_product> Order_Products { get; set; } = new HashSet<Order_product>();


        //relation with  
        public int? CustomerID { get; set; }
        public virtual Customer Customer { get; set; }


    }
}
