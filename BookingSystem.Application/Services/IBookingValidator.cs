
using BookingSystem.Application.Bookings.DTOs;
using BookingSystem.Domain.Resources;

namespace BookingSystem.Application.Services;

public interface IBookingValidator
{
    Task<bool> IsResourceAvailable(Resource resource, CreateBookingInputDto requestedBooking);
}
