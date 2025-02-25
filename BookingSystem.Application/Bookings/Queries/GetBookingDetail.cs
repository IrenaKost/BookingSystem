using BookingSystem.Domain.Bookings;
using BookingSystem.EntityFrameworkCore;
using MediatR;

namespace BookingSystem.Application.Bookings.Queries;

public class GetBookingDetail
{
    public class Query : IRequest<Booking>
    {
        public required int Id { get; set; }
    }

    public class Handler(AppDbContext context) : IRequestHandler<Query, Booking>
    {
        public async Task<Booking> Handle(Query request, CancellationToken cancellationToken)
        {
            var booking = await context.Bookings.FindAsync([request.Id], cancellationToken);

            if (booking == null)
            {
                throw new Exception("Booking not found!");
            }

            return booking;
        }
    }
}
