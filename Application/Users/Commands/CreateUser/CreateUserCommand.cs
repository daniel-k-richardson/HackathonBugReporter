using Domain.Entities;
using LanguageExt.Common;
using MediatR;

namespace Application.Users.Commands.CreateUser;
public record CreateUserCommand(GlobalUser User) : IRequest<Result<GlobalUser>>;
