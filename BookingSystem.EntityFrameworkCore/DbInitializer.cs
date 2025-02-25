using BookingSystem.Domain.Bookings;
using BookingSystem.Domain.Resources;

namespace BookingSystem.EntityFrameworkCore;

public class DbInitializer
{
    public static async Task SeedData(AppDbContext context)
    {
        if (!context.Resources.Any())
        {
            var resources = new List<Resource>
        {
            new() { Name = "Resource 1", Quantity = 10 },
            new() { Name = "Resource 2", Quantity = 20 }
        };
            await context.Resources.AddRangeAsync(resources);
        }

        //if (!context.Bookings.Any())
        //{
        //    var bookings = new List<Booking>
        //{
        //    new() {
        //        ResourceId = 1,
        //        BookedQuantity = 5,
        //        DateFrom = DateOnly.FromDateTime(DateTime.Now),
        //        DateTo = DateOnly.FromDateTime(DateTime.Now).AddDays(1)
        //    },
        //    new() {
        //        ResourceId = 2,
        //        BookedQuantity = 10,
        //        DateFrom = DateOnly.FromDateTime(DateTime.Now),
        //        DateTo = DateOnly.FromDateTime(DateTime.Now).AddDays(2)
        //    }
        //};
        //    await context.Bookings.AddRangeAsync(bookings);
        //}

        await context.SaveChangesAsync();
    }
}

