using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Models
{
    public class ProductLine
    {
        // productline properties
        public int ID { get; set; }
        public string? DescinText { get; set; }
        public string? DescinHTML { get; set; }
        public string? Image { get; set; }

        /*------------------------------------------------------------------*/

        //relation with product
        public virtual ICollection<Product> Products { get;set; } = new HashSet<Product>();
    }
}
