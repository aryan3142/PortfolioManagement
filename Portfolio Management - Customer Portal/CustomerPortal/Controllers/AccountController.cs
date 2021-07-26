using CustomerPortal.Models;
using CustomerPortal.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CustomerPortal.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly ILoggerManager _logger;

        public AccountController(IAuthorizationService authorizationService, ILoggerManager logger)
        {
            _authorizationService = authorizationService;
            _logger = logger;
        }
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
                _logger.LogInformation($"Navigated to {ViewBag.UserName}'s home page");
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginModel user)
        {
            try
            {
                Customer customer = _authorizationService.GetAuthorizatedCustomer("https://localhost:44316/api/Auth/login", user);
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
                    _logger.LogInformation($"Login Initiated");
                    return RedirectToAction("Index", "Account");
                }
                ModelState.Clear();
                _logger.LogInformation($"Unauthorized access");
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
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            _logger.LogInformation($"Logged out successfully");
            return RedirectToAction("Index", "Home");
        }
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
