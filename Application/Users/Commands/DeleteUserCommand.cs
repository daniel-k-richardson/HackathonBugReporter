using LanguageExt.Common;
using MediatR;

namespace Application.Users.Commands;
public record DeleteUserCommand(int userId) : IRequest<Result<bool>>;
