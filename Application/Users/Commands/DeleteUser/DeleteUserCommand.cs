using LanguageExt.Common;
using MediatR;

namespace Application.Users.Commands.DeleteUser;
public record DeleteUserCommand(int userId) : IRequest<Result<bool>>;
