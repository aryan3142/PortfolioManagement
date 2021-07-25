using MutualFund.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MutualFund.DbHelper
{
    public class DbService
    {
        public static List<MutualFundDetails> MutualFundDetails { get; set; } = new List<MutualFundDetails>()
        {
            new MutualFundDetails()
            { 
                MutualFundId = 1, 
                MutualFundName = "HDFC",
                MutualFundValue=10
            },
            new MutualFundDetails()
            {
                MutualFundId = 2, 
                MutualFundName = "ICICI", 
                MutualFundValue = 20 
            },
            new MutualFundDetails()
            {
                MutualFundId = 3,
                MutualFundName = "MIRAE", 
                MutualFundValue = 30 
            },
            new MutualFundDetails()
            { 
                MutualFundId = 4, 
                MutualFundName = "ICICI", 
                MutualFundValue = 40 
            },
			new MutualFundDetails()
            { 
                MutualFundId = 5, 
                MutualFundName = "Parag", 
                MutualFundValue = 50 
            },
			new MutualFundDetails()
            { 
                MutualFundId = 6, 
                MutualFundName = "UTI", 
                MutualFundValue = 60 
            },
			new MutualFundDetails()
            { 
                MutualFundId = 7, 
                MutualFundName = "MIRAEBLUECHIFFUND", 
                MutualFundValue = 70 
            },
			new MutualFundDetails()
            { 
                MutualFundId = 8, 
                MutualFundName = "ICICITECHNOLOGYFUND", 
                MutualFundValue = 80
            },
			new MutualFundDetails()
            { 
                MutualFundId = 9, 
                MutualFundName = "ParagParekhSENSEXFUND", 
                MutualFundValue = 90 
            },
			new MutualFundDetails()
            { 
                MutualFundId = 10, 
                MutualFundName = "ParagParekhFUND", 
                MutualFundValue = 10 
            },
			new MutualFundDetails()
            { 
                MutualFundId = 11, 
                MutualFundName = "LIC", 
                MutualFundValue = 20
            },
			new MutualFundDetails()
            { 
                MutualFundId = 12, 
                MutualFundName = "NIPPONETFFUND", 
                MutualFundValue = 32
            },
			new MutualFundDetails()
            { 
                MutualFundId = 13, 
                MutualFundName = "ICICIPRUMIDCAPFUND", 
                MutualFundValue = 23
            },
            new MutualFundDetails()
            {
                MutualFundId = 14,
                MutualFundName = "SBISMALLCAPFUND",
                MutualFundValue = 33
            },
            new MutualFundDetails()
            {
                MutualFundId = 15,
                MutualFundName = "ICICIPRUMIDCAPFUND",
                MutualFundValue = 13
            },
            new MutualFundDetails()
            {
                MutualFundId = 16,
                MutualFundName = "NIPPONETFFUND",
                MutualFundValue = 50
            },
             new MutualFundDetails()
            {
                MutualFundId = 17,
                MutualFundName = "NIFTYBEESETFFUND",
                MutualFundValue = 40
            },
              new MutualFundDetails()
            {
                MutualFundId = 18,
                MutualFundName = "ParagParekhFUND",
                MutualFundValue = 30
            }
        };
        
    }
}
