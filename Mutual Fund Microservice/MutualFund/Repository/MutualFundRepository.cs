using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DailyShare.Controllers;
using MutualFund.DbHelper;
using MutualFund.Models;

namespace MutualFund.Repository
{
    public class MutualFundRepository : IMutualFundRepository
    {
        public MutualFundDetails GetMutualFund(string mutualFundName)
        {
            MutualFundDetails mutualFundDetails = DbService.MutualFundDetails.FirstOrDefault(c => c.MutualFundName.ToLower() == mutualFundName.ToLower());
            return mutualFundDetails == null ? null : mutualFundDetails;
        }
    }
}
