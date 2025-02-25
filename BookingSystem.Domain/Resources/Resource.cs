using BookingSystem.Domain.Bookings;
using BookingSystem.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Resources;

public class Resource : IEntity<int>
{
    public int Id { get; protected set; }
    public required string Name { get; set; }
    public required int Quantity { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = [];

}
