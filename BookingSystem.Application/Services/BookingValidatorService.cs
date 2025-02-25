using BookingSystem.Application.Bookings.DTOs;
using BookingSystem.Application.Core;
using BookingSystem.Domain.Resources;
using BookingSystem.EntityFrameworkCore;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Application.Services;

public class BookingValidatorService(AppDbContext context) : IBookingValidator
{
    //public static async Task<bool> IsBookingValid(this Booking booking, Resource resource, BookResourceInputDto requestedResource)
    public async Task<bool> IsBookingValid(Resource resource, BookResourceInputDto requestedResource)
    {
        // Find overlapping bookings for the same resource
        var overlappingBookings = await context.Bookings
            .Where(b => b.ResourceId == resource.Id)
            .Where(b => b.DateFrom < requestedResource.DateTo && b.DateTo > requestedResource.DateFrom) // add extension method for this smth like IsOverlappingByDateRange
            .ToListAsync();

        // Sum the booked quantities during the requested period
        // in case there are more booked periods in the range of the requested period
        var bookedQuantity = overlappingBookings.Sum(b => b.BookedQuantity);

        return bookedQuantity + requestedResource.Quantity <= resource.Quantity;
    }
}
