using Application.Common;
using Application.Users.Queries;
using Domain.Entities;
using LanguageExt.Common;
using MediatR;

namespace Application.Users.Events;
public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, Result<IList<GlobalUser>>>
{
    private readonly IUserService _context;

    public GetAllUsersHandler(IUserService context) => _context = context;

    public async Task<Result<IList<GlobalUser>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.GetAllUsersAsync();
        return result;
    }
}
