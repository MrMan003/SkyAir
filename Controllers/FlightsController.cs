using Hello.Data;
using Hello.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Hello.Controllers
{
    public class FlightController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FlightController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SearchResults(FlightSearchViewModel model)
        {
            var flights = _context.Flights
                .Where(f => f.FromAirport == model.FromAirport && f.ToAirport == model.ToAirport)
                .ToList();

            return View("Index", flights);
        }

        public IActionResult Index()
        {
            var allFlights = _context.Flights.ToList();
            return View(allFlights);
        }
    }
}
