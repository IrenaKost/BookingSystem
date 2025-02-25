using BookingSystem.Application.Bookings.DTOs;
using BookingSystem.Domain.Resources;
using BookingSystem.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Application.Services;

public class BookingValidatorService(AppDbContext context) : IBookingValidator
{
    public async Task<bool> IsResourceAvailable(Resource resource, CreateBookingInputDto requestedBooking)
    {

        if (requestedBooking.DateFrom >= requestedBooking.DateTo)
            throw new InvalidOperationException("Start date can not be after end date.");

        if (requestedBooking.BookedQuantity <= 0)
            throw new InvalidOperationException("Requested quantity must be greater than 0.");

        if ((requestedBooking.DateFrom < DateOnly.FromDateTime(DateTime.Now)) || (requestedBooking.DateTo < DateOnly.FromDateTime(DateTime.Now)))
            throw new InvalidOperationException("Requested date must be after the current date.");

        // Find overlapping bookings for the same resource
        var overlappingBookings = await context.Bookings
            .Where(b => b.ResourceId == resource.Id)
            .Where(b => b.DateFrom <= requestedBooking.DateTo && b.DateTo >= requestedBooking.DateFrom)
            .ToListAsync();

        //For each day, sum the booked quantity from all bookings overlapping that day.
        for (DateOnly day = requestedBooking.DateFrom; day < requestedBooking.DateTo; day = day.AddDays(1))
        {
            var overlappingBookingsOnDay = overlappingBookings.Where(b => b.DateFrom <= day && b.DateTo >= day);
            var totalBookedOnDay = overlappingBookings.Where(b => b.DateFrom <= day && b.DateTo >= day).Sum(b => b.BookedQuantity);
            if (totalBookedOnDay + requestedBooking.BookedQuantity > resource.Quantity)
                return false;
        }

        return true;
    }
}
