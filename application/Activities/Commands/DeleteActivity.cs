using System;
using Domain;
using MediatR;
using persistence;

namespace application.Activities.Commands;

public class DeleteActivity
{
    public class Command : IRequest {
        public required string Id { get; set; }
    }

    public class Handler(AppDbContext context) : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
             var activity = await context.Activities
                .FindAsync( [request.Id ], cancellationToken: cancellationToken) 
                    ?? throw new Exception("Cannot Find Activity");
            
            context.Remove(activity);

            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
