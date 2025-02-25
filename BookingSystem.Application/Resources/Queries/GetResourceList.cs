using BookingSystem.Application.Core;
using BookingSystem.Domain.Resources;
using BookingSystem.EntityFrameworkCore;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Application.Resources.Queries;

public class GetResourceList
{
    public class Query : IRequest<List<Resource>> { }
    

    public class Handler(AppDbContext context) : IRequestHandler<Query, List<Resource>>
    {
        public async Task<List<Resource>> Handle(Query request, CancellationToken cancellationToken)
        {
            return await context.Resources.ToListAsync(cancellationToken);
        }
    }
}
