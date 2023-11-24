using Application.Common;
using Application.Users.Commands;
using LanguageExt.Common;
using MediatR;

namespace Application.Users.Events;
public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, Result<bool>>
{
    private readonly IUserService _userService;

    public DeleteUserHandler(IUserService userService) => _userService = userService;

    public async Task<Result<bool>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var result = await _userService.DeleteUserAsync(request.userId);
        return result;
    }
}
