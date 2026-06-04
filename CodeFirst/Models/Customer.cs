using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? Phone { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public int? PostalCode { get; set; }
        public string? Country { get; set; }
        public decimal? CreditLimit { get; set; }



        //relation with order 
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();

        //RELATION WITH PAYMENT
        public virtual ICollection<Payment> Payments { get; set; } = new HashSet<Payment>();


        //relation with employee
        public int? SalesRepEmployeeNum { get; set; }
        public virtual Employee Employee { get; set; }

    }
}
