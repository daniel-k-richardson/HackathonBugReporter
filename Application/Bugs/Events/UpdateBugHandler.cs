using Application.Bugs.Commands;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Bugs.Events;
public class UpdateBugHandler : IRequestHandler<UpdateBugCommand, Bug>
{
    private readonly IAppDbContext _context;

    public UpdateBugHandler(IAppDbContext context) => _context = context;

    public async Task<Bug> Handle(UpdateBugCommand request, CancellationToken cancellationToken)
    {
        //var user = await _context.Bugs.Update(request.bug);

        return new();
    }
}
