using MainWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MainWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            // You can add any logic or data setup for the actual website here if needed.
            ViewBag.SubscriptionMessage = TempData["SubscriptionMessage"] as string;
            ViewBag.Subscribed = TempData["Subscribed"] as bool? ?? false;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            var aboutModel = new AboutModel
            {
                TextContent = "a comprehensive range of web and graphic design services that blend creativity and functionality to elevate your online presence. With a keen understanding of user experience, I specialize in crafting visually captivating websites that seamlessly engage your target audience. From concept to execution, I am dedicated to translating your brand's essence into captivating visuals, ensuring consistency across logos, banners, and marketing materials. My services encompass responsive web design, user interface optimization, and intuitive navigation, guaranteeing an exceptional user journey across devices. Whether you seek a stunning website, eye-catching graphics, or a harmonious fusion of both, I am committed to delivering designs that resonate with your brand identity while leaving a lasting impression on your visitors....",
                MediaUrl = "~/images/hadidesign.png" // Update with actual path
            };

            return View(aboutModel);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }




        public IActionResult Home()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
          public IActionResult Index([FromForm] EmailModel emailModel)
            {
                if (ModelState.IsValid)
                {
                    // Add the email to the EmailList in SubscriptionModel
                    SubscribtionModel.EmailList.Add(emailModel.Email);

                    TempData["SubscriptionMessage"] = "Thank you for subscribing!";
                TempData["Subscribed"] = true;
                return RedirectToAction("Home");
            }
            TempData["SubscriptionMessage"] = "An error occurred while subscribing.";
            TempData["Subscribed"] = false;
            return View();
        }
        

        public class EmailModel
        {
            public string? Email { get; set; }
        }

    }
}


