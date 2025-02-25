using AutoMapper;
using BookingSystem.Application.Bookings.DTOs;
using BookingSystem.Application.Core;
using BookingSystem.Application.Services;
using BookingSystem.Domain.Bookings;
using BookingSystem.EntityFrameworkCore;
using MediatR;

namespace BookingSystem.Application.Bookings.Commands;

public class CreateBooking
{
    public class Command : IRequest<Result<int>>
    {
        public required CreateBookingInputDto BookingDto { get; set; }
    }

    public class Handler(AppDbContext context, IMapper mapper, IBookingValidator bookingValidator) : IRequestHandler<Command, Result<int>>
    {
        public async Task<Result<int>> Handle(Command request, CancellationToken cancellationToken)
        {
            var resource = await context.Resources
                .FindAsync(request.BookingDto.ResourceId, cancellationToken);

            if (resource == null)
                return Result<int>.Failure("Resource for the booking not found", 404);
           
            var isBookingValid = await bookingValidator.IsResourceAvailable(resource, request.BookingDto);

            if (!isBookingValid)
                return Result<int>.Failure("Reqested resource is not availabe for that period.", 400);

            var booking = mapper.Map<Booking>(request.BookingDto);
            context.Bookings.Add(booking);

            var result = await context.SaveChangesAsync(cancellationToken);

            // Mock email sending (console output)
            Console.WriteLine($"EMAIL SENT TO admin@admin.com FOR CREATED BOOKING WITH ID {booking.Id}");

            return Result<int>.Success(booking.Id, "Booking successfully created.");
        }
    }
}
