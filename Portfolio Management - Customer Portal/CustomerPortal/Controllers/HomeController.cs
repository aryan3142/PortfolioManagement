using CustomerPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILoggerManager _logger;

        public HomeController(ILoggerManager logger)
        { 
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation($"Navigated to Home page");
            return View();
        }

        [Route("login")]
        public IActionResult Login(bool status = false)
        {
            if(status == true)
            {
                ViewBag.Status = true;
                _logger.LogInformation(nameof(Login) + $"method invoked");
                return View();              
            }
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }        
    }
}
