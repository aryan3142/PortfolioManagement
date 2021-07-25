using MutualFund.Models;
using System.Collections.Generic;

namespace MutualFund.Repository
{
    public interface IMutualFundRepository
    {
        MutualFundDetails GetMutualFund(string mutualFundName);
    }
}