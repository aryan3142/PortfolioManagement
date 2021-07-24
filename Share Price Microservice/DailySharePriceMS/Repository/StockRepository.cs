using DailySharePriceMS.DBHelper;
using DailySharePriceMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailySharePriceMS.Repository
{
    public class StockRepository :IStockRepository
    {
        public DailyStockDetails GetDailyShare(string stockName)
        {
            DailyStockDetails stockDetails =  DbHelper.dailyStockDetails.FirstOrDefault(c => c.StockName.ToLower() == stockName.ToLower());
            return stockDetails == null ? null : stockDetails;
        }
    }
}
