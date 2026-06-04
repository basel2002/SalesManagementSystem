using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Models
{
    public class Product
    {
        //product Properties
        public int Code { get; set; }
        public string? Name { get; set; }
        public int? Scale { get; set; }
        public string? Vendor { get; set; }
        public string? PdtDescription { get; set; }
        public int QtyInStock { get; set; }
        public decimal BuyPrice { get; set; }
        public string? MSRP { get; set; }
        /*------------------------------------------------------------------*/

        // relation with productline
        public int? ProductLineID { get; set; }
        public virtual ProductLine ProductLine { get; set; }
        /*------------------------------------------------------------------*/

        //relation with order_product
        public virtual ICollection<Order_product> Order_Products { get; set; } = new HashSet<Order_product>();

    }
}
