using BookingSystem.Application.Core;
using BookingSystem.EntityFrameworkCore;
using MediatR;

namespace BookingSystem.Application.Bookings.Commands;

public class DeleteBooking
{
    public class Command : IRequest<Result<Unit>>
    {
        public required int Id { get; set; }
    }
    public class Handler(AppDbContext context) : IRequestHandler<Command, Result<Unit>>
    {
        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            var booking = await context.Bookings
                .FindAsync([request.Id], cancellationToken);

            if (booking == null)
                return Result<Unit>.Failure("Booking not found", 404);

            context.Remove(booking);

            //await context.SaveChangesAsync(cancellationToken);
            var result = await context.SaveChangesAsync(cancellationToken) > 0;

            if (!result) return Result<Unit>.Failure("Failed to delete booking", 400);

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
