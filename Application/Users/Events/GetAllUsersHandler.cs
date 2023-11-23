using Application.Common;
using Application.Users.Queries;
using Domain.Entities;
using MediatR;

namespace Application.Users.Events;
public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<GlobalUser>>
{
    private readonly IUserService _context;

    public GetAllUsersHandler(IUserService context) => _context = context;

    public async Task<IEnumerable<GlobalUser>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var result = _context.GetAllUsers();
        return result;
    }
}
