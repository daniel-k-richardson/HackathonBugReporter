using Application.Common.Interfaces;
using FluentValidation;

namespace Application.Users.Commands.DeleteUser;
public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
{
    public DeleteUserCommandValidator(IUserService userService)
    {
        RuleFor(x => x.userId).NotEmpty();

        RuleFor(x => x.userId).MustAsync(async (userId, _) =>
        {
            return await userService.GetUserAsync(userId) != null;
        }).WithMessage("That user does not exist.");
    }
}
