using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Models
{
    public class Payment
    {
        public string CheckNum { get; set; }
        public DateTime? PaymentDate { get; set; }
        public decimal? Amount { get; set; }

        //relation with customer
        public int? CustomerID { get; set; }
        public virtual Customer Customer { get; set; }


    }
}
