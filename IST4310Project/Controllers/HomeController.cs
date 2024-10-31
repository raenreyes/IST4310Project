using IST4310Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IST4310Project.Controllers
{
    public class HomeController : Controller
    {
        private static readonly List<Student> Data = new List<Student>();
        private readonly ILogger<HomeController> _logger;
        static HomeController()
        {
            foreach (var studentData in DatabaseHelper.GetStudents())
            {

                Data.Add(studentData);
            }

        }
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string? errorMessage = "")
        {
            var loginModel = new Login() { AuthenticationError = errorMessage };
            return View(loginModel);
        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult NewUser(string firstName, string lastName, string email, string password,
                                  string gender, string height, string dept, string major)
        {
            var hashedPassword = PasswordOneWayHash.GetHash(password);
            DatabaseHelper.InsertNew(firstName, lastName, email, hashedPassword, gender, int.Parse(height), dept, major);
            return Json(new { Message = $"User {firstName} created sucessfully!" });
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult StudentHome(Login model)
        {
            if (model == null)
            {
                return Index();
            }
            if (model.UserName != "holder")
            {
                return RedirectToAction("Index", new { errorMessage = "Invalid UserName" });
            }
            if (model.Password != "holderp")
            {
                return RedirectToAction("Index", new { errorMessage = "Invalid Password" });

            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
