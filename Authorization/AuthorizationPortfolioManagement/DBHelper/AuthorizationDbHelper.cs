using AuthorizationPortfolioManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationPortfolioManagement.DBHelper
{
    public class AuthorizationDbHelper
    {
        public static List<Customer> Customers { get; set; } = new List<Customer>()
        {
            new Customer()
            {
                CustomerId = 1,
                PortfolioId = 1,
                CustomerName = "Aryan Khandelwal",
                CustomerAddress1 = "Gaur Atulyam, A-206",
                CustomerAddress2 = "Omicron-1",
                CustomerCity = "Greater Noida",
                Password = "Aryan@3142",
                PhoneNumber = 252806,
                Username = "ryan3142"
            },
            new Customer()
            {
                CustomerId = 2,
                PortfolioId = 2,
                CustomerName = "Katari Deeksha",
                CustomerAddress1 = "Ram Nagar, CP",
                CustomerAddress2 = "Near Chowk",
                CustomerCity = "Agra",
                Password = "Katari@3142",
                PhoneNumber = 252899,
                Username = "katari3142"
            },
            new Customer()
            {
                CustomerId = 3,
                PortfolioId = 3,
                CustomerName = "Mudusu Sai Teza",
                CustomerAddress1 = "Near Bus Stand",
                CustomerAddress2 = "Gomti Nagar",
                CustomerCity = "Luckhnow",
                Password = "Mudusu@3142",
                PhoneNumber = 232806,
                Username = "mudusu3142"
            },
            new Customer()
            {
                CustomerId = 4,
                PortfolioId = 4,
                CustomerName = "Penchikala Lakshmi Narayana Reddy",
                CustomerAddress1 = "Subhas Chowk",
                CustomerAddress2 = "Near Bank",
                CustomerCity = "Rampur",
                Password = "Lakshmi@3142",
                PhoneNumber = 252806,
                Username = "lakshmi3142"
            }
        };

    }
}
