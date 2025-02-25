using AutoMapper;
using BookingSystem.Application.Bookings.DTOs;
using BookingSystem.Application.Core;
using BookingSystem.Application.Resources.DTOs;
using BookingSystem.Application.Services;
using BookingSystem.Domain.Bookings;
using BookingSystem.EntityFrameworkCore;
using MediatR;

namespace BookingSystem.Application.Bookings.Commands;

public class BookResource
{
    public class Command : IRequest<Result<Unit>>
    {
        public required BookResourceInputDto BookResourceDto { get; set; }
    }

    public class Handler(AppDbContext context, IMapper mapper, IBookingValidator bookingValidator) : IRequestHandler<Command, Result<Unit>>
    {
        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            var resource = await context.Resources
                .FindAsync([request.BookResourceDto.ResourceId, cancellationToken], cancellationToken: cancellationToken);

            if (resource == null)
                return Result<Unit>.Failure("Resource not found.", 404);

            if (request.BookResourceDto.DateFrom >= request.BookResourceDto.DateTo)
                throw new InvalidOperationException("Start date can not be after end date.");

            if (request.BookResourceDto.Quantity <= 0)
                throw new InvalidOperationException("Requested quantity must be greater than 0.");

            if ((request.BookResourceDto.DateFrom < DateOnly.FromDateTime(DateTime.Now)) || (request.BookResourceDto.DateTo < DateOnly.FromDateTime(DateTime.Now)))
                throw new InvalidOperationException("Requested date must be greater than current date.");

            var isBookingValid = await bookingValidator.IsBookingValid(resource, request.BookResourceDto);

            if (!isBookingValid)
                return Result<Unit>.Failure("Reqested resource is not availabe.", 400);

            var booking = new Booking
            {
                ResourceId = request.BookResourceDto.ResourceId,
                DateFrom = request.BookResourceDto.DateFrom,
                DateTo = request.BookResourceDto.DateTo,
                BookedQuantity = request.BookResourceDto.Quantity
            };

            //var booking = mapper.Map<Booking>(request.BookResourceDto);

            context.Bookings.Add(booking);
            await context.SaveChangesAsync(cancellationToken);

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
