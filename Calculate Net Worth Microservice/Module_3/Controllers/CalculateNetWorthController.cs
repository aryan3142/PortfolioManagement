using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Module_3.Services;
using Module_3.Models;
using Microsoft.Extensions.Configuration;
using Module_3.Repository;

namespace Module_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculateNetWorthController : ControllerBase
    {
        private readonly ICalculateNetWorthService _netWorthService;
        private readonly ISellAssetsRepository _sellAssetRepository;


        public CalculateNetWorthController(ICalculateNetWorthService netWorthService, 
            ISellAssetsRepository sellAssetRepository)
        {
            _netWorthService = netWorthService;
            _sellAssetRepository = sellAssetRepository;
        }
        [HttpPost]
        [Route("netWorth")]
        public ActionResult GetNetWorth([FromBody]PortfolioDetails portFolio)
        {
            if (portFolio == null)
            {
                return BadRequest();
            }
            int netWorth = _netWorthService.CalculateNetWorth(portFolio);
            return Ok(Convert.ToString(netWorth));
        }

        [HttpPost]
        [Route("sellAsset")]
        public IActionResult SellAsset([FromBody]PortfolioDetails portfolioDetails)
        {
            AssetSaleResponse assetSaleResponse = _sellAssetRepository.SellAsset(portfolioDetails);

            if(assetSaleResponse != null)
            {
                return Ok(assetSaleResponse);
            }

            return NoContent();
        }
    }
}
