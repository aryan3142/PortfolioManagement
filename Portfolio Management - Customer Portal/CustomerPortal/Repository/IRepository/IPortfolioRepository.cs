using CustomerPortal.Models;

namespace CustomerPortal.Repository
{
    public interface IPortfolioRepository
    {
       PortfolioDetails GetPortfolioById(int id);
    }
}