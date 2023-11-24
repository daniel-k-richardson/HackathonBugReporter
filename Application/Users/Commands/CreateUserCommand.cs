
using Domain.Entities;
using LanguageExt.Common;
using MediatR;

namespace Application.Users.Commands;
public class CreateUserCommand : IRequest<Result<GlobalUser>>
{

    public GlobalUser UserRequest { get; }

    public CreateUserCommand(GlobalUser userRequest)
    {
        UserRequest = userRequest;
    }
}
