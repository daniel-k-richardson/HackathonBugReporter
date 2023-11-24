using MediatR;

namespace Application.Users.Commands;
public record DeleteUserRequest(int userId) : IRequest<bool>;
