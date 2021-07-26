using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerPortal.Models
{
    public class StockTransactionDetail
    {
        [Key]
        public int StockDetailId { get; set; }
        public int PortfolioId { get; set; }
        public string StockName { get; set; }
        public int StockCount { get; set; }
    }
}
