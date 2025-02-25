using AutoMapper;
using BookingSystem.Application.Bookings.DTOs;
using BookingSystem.Application.Core;
using BookingSystem.Domain.Bookings;
using BookingSystem.Domain.Resources;
using BookingSystem.EntityFrameworkCore;
using MediatR;
using static BookingSystem.Application.Bookings.Commands.BookResource;

namespace BookingSystem.Application.Bookings.Commands;

public class CreateBooking
{
    public class Command : IRequest<Result<int>>
    {
        public required CreateBookingInputDto BookingDto { get; set; }
    }

    public class Handler(AppDbContext context, IMapper mapper) : IRequestHandler<Command, Result<int>>
    {
        public async Task<Result<int>> Handle(Command request, CancellationToken cancellationToken)
        {
            var booking = mapper.Map<Booking>(request.BookingDto);

            var resource = await context.Resources
                .FindAsync(request.BookingDto.ResourceId, cancellationToken);

            if (resource == null)
                return Result<int>.Failure("Resource for the booking not found", 404);
           

            if (request.BookingDto.DateFrom >= request.BookingDto.DateTo)
                throw new InvalidOperationException("Start date can not be after end date.");

            if (request.BookingDto.Quantity <= 0)
                throw new InvalidOperationException("Requested quantity must be greater than 0.");

            if ((request.BookingDto.DateFrom < DateOnly.FromDateTime(DateTime.Now)) || (request.BookingDto.DateTo < DateOnly.FromDateTime(DateTime.Now)))
                throw new InvalidOperationException("Requested date must be greater than current date.");

            context.Bookings.Add(booking);

            var result = await context.SaveChangesAsync(cancellationToken) > 0;

            if (!result) return Result<int>.Failure("Failed to create booking", 400);

            return Result<int>.Success(booking.Id);
        }
    }
}
