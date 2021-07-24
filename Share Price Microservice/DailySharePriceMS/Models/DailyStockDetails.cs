using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailySharePriceMS.Models
{
    public class DailyStockDetails
    {
        public int StockId { get; set; }
        public string StockName { get; set; }
        public int StockValue { get; set; }
    }
}
