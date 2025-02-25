using BookingSystem.Domain.Bookings;
using BookingSystem.EntityFrameworkCore;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Application.Bookings.Queries
{
    public class GetBookingList
    {
        public class Query : IRequest<List<Booking>> { }


        public class Handler(AppDbContext context) : IRequestHandler<Query, List<Booking>>
        {
            public async Task<List<Booking>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await context.Bookings.ToListAsync(cancellationToken);
            }
        }
    }
}
