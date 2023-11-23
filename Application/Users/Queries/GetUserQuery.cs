using Domain.Entities;
using MediatR;

namespace Application.Users.Queries;
public class GetUserQuery : IRequest<GlobalUser>
{
    public int UserId { get; }

    public GetUserQuery(int userId)
    {
        UserId = userId;
    }
}
