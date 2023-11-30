using Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;


namespace Application.Users.Commands.CreateUser;
public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator(IAppDbContext context)
    {
        RuleFor(x => x.User).NotNull();
        RuleFor(x => x.User.Id).Empty();
        RuleFor(x => x.User.Email).EmailAddress().NotEmpty();
        RuleFor(x => x.User.Email)
            .MustAsync(async (email, _) =>
            {
                var user = await context.GlobalUsers.FirstOrDefaultAsync(x => x.Email == email);
                return user == null;
            }).WithMessage("email already exists.");
    }
}
