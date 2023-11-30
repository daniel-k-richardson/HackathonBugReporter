using Application.Common.Dtos;
using Application.Users.Commands.CreateUser;
using Application.Users.Commands.DeleteUser;
using Application.Users.Commands.UpdateUser;
using Application.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HackathonBugReport.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator) 
        => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var query = new GetUsersQuery();
        var result = await _mediator.Send(query);

        return result.Match<IActionResult>(Ok, BadRequest);

    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> Get(int Id)
    {
        var query = new GetUserQuery(Id);
        var result = await _mediator.Send(query);


        return result.Match<IActionResult>(
            success => success is null ? NotFound() : Ok(success),
            BadRequest);
    }

    [HttpPost()]
    public async Task<IActionResult> Post(User user)
    {
        var query = new CreateUserCommand(user);
        var result = await _mediator.Send(query);

        return result.Match<IActionResult>(Ok, BadRequest);
    }

    [HttpPut("{Id}")]
    public async Task<IActionResult> Put(int id, User user)
    {
        var updateQuery = new UpdateUserCommand(id, user);
        var result = await _mediator.Send(updateQuery);

        return result.Match<IActionResult>(Ok, BadRequest);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var query = new DeleteUserCommand(id);
        var result = await _mediator.Send(query);

        return result.Match<IActionResult>(
            success => NoContent(), BadRequest);
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
