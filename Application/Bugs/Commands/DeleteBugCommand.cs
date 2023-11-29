using MediatR;

namespace Application.Bugs.Commands;
public record DeleteBugCommand(int bugId) : IRequest<bool>;
