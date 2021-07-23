using AuthorizationPortfolioManagement.Models;
using Microsoft.Extensions.Configuration;

namespace AuthorizationPortfolioManagement.Repository
{
    public interface IAuthorizationRepository
    {
        Customer CheckCredentials(LoginModel user);
        string GenerateToken(IConfiguration _config, Customer customer);
    }
}