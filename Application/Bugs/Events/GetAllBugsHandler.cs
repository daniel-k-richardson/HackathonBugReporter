using Application.Common;
using Application.Bugs.Queries;
using Domain.Entities;
using MediatR;

namespace Application.Bugs.Events;
public class GetAllBugsHandler : IRequestHandler<GetAllBugsQuery, IEnumerable<Bug>>
{
    private readonly IBugService _context;

    public GetAllBugsHandler(IBugService context) => _context = context;

    public async Task<IEnumerable<Bug>> Handle(GetAllBugsQuery request, CancellationToken cancellationToken)
    {
        var result = _context.GetAllBugs();
        return result;
    }
}
