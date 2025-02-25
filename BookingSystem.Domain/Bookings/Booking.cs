using BookingSystem.Domain.Resources;
using BookingSystem.Domain.Shared;

namespace BookingSystem.Domain.Bookings;

public class Booking : IEntity<int>
{
    public int Id { get; protected set; }
    public DateOnly DateFrom { get; set; }
    public DateOnly DateTo { get; set; }
    public int BookedQuantity { get; set; }
    public int ResourceId { get; set; }

    public virtual Resource Resource { get; set; } = default!;

}
