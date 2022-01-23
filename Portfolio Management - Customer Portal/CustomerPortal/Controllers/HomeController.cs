using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CustomerPortal.Controllers
{
    /// <summary>
    /// Provides methods that respond to HTTP requests for home controller
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Logger service
        /// </summary>
        private readonly ILogger<HomeController> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class
        /// </summary>
        /// <param name="logger">Logger</param>
        public HomeController(ILogger<HomeController> logger)
        { 
            this.logger = logger;
        }

        /// <summary>
        /// Index method to return home page view
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            logger.LogInformation($"Navigated to Home page");
            return View();
        }

        /// <summary>
        /// Action method to navigate to login page
        /// </summary>
        /// <param name="status"></param>
        /// <returns>Login page</returns>
        [Route("login")]
        public IActionResult Login(bool status = false)
        {
            if(status == true)
            {
                ViewBag.Status = true;
                logger.LogInformation(nameof(Login) + $"method invoked");
                return View();              
            }
            return View();
        }

        /// <summary>
        /// Action method to navigate to contact us page
        /// </summary>
        /// <returns>Contact us page</returns>
        public IActionResult ContactUs()
        {
            return View();
        }

        /// <summary>
        /// Action method to navigate to about us page
        /// </summary>
        /// <returns>About us page</returns>
        public IActionResult AboutUs()
        {
            return View();
        }        
    }
}
