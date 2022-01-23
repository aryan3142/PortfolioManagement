using CustomerPortal.Models;
using CustomerPortal.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace CustomerPortal.Controllers
{
    /// <summary>
    /// Provides methods that respond to HTTP requests for account controller
    /// </summary>
    public class AccountController : Controller
    {
        /// <summary>
        /// Authorization service
        /// </summary>
        private readonly IAuthorizationService authorizationService;

        /// <summary>
        /// Logger service
        /// </summary>
        private readonly ILogger<AccountController> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class
        /// </summary>
        /// <param name="authorizationService">Authorization service</param>
        /// <param name="logger">Logger service</param>
        public AccountController(IAuthorizationService authorizationService, ILogger<AccountController> logger)
        {
            this.authorizationService = authorizationService;
            this.logger = logger;
        }

        /// <summary>
        /// Login method
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Login status</returns>
        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginModel user)
        {
            try
            {
                Customer customer = authorizationService.GetAuthorizatedCustomer("https://localhost:44316/api/Auth/login", user);
                if(customer != null)
                {
                   using (var client = new HttpClient())
                    {
                        var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                        client.DefaultRequestHeaders.Accept.Add(contentType);
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", customer.token);
                        HttpContext.Session.SetString("Username", user.Username);
                        HttpContext.Session.SetString("Name", customer.CustomerName);
                        HttpContext.Session.SetString("CustomerAddress1", customer.CustomerAddress1);
                        HttpContext.Session.SetString("CustomerAddress2", customer.CustomerAddress2);
                        HttpContext.Session.SetString("City", customer.CustomerCity);
                        HttpContext.Session.SetString("Phone", Convert.ToString(customer.PhoneNumber));
                        HttpContext.Session.SetString("PortfolioId", Convert.ToString(customer.PortfolioId));
                    }
                    logger.LogInformation($"Login Initiated");
                    return RedirectToAction("Index", "Account");
                }
                ModelState.Clear();
                logger.LogInformation($"Unauthorized access");
                ModelState.AddModelError("", "Username or Password is incorrect");
                return RedirectToAction("Login","Home", new { status = true });

            }
            catch(Exception e)
            {
                ErrorViewModel error = new ErrorViewModel
                {
                    ErrorMessage = e.Message
                };
                return View("Error",error);
            }
        }

        /// <summary>
        /// Logout method
        /// </summary>
        /// <returns>Redirects to home page</returns>
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            logger.LogInformation($"Logged out successfully");
            return RedirectToAction("Index", "Home");
        }


        /// <summary>
        /// Index method
        /// </summary>
        public IActionResult Index()
        {
            if (CheckStatus())
            {
                ViewBag.UserName = HttpContext.Session.GetString("Username");
                ViewBag.Address1 = HttpContext.Session.GetString("CustomerAddress1");
                ViewBag.Address2 = HttpContext.Session.GetString("CustomerAddress2");
                ViewBag.City = HttpContext.Session.GetString("City");
                ViewBag.Name = HttpContext.Session.GetString("Name");
                ViewBag.Phone = HttpContext.Session.GetString("Phone");
                ViewBag.PortfolioId = HttpContext.Session.GetString("PortfolioId");
                logger.LogInformation($"Navigated to {ViewBag.UserName}'s home page");
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Check login status
        /// </summary>
        /// <returns>True if login initiated successfully, false otherwise</returns>
        private bool CheckStatus()
        {
            if (HttpContext.Session.GetString("Username") != null)
            {
                return true;
            }
            return false;
        }

    }
}
