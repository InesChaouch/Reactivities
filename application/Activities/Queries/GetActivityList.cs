using application.Activities.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using persistence;

namespace application.Activities.Queries;

public class GetActivityList
{
    public class Query : IRequest<List<ActivityDto>>;
    
    public class Handler(AppDbContext context, IMapper mapper) : IRequestHandler<Query, List<ActivityDto>>
    {
        public async Task<List<ActivityDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            return await context.Activities
                .ProjectTo<ActivityDto>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}
