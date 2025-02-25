namespace BookingSystem.Application.Bookings.DTOs;

public class BookResourceInputDto
{
    public int ResourceId { get; set; }
    public DateOnly DateFrom { get; set; }
    public DateOnly DateTo { get; set; }
    public int Quantity { get; set; }    
}
