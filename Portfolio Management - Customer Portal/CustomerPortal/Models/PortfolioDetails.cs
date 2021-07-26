using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerPortal.Models
{
    public class PortfolioDetails
    {
        public int PortfolioId { get; set; }
        public List<StockDetails> StockList { get; set; }
        public List<MutualFundDetails> MutualFundList { get; set; }

        //Added three properties to implement Asset Selling

        public string AssetTypeToBeSold { get; set; }
        public string AssetNameToBeSold { get; set; }
        public int? NetWorth { get; set; }
    }
}
