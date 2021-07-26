
using CustomerPortal.Context;
using CustomerPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerPortal.Repository
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly ApplicationDbContext _context;

        public PortfolioRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public PortfolioDetails GetPortfolioById(int id)
        {
            PortfolioDetails customerPortfolio = new PortfolioDetails() { };
            customerPortfolio.PortfolioId = id;
            customerPortfolio.StockList = new List<StockDetails>();
            customerPortfolio.MutualFundList = new List<MutualFundDetails>();
            List<StockTransactionDetail> stockDetails = _context.StockDetails.Where(x => x.PortfolioId == id).ToList();
            foreach (var stock in stockDetails)
            {
                customerPortfolio.StockList.Add(new StockDetails()
                {
                    StockCount = stock.StockCount,
                    StockName = stock.StockName
                });
            }
            List<MutualFundTransactionDetail> mutualFundDetails = _context.MutualFundDetails.Where(x => x.PortfolioId == id).ToList();
            foreach (var mutualFund in mutualFundDetails)
            {
                customerPortfolio.MutualFundList.Add(new MutualFundDetails()
                {
                    MutualFundName = mutualFund.MutualFundName,
                    MutualFundUnits = mutualFund.MutualFundUnits
                });
            }
            return customerPortfolio;
        } 
    }
}
