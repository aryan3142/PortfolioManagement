using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Module_3.Models
{
    public class PortfolioDetails
    {
        public int portFolioid { get; set; }
        public List<StockDetails> StockList { get; set; }
        public List<MutualFundDetails> MutualFundList { get; set; }

        //adding some properties to implement sell assets
        public string AssetTypeToBeSold { get; set; }
        public string AssetNameToBeSold { get; set; }
        public int? NetWorth { get; set; }

    }
}
