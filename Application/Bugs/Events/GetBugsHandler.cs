using Application.Bugs.Queries;
using Domain.Entities;
using MediatR;
using Application.Common.Interfaces;

namespace Application.Bugs.Events;
public class GetBugsHandler : IRequestHandler<GetBugsQuery, IEnumerable<Bug>>
{
    private readonly IBugService _context;

    public GetBugsHandler(IBugService context) => _context = context;

    public async Task<IEnumerable<Bug>> Handle(GetBugsQuery request, CancellationToken cancellationToken)
    {
        var result = _context.GetAllBugs();
        return result;
    }
}
