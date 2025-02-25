namespace BookingSystem.Application.Bookings.DTOs;

public class UpdateBookingInputDto
{
    public int Id { get; set; }
    public DateOnly DateFrom { get; set; }
    public DateOnly DateTo { get; set; }
    public int BookedQuantity { get; set; }
}
