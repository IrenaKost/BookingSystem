using BookingSystem.Application.Bookings.Commands;
using BookingSystem.Application.Bookings.DTOs;
using BookingSystem.Application.Resources.Commands;
using BookingSystem.Application.Resources.DTOs;
using BookingSystem.Application.Resources.Queries;
using BookingSystem.Domain.Resources;
using BookingSystem.EntityFrameworkCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Controllers;

public class ResourcesController : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Resource>>> GetResources()
    {
        return await Mediator.Send(new GetResourceList.Query());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Resource>> GetResource(int id)
    {
        //throw new Exception("Server test error");
        return HandleResult(await Mediator.Send(new GetResourceDetails.Query { Id = id }));

    }

    [HttpPost]
    public async Task<ActionResult<int>> CreateResource(CreateResourceInputDto input)
    {
        return HandleResult(await Mediator.Send(new CreateResource.Command { ResourceDto = input }));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateResource(UpdateResourceInputDto input)
    {
         return HandleResult(await Mediator.Send(new EditResource.Command { ResourceDto = input }));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteResource(int id)
    {
        return HandleResult(await Mediator.Send(new DeleteResource.Command { Id = id }));
    }

    //[HttpPost("{id}/book")]
    //public async Task<ActionResult> Book(BookResourceInputDto input)
    //{
    //    return HandleResult(await Mediator.Send(new BookResource.Command { BookResourceDto = input }));
    //}
}
