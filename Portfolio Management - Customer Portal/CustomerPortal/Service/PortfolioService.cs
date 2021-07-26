using CustomerPortal.Models;
using CustomerPortal.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CustomerPortal.Service
{
    public class PortfolioService : IPortfolioService
    {
        private readonly IPortfolioRepository _portfolioRepository;
        public PortfolioService(IPortfolioRepository portfolioRepository)
        {
            _portfolioRepository = portfolioRepository;
        }

        public PortfolioDetails GetCustomerPortfolio(int portfolioId)
        {
            PortfolioDetails portfolioDetails = _portfolioRepository.GetPortfolioById(portfolioId);
            portfolioDetails.NetWorth = CalculateNetWorth(portfolioDetails);
            return portfolioDetails;
        }

        public int CalculateNetWorth(PortfolioDetails portfolioDetails)
        {
            string uri = "http://localhost:27004/api/CalculateNetWorth/netWorth";
            var jsonData = JsonConvert.SerializeObject(portfolioDetails);
            var encodedData = new StringContent(jsonData, Encoding.UTF8, "application/json");
            using var client = new HttpClient();
            var response = client.PostAsync(uri, encodedData).Result;
            if (response != null)
            {
                int netWorth = Convert.ToInt32(response.Content.ReadAsStringAsync().Result);
                return netWorth;
            }
            return 0;
        }

        public AssetSaleResponse SellAsset(PortfolioDetails portfolioDetails, string assetName, string assetType)
        {
            portfolioDetails.AssetNameToBeSold = assetName;
            portfolioDetails.AssetTypeToBeSold = assetType;
            var jsonData = JsonConvert.SerializeObject(portfolioDetails);
            var encodedData = new StringContent(jsonData, Encoding.UTF8, "application/json");
            string uri = "http://localhost:27004/api/CalculateNetWorth/sellAsset";
            using var client = new HttpClient();
            var response = client.PostAsync(uri, encodedData).Result;
            if (response != null)
            {
                AssetSaleResponse assetSaleResponse = JsonConvert.DeserializeObject<AssetSaleResponse>(response.Content.ReadAsStringAsync().Result);
                return assetSaleResponse;
            }
            return null;
        }
    }
}
