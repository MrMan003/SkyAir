using Hello.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Hello.Controllers
{
    public class AccountController : Controller
    {
        // ✅ Hardcoded users list
        private static readonly List<User> users = new()
        {
            new User { Username = "admin", Password = "admin123" },
            new User { Username = "user", Password = "pass123" }
        };

        // GET: /Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View(); // Points to Views/Account/Login.cshtml
        }

        // POST: /Account/Login
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user != null)
            {
                // Optional: store user info in session or cookie if needed
                return RedirectToAction("Dashboard");
            }

            ViewBag.Error = "Invalid credentials";
            return View();
        }

        // GET: /Account/Dashboard
        [HttpGet]
        public IActionResult Dashboard()
        {
            return View(); // Points to Views/Account/Dashboard.cshtml
        }
    }
}
