using Hello.Data;
using Hello.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Hello.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Dashboard (Home)
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.SuccessMessage = TempData["SuccessMessage"] as string;
            return View();
        }

        // POST: Search flights
        [HttpPost]
        public IActionResult Search(FlightSearchInputModel model)
        {
            if (string.IsNullOrEmpty(model.FromAirport) || string.IsNullOrEmpty(model.ToAirport))
            {
                ModelState.AddModelError("", "Both From and To airports must be specified.");
                return View("Index");
            }

            var results = _context.Flights
                .Where(f => f.FromAirport == model.FromAirport && f.ToAirport == model.ToAirport)
                .ToList();

            return View("SearchResults", results);
        }

        // GET: Add new flight
        [HttpGet]
        public IActionResult AddFlight()
        {
            ViewBag.SuccessMessage = TempData["SuccessMessage"] as string;
            return View();
        }

        // POST: Save new flight
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddFlight(Flight flight)
        {
            if (ModelState.IsValid)
            {
                _context.Flights.Add(flight);
                await _context.SaveChangesAsync();

                // Show thank you message after redirect
                TempData["SuccessMessage"] = "Thank you for the updation, the details have been updated.";
                return RedirectToAction("AddFlight");
            }

            return View(flight);
        }
    }

    // Input model for search
    public class FlightSearchInputModel
    {
        public string? FromAirport { get; set; }
        public string? ToAirport { get; set; }
    }
}
