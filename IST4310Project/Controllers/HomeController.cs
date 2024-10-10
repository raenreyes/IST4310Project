using IST4310Project.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IST4310Project.Controllers
{
    public class HomeController : Controller
    {
        private static readonly Dictionary<string, string> Data = new Dictionary<string, string>();
        private readonly ILogger<HomeController> _logger;
        static HomeController()
        {
            Data.Add("firstName","Michael");
            Data.Add("lastName","Jordan");
            Data.Add("gender","Male");
            Data.Add("height","197cm");
            Data.Add("occupation","Basketball");
            Data.Add("university","California State Univesity");
        }
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string? errorMessage = "")
        {
            var loginModel = new Login() { AuthenticationError = errorMessage};
            return View(loginModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult StudentHome(Login model)
        {
            if(model == null)
            {
                return Index();
            }
            if(model.UserName != "holder")
            {
                return RedirectToAction("Index", new { errorMessage = "Invalid UserName"});
            }
            if (model.Password != "holderp")
            {
                return RedirectToAction("Index", new { errorMessage = "Invalid Password" });

            }
            ViewBag.Name =$"{Data["lastName"]}, {Data["firstName"]}";
            ViewBag.Occupation = Data["occupation"];
            ViewBag.University = Data["university"];
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
