using Application.Bugs.Queries;
using Domain.Entities;
using MediatR;
using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Bugs.Events;
public class GetBugsHandler : IRequestHandler<GetBugsQuery, IEnumerable<Bug>>
{
    private readonly IAppDbContext _context;

    public GetBugsHandler(IAppDbContext context) => _context = context;

    public async Task<IEnumerable<Bug>> Handle(GetBugsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Bugs.ToListAsync();
    }
}
