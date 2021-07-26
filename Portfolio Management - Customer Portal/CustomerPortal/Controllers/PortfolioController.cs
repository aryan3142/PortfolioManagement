using CustomerPortal.Models;
using CustomerPortal.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerPortal.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly IPortfolioService _portfolioService;
        private readonly ILoggerManager _logger;
        public PortfolioController(IPortfolioService portfolioService,ILoggerManager logger)
        {
            _logger = logger;
            _portfolioService = portfolioService;
        }

        public IActionResult SellAssets(string assetName,int id,string assetType)
        {
            PortfolioDetails portfolioDetails = _portfolioService.GetCustomerPortfolio(id);
            AssetSaleResponse assetSaleResponse = _portfolioService.SellAsset(portfolioDetails,assetName,assetType);
            if(assetSaleResponse != null)
            {
                if(assetSaleResponse.SaleStatus == true)
                {                  
                    portfolioDetails.NetWorth = assetSaleResponse.Networth;
                    RemoveAsset(portfolioDetails, assetType, assetName);
                    _logger.LogInformation($"{assetName} sold from portfolio with portfolioId {portfolioDetails.PortfolioId}");
                    return View("GetCustomerPortfolio", portfolioDetails);
                }
            }
            _logger.LogInformation($"Error while selling assets");
            return StatusCode(500, "Asset cannot be sold now");
        }

        private void RemoveAsset(PortfolioDetails portfolioDetails, string assetType, string assetName)
        {
            if(assetType == AssetType.Stock)
            {
                StockDetails stockToBeDeleted = portfolioDetails.StockList.FirstOrDefault(x => x.StockName == assetName);
                portfolioDetails.StockList.Remove(stockToBeDeleted);
            }
            else
            {
                MutualFundDetails mutualFundToBeDeleted = portfolioDetails.MutualFundList.FirstOrDefault(x => x.MutualFundName == assetName);
                portfolioDetails.MutualFundList.Remove(mutualFundToBeDeleted);
            }
        }

        public IActionResult GetCustomerPortfolio(int portfolioId)
        {
            PortfolioDetails portfolioDetails = _portfolioService.GetCustomerPortfolio(portfolioId);
            _logger.LogInformation($"retrieving portfolio details of user with portfolioId {portfolioDetails.PortfolioId}");
            return View(portfolioDetails);
        }
    }
}
