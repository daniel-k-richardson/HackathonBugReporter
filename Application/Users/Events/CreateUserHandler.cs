using Application.Common;
using Application.Users.Commands;
using Domain.Entities;
using LanguageExt.Common;
using MediatR;

namespace Application.Users.Events;
public class CreateUserHandler : IRequestHandler<CreateUserCommand, Result<GlobalUser>>
{
    private readonly IUserService _userService;

    public CreateUserHandler(IUserService userService) => _userService = userService;

    public async Task<Result<GlobalUser>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var result = await _userService.CreateUserAsync(request.UserRequest);
        return result;
    }
}
