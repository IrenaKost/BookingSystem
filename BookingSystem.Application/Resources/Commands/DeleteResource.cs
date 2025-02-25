using BookingSystem.Application.Core;
using BookingSystem.EntityFrameworkCore;
using MediatR;

namespace BookingSystem.Application.Resources.Commands;

public class DeleteResource
{
    public class Command : IRequest<Result<Unit>>
    {
        public required int Id { get; set; }
    }
    public class Handler(AppDbContext context) : IRequestHandler<Command, Result<Unit>>
    {
        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            var resource = await context.Resources
                .FindAsync([request.Id], cancellationToken);

            if(resource == null)
                return Result<Unit>.Failure("Resource not found", 404);

            context.Remove(resource);

            var result = await context.SaveChangesAsync(cancellationToken) > 0;

            if (!result) return Result<Unit>.Failure("Failed to delete resource", 400);

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
