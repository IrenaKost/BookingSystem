using BookingSystem.Application.Core;
using BookingSystem.Domain.Resources;
using BookingSystem.EntityFrameworkCore;
using MediatR;

namespace BookingSystem.Application.Resources.Queries;

public class GetResourceDetails
{
    public class Query : IRequest<Result<Resource>> {
        public required int Id { get; set; }
    }

    public class Handler(AppDbContext context) : IRequestHandler<Query, Result<Resource>>
    {
        public async Task<Result<Resource>> Handle(Query request, CancellationToken cancellationToken)
        {
            var resource = await context.Resources.FindAsync([request.Id], cancellationToken);

            if(resource == null)
                return Result<Resource>.Failure("Resource not found", 404);

            return Result<Resource>.Success(resource);
        }
    }
}
