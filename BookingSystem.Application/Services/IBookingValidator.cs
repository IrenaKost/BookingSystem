
using BookingSystem.Application.Bookings.DTOs;
using BookingSystem.Domain.Resources;

namespace BookingSystem.Application.Services;

public interface IBookingValidator
{
    // IsResourceAvailable
    Task<bool> IsBookingValid(Resource resource, BookResourceInputDto requestedResource);
}
