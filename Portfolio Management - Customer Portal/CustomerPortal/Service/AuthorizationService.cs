using CustomerPortal.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CustomerPortal.Service
{
    public class AuthorizationService : IAuthorizationService
    {
        public Customer GetAuthorizatedCustomer(string url, LoginModel user)
        {
            try
            {
                var jsonData = JsonConvert.SerializeObject(user);
                var encodedData = new StringContent(jsonData, Encoding.UTF8, "application/json");
                using var client = new HttpClient();
                var response = client.PostAsync(url, encodedData).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var customer = JsonConvert.DeserializeObject<Customer>(response.Content.ReadAsStringAsync().Result);
                    return customer;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
