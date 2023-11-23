using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HackathonBugReport.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BugsController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok();
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> Get(int Id)
    {
        return Ok();
    }

    [HttpPost()]
    public async Task<IActionResult> Post(Bug user)
    {
        return Ok();
    }

    [HttpPut("{Id}")]
    public async Task<IActionResult> Put(int Id, Bug user)
    {
        return Ok();
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(int Id)
    {
        return Ok();
    }


    [HttpGet("{id}/assigned-user")]
    public async Task<IActionResult> AllAssignedUser(int Id)
    {
        return Ok();
    }

    [HttpPost("{id}/assign-user/{userId}")]
    public async Task<IActionResult> AssignUser(int Id, int bugId)
    {
        return Ok();
    }

    [HttpDelete("{id}/assigned-user/{userId}")]
    public async Task<IActionResult> RemoveAssignedUser(int Id, int bugId)
    {
        return Ok();
    }
}
