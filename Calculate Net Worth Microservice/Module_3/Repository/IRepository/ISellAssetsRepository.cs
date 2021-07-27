using Module_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Module_3.Repository
{
    public interface ISellAssetsRepository
    {
        AssetSaleResponse SellAsset(PortfolioDetails portfolioDetails);
    }
}
