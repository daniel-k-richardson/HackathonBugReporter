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

        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> Get(int Id)
    {
        var query = new GetUserQuery(Id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost()]
    public async Task<IActionResult> Post(GlobalUser user)
    {
        var query = new CreateUserRequest(user);
        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [HttpPut("{Id}")]
    public async Task<IActionResult> Put(int id, GlobalUser user)
    {
        if (id != user.Id)
        {
            return BadRequest("Id's don't match");
        }

        var updateQuery = new UpdateUserRequest(id, user);
        var result = await _mediator.Send(updateQuery);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var query = new DeleteUserRequest(id);
        var result = await _mediator.Send(query);
        return Ok(result);
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
