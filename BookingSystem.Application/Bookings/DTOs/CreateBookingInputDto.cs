namespace BookingSystem.Application.Bookings.DTOs;

public class CreateBookingInputDto
{
    public DateOnly DateFrom { get; set; }
    public DateOnly DateTo { get; set; }
    public int BookedQuantity { get; set; }
    public int ResourceId { get; set; }
}
