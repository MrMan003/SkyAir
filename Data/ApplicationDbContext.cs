using Microsoft.EntityFrameworkCore;
using Hello.Models;

namespace Hello.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Flight> Flights { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
