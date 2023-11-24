using Domain.Entities;
using MediatR;

namespace Application.Users.Commands;
public record UpdateUserRequest(int UserId, GlobalUser User) : IRequest<GlobalUser>;
