using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Models
{
    public class Order_product
    {
        //properties

        public int ID { get; set; }
        public int? Qty { get; set; }
        public decimal? PriceEach { get; set; }


        //relation with product
        public int? ProductCode { get; set; }
        public virtual Product Product { get; set; }        /*------------------------------------------------------------------*/
        /*------------------------------------------------------------------*/

        // relation with order
         public int? OrderID { get; set; }
        public virtual Order Order { get; set; }




    }
}
