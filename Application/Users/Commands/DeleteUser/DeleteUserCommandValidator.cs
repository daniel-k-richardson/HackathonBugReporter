using Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;


namespace Application.Users.Commands.DeleteUser;
public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
{
    public DeleteUserCommandValidator(IAppDbContext context)
    {
        RuleFor(x => x.userId).NotEmpty();

        RuleFor(x => x.userId).MustAsync(async (userId, _) =>
        {
            return await context.GlobalUsers.AnyAsync(x => x.Id == userId);
        }).WithMessage("That user does not exist.");
    }
}
