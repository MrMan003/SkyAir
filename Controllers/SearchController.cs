using Microsoft.AspNetCore.Mvc;
using Hello.Data;
using Hello.Models;
using System.Linq;

namespace Hello.Controllers
{
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SearchController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var flights = _context.Flights.ToList(); // or filter based on user input
            return View(flights);
        }
    }
}
