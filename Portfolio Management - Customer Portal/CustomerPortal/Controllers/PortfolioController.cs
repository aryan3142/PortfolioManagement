using CustomerPortal.Models;
using CustomerPortal.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace CustomerPortal.Controllers
{
    /// <summary>
    /// Provides methods that respond to HTTP requests for portfolio controller
    /// </summary>
    public class PortfolioController : Controller
    {
        /// <summary>
        /// Portfolio service
        /// </summary>
        private readonly IPortfolioService portfolioService;

        /// <summary>
        /// Logger service
        /// </summary>
        private readonly ILogger<PortfolioController> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="PortfolioController"/> class
        /// </summary>
        /// <param name="portfolioService">Portfolio service</param>
        /// <param name="logger">Logger service</param>
        public PortfolioController(IPortfolioService portfolioService,ILogger<PortfolioController> logger)
        {
            this.logger = logger;
            this.portfolioService = portfolioService;
        }

        /// <summary>
        /// Sell assets
        /// </summary>
        /// <param name="assetName">Asset name</param>
        /// <param name="id">Asset id</param>
        /// <param name="assetType">Asset type</param>
        /// <returns></returns>
        public IActionResult SellAssets(string assetName,int id,string assetType)
        {
            PortfolioDetails portfolioDetails = this.portfolioService.GetCustomerPortfolio(id);
            AssetSaleResponse assetSaleResponse = this.portfolioService.SellAsset(portfolioDetails,assetName,assetType);
            if(assetSaleResponse != null)
            {
                if(assetSaleResponse.SaleStatus == true)
                {                  
                    portfolioDetails.NetWorth = assetSaleResponse.Networth;
                    RemoveAsset(portfolioDetails, assetType, assetName);
                    logger.LogInformation($"{assetName} sold from portfolio with portfolioId {portfolioDetails.PortfolioId}");
                    return View("GetCustomerPortfolio", portfolioDetails);
                }
            }
            logger.LogInformation($"Error while selling assets");
            return StatusCode(500, "Asset cannot be sold now");
        }

        /// <summary>
        /// Get customer portfolio
        /// </summary>
        /// <param name="portfolioId">Portfolio id</param>
        /// <returns>Customer portfolio page</returns>
        public IActionResult GetCustomerPortfolio(int portfolioId)
        {
            PortfolioDetails portfolioDetails = this.portfolioService.GetCustomerPortfolio(portfolioId);
            this.logger.LogInformation($"retrieving portfolio details of user with portfolioId {portfolioDetails.PortfolioId}");
            return View(portfolioDetails);
        }

        /// <summary>
        /// Remove asset
        /// </summary>
        /// <param name="portfolioDetails">Portfolio details</param>
        /// <param name="assetType">Asset type</param>
        /// <param name="assetName">Asset name</param>
        private static void RemoveAsset(PortfolioDetails portfolioDetails, string assetType, string assetName)
        {
            if(assetType.Equals(AssetType.Stock))
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
    }
}
