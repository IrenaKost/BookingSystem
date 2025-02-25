using AutoMapper;
using BookingSystem.Application.Core;
using BookingSystem.Application.Resources.DTOs;
using BookingSystem.Domain.Resources;
using BookingSystem.EntityFrameworkCore;
using MediatR;

namespace BookingSystem.Application.Resources.Commands;

public class CreateResource
{
    public class Command : IRequest<Result<int>>
    {
        public required CreateResourceInputDto ResourceDto { get; set; }
    }

    public class Handler(AppDbContext context, IMapper mapper) : IRequestHandler<Command, Result<int>>
    {
        public async Task<Result<int>> Handle(Command request, CancellationToken cancellationToken)
        {
            var resource = mapper.Map<Resource>(request.ResourceDto);

            context.Resources.Add(resource);

            var result = await context.SaveChangesAsync(cancellationToken) > 0;

            if (!result) return Result<int>.Failure("Failed to create resource", 400);

            return Result<int>.Success(resource.Id);
        }
    }
}
