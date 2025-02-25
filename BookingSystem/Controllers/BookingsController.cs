using BookingSystem.Application.Bookings.Commands;
using BookingSystem.Application.Bookings.DTOs;
using BookingSystem.Application.Bookings.Queries;
using BookingSystem.Application.Resources.Commands;
using BookingSystem.Application.Resources.DTOs;
using BookingSystem.Domain.Bookings;
using BookingSystem.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Controllers;

public class BookingsController : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
    {
        return await Mediator.Send(new GetBookingList.Query());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Booking>> GetBooking(int id)
    {
       return await Mediator.Send(new GetBookingDetail.Query{ Id = id });
    }

    [HttpPost]
    public async Task<ActionResult<int>> CreateBooking(CreateBookingInputDto input)
    {
        return HandleResult(await Mediator.Send(new CreateBooking.Command { BookingDto = input }));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateBooking(UpdateBookingInputDto input)
    {
        return HandleResult(await Mediator.Send(new EditBooking.Command { BookingDto = input }));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteBooking(int id)
    {
        return HandleResult(await Mediator.Send(new DeleteBooking.Command { Id = id }));
    }

}
