using Domain.Entities;
using MediatR;

namespace Application.Bugs.Commands;
public record UpdateBugCommand(int BugId, Bug bug) : IRequest<Bug>;
