using Application.Common;
using Application.Users.Commands;
using Domain.Entities;
using LanguageExt.Common;
using MediatR;

namespace Application.Users.Events;
public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, Result<GlobalUser>>
{

    private readonly IUserService _userService;

    public UpdateUserHandler(IUserService userService) => _userService = userService;

    public async Task<Result<GlobalUser>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userService.UpdateUserAsync(request.UserId, request.User);

        return user;
    }
}
