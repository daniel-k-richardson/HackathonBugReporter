using Application.Bugs.Queries;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Bugs.Events;
public class GetBugHandler : IRequestHandler<GetBugQuery, Bug?>
{
    private readonly IAppDbContext _context;

    public GetBugHandler(IAppDbContext context) => _context = context;

    public async Task<Bug?> Handle(GetBugQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Bugs.FindAsync(request.BugId);
        return result;
    }
}
