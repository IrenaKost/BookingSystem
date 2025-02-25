using AutoMapper;
using BookingSystem.Application.Bookings.DTOs;
using BookingSystem.Application.Core;
using BookingSystem.EntityFrameworkCore;
using MediatR;

namespace BookingSystem.Application.Bookings.Commands;

public class EditBooking
{
    public class Command : IRequest<Result<Unit>>
    {
        public required UpdateBookingInputDto BookingDto { get; set; }
    }

    public class Handler(AppDbContext context, IMapper mapper) : IRequestHandler<Command, Result<Unit>>
    {
        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            var booking = await context.Bookings
                .FindAsync(request.BookingDto.Id, cancellationToken);

            if (booking == null)
                return Result<Unit>.Failure("Booking not found.", 404);

            mapper.Map(request.BookingDto, booking);

            var result = await context.SaveChangesAsync(cancellationToken) > 0;

            if (!result) return Result<Unit>.Failure("Failed to update booking", 400);

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
