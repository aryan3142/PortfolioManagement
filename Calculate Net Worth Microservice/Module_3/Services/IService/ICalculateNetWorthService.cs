using Module_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Module_3.Services
{
    public interface ICalculateNetWorthService
    {
        int CalculateNetWorth(PortfolioDetails portFolio);
    }
}
