using Domain.Entities;
using LanguageExt.Common;
using MediatR;

namespace Application.Users.Queries;
public class GetUserQuery : IRequest<Result<GlobalUser>>
{
    public int UserId { get; }

    public GetUserQuery(int userId)
    {
        UserId = userId;
    }
}
