using Module_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerPortal.Models;
using Module_3.Services;

namespace Module_3.Repository
{
    public class SellAssetsRepository : ISellAssetsRepository
    {
        private readonly ICalculateNetWorthService _netWorthService;

        public SellAssetsRepository(ICalculateNetWorthService netWorthService)
        {
            _netWorthService = netWorthService;
        }

        public AssetSaleResponse SellAsset(PortfolioDetails portfolioDetails)
        {

            AssetSaleResponse assetSaleResponse = null;

            bool saleStatus = false;

            if(portfolioDetails.AssetTypeToBeSold == AssetType.Stock)
            {
                StockDetails stockToBeSold =  portfolioDetails.StockList.FirstOrDefault(x => x.StockName.ToLower() == portfolioDetails.AssetNameToBeSold.ToLower());

                saleStatus = portfolioDetails.StockList.Remove(stockToBeSold);
                
            }
            else
            {
                MutualFundDetails mutualFundToBeSold = portfolioDetails.MutualFundList.FirstOrDefault(x => x.MutualFundName.ToLower() == portfolioDetails.AssetNameToBeSold.ToLower());
                
                saleStatus = portfolioDetails.MutualFundList.Remove(mutualFundToBeSold);
            }

            assetSaleResponse = new AssetSaleResponse()
            {
                SaleStatus = saleStatus,
                //NetWorth = //call the calulated net worth function again to calculate networth and assign that value here
                NetWorth = _netWorthService.CalculateNetWorth(portfolioDetails)
            };

            return assetSaleResponse;
        }
    }
}
