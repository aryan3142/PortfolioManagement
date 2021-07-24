using DailySharePriceMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailySharePriceMS.DBHelper
{
    public class DbHelper
    {
        public static List<DailyStockDetails> dailyStockDetails { get; set; } = new List<DailyStockDetails>()
        {
            new DailyStockDetails()
            {
                StockId = 1,
                StockName = "HDFC",
                StockValue=10
            },
            new DailyStockDetails()
            {
                StockId = 2,
                StockName = "Asian Paints",
                StockValue = 20
            },
            new DailyStockDetails()
            {
                StockId = 3,
                StockName = "AXIS",
                StockValue = 30
            },
            new DailyStockDetails()
            {
                StockId = 4,
                StockName = "Bajaj Automobiles",
                StockValue = 40
            },
            new DailyStockDetails()
            {
                StockId = 5,
                StockName = "ICICI",
                StockValue = 40
            },
            new DailyStockDetails()
            {
                StockId = 6,
                StockName = "INFOSYS",
                StockValue = 40
            },
            new DailyStockDetails()
            {
                StockId = 7,
                StockName = "Wipro",
                StockValue = 45
            },
            new DailyStockDetails()
            {
                StockId = 8,
                StockName = "Tata Motors",
                StockValue = 42
            },
            new DailyStockDetails()
            {
                StockId = 9,
                StockName = "Lupin",
                StockValue = 40
            },
            new DailyStockDetails()
            {
                StockId = 10,
                StockName = "ITC",
                StockValue = 50
            },
            new DailyStockDetails()
            {
                StockId = 11,
                StockName = "BajajFinance",
                StockValue = 50
            },
            new DailyStockDetails()
            {
                StockId = 12,
                StockName = "JSWSteel",
                StockValue = 50
            },
            new DailyStockDetails()
            {
                StockId = 13,
                StockName = "HCL",
                StockValue = 50
            },
            new DailyStockDetails()
            {
                StockId = 14,
                StockName = "NestleIndia",
                StockValue = 50
            },
            new DailyStockDetails()
            {
                StockId = 15,
                StockName = "SBI",
                StockValue = 50
            },
            new DailyStockDetails()
            {
                StockId = 16,
                StockName = "Tata Motors",
                StockValue = 50
            },
            new DailyStockDetails()
            {
                StockId = 17,
                StockName = "HDFC Insurance",
                StockValue = 50
            },
            new DailyStockDetails()
            {
                StockId = 18,
                StockName = "SBI",
                StockValue = 50
            }
        };
    }
}
