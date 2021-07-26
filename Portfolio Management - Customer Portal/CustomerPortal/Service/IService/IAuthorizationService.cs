using CustomerPortal.Models;

namespace CustomerPortal.Service
{
    public interface IAuthorizationService
    {
        Customer GetAuthorizatedCustomer(string url, LoginModel user);
    }
}