using Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Commands.UpdateUser;
public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator(IAppDbContext context)
    {
        RuleFor(x => x.User)
            .NotEmpty();

        RuleFor(x => x.UserId)
            .NotEmpty();

        RuleFor(x => x)
            .Must(x => x.UserId == x.User.Id)
            .WithMessage("Id's do not match");

        RuleFor(x => x.UserId).MustAsync(async (userId, _) =>
        {
            var user = await context.GlobalUsers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == userId);
            return user is not null;
        }).WithMessage("Cannot update user that does not exist");

        RuleFor(x => x.User.Username)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.User.Email)
            .EmailAddress();
    }
}
