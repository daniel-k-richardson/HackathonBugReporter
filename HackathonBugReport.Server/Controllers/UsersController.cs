using Application.Users.Commands;
using Application.Users.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HackathonBugReport.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{

    private readonly IMediator _mediator;
    public UsersController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var query = new GetAllUsersQuery();
        var result = await _mediator.Send(query);

        return result.Match<IActionResult>(
            success => Ok(success),
            error => BadRequest(error));

    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> Get(int Id)
    {
        var query = new GetUserQuery(Id);
        var result = await _mediator.Send(query);
        return result.Match<IActionResult>(
            success => success is null ? NotFound() : Ok(success),
            error => BadRequest(error));
    }

    [HttpPost()]
    public async Task<IActionResult> Post(GlobalUser user)
    {
        var query = new CreateUserCommand(user);
        var result = await _mediator.Send(query);
        return result.Match<IActionResult>(
            success => Ok(success),
            error => BadRequest(error));
    }

    [HttpPut("{Id}")]
    public async Task<IActionResult> Put(int id, GlobalUser user)
    {
        var updateQuery = new UpdateUserCommand(id, user);
        var result = await _mediator.Send(updateQuery);

        return result.Match<IActionResult>(
            success => Ok(success),
            error => BadRequest(error));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var query = new DeleteUserCommand(id);
        var result = await _mediator.Send(query);

        return result.Match<IActionResult>(
            success => NoContent(),
            error => BadRequest(error));
    }

    [HttpGet("{id}/assigned-bugs")]
    public async Task<IActionResult> AllAssignedBugs(int Id)
    {
        return Ok();
    }

    [HttpPost("{id}/assign-bug/{bugId}")]
    public async Task<IActionResult> AssignBug(int Id, int bugId)
    {
        return Ok();
    }

    [HttpDelete("{id}/assigned-bug/{bugId}")]
    public async Task<IActionResult> RemoveAssignedBug(int Id, int bugId)
    {
        return Ok();
    }
}
