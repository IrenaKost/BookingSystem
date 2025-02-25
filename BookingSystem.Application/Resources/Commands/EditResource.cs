using AutoMapper;
using BookingSystem.Application.Core;
using BookingSystem.Application.Resources.DTOs;
using BookingSystem.EntityFrameworkCore;
using MediatR;

namespace BookingSystem.Application.Resources.Commands;

public class EditResource
{
    public class Command : IRequest<Result<Unit>>
    {
        public required UpdateResourceInputDto ResourceDto { get; set; }
    }

    public class Handler(AppDbContext context, IMapper mapper) : IRequestHandler<Command, Result<Unit>>
    {
        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            var resource = await context.Resources
                .FindAsync(request.ResourceDto.Id, cancellationToken);

            if (resource == null)
                return Result<Unit>.Failure("Resource not found.", 404);

            mapper.Map(request.ResourceDto, resource);

            var result = await context.SaveChangesAsync(cancellationToken) > 0;

            if (!result) return Result<Unit>.Failure("Failed to update resource", 400);

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
