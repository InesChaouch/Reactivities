using System;
using application.Core;
using Domain;
using MediatR;
using persistence;

namespace application.Activities.Commands;

public class DeleteActivity
{
    public class Command : IRequest<Result<Unit>> {
        public required string Id { get; set; }
    }

    // public class Handler(AppDbContext context) : IRequestHandler<Command, Result<Unit>>
    // {
    //     public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
    //     {
    //          var activity = await context.Activities
    //             .FindAsync( [request.Id ], cancellationToken: cancellationToken) 
    //                 ?? throw new Exception("Cannot Find Activity");
            
    //         context.Remove(activity);

    //         await context.SaveChangesAsync(cancellationToken);
    //     }
    // }
}
