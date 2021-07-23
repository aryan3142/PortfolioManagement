using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationPortfolioManagement.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public int PortfolioId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress1 { get; set; }
        public string CustomerAddress2 { get; set; }
        public string CustomerCity { get; set; }
        public int PhoneNumber { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string token { get; set; }
        public int Age { get; set; }
    }
}
