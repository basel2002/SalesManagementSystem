using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? Extension { get; set; }
        public string? Email { get; set; }
        public string? JobTitle { get; set; }


        //relation with customer
        public virtual ICollection<Customer> Customers { get; set; } = new HashSet<Customer>();

        //relation with office 
        public int? OfficeCode { get; set; }
        public virtual Office Office { get; set; }

        //self relationship
        public int? ReportsTo { get; set; }
        public virtual Employee? Manager { get; set; }
        public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();



    }
}
