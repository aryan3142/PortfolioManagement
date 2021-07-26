using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerPortal.Models
{
    public class MutualFundTransactionDetail
    {
        [Key]
        public int MutualFundId { get; set; }
        public int PortfolioId { get; set; }
        public string MutualFundName { get; set; }
        public int MutualFundUnits { get; set; }
    }
}
