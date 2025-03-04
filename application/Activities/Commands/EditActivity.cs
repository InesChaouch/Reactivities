using System;
using AutoMapper;
using Domain;
using MediatR;
using persistence;

namespace application.Activities.Commands;

public class EditActivity
{
    public class Command : IRequest{
        public required Activity Activity { get; set;}
    }

    public class Handler(AppDbContext context, IMapper mapper) : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var activity = await context.Activities
                .FindAsync( [request.Activity.Id ], cancellationToken: cancellationToken) 
                    ?? throw new Exception("Cannot Find Activity");
            
            mapper.Map(request.Activity, activity);
            
            activity.Title = request.Activity.Title;

            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
