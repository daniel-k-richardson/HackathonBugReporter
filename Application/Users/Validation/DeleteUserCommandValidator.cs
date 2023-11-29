using Application.Users.Commands;
using FluentValidation;

namespace Application.Common.Validation;
public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
{
    public DeleteUserCommandValidator()
    {
        RuleFor(x => x.userId).NotEmpty();
    }
}
