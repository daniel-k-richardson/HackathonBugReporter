using Domain.Entities;
using MediatR;

namespace Application.Users.Queries;
public class GetAllUsersQuery : IRequest<IEnumerable<GlobalUser>>
{
    public GetAllUsersQuery()
    {
    }
}
