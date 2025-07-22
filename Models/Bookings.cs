using Hello.Models;

public class Booking
{
    public int Id { get; set; }
    public int FlightId { get; set; }
    public string UserId { get; set; } = string.Empty;
    public int Passengers { get; set; }
    public DateTime BookingDate { get; set; }

    public required Flight Flight { get; set; }
}
