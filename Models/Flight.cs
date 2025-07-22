using System;
using System.ComponentModel.DataAnnotations;

namespace Hello.Models
{
    public class Flight
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Flight number is required")]
        [Display(Name = "Flight Number")]
        public string FlightNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "From Airport is required")]
        [Display(Name = "From Airport")]
        public string FromAirport { get; set; } = string.Empty;

        [Required(ErrorMessage = "To Airport is required")]
        [Display(Name = "To Airport")]
        public string ToAirport { get; set; } = string.Empty;

        [Required(ErrorMessage = "Departure Time is required")]
        [Display(Name = "Departure Time")]
        [DataType(DataType.Time)]
        public string DepartureTime { get; set; } = string.Empty;

        [Required(ErrorMessage = "Arrival Time is required")]
        [Display(Name = "Arrival Time")]
        [DataType(DataType.Time)]
        public string ArrivalTime { get; set; } = string.Empty;

        [Required(ErrorMessage = "Departure Date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Departure Date")]
        public DateTime Date { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Return Date")]
        public DateTime? ReturnDate { get; set; }

        [Required(ErrorMessage = "Class is required")]
        [Display(Name = "Flight Class")]
        public string Class { get; set; } = string.Empty; // Economy / Business / Prime

    }
}
