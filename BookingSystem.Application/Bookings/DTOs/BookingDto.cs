using BookingSystem.Application.Resources.DTOs;

namespace BookingSystem.Application.Bookings.DTOs;

public class BookingDto
{
    public int Id { get; set; }
    public DateOnly DateFrom { get; set; }
    public DateOnly DateTo { get; set; }
    public int BookedQuantity { get; set; }
    public int ResourceId { get; set; }
    public ResourceDto Resource { get; set; } = default!;
}
