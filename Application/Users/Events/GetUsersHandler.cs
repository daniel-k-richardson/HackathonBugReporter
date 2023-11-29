using Application.Common.Interfaces;
using Application.Users.Queries;
using Domain.Entities;
using LanguageExt.Common;
using MediatR;

namespace Application.Users.Events;
public class GetUsersHandler : IRequestHandler<GetUsersQuery, Result<IList<GlobalUser>>>
{
    private readonly IUserService _context;

    public GetUsersHandler(IUserService context)
    {
        _context = context;
    }

    public async Task<Result<IList<GlobalUser>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        return await _context.GetAllUsersAsync();
    }
}
