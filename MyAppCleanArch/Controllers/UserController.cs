using App.Application.Commands;
using App.Application.Queries;
using App.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyAppCleanArch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(ISender sender) : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> AddUserAsync([FromBody] User user)
        {
            var result = await sender.Send(new AddUserCommand(user));
            return Ok(result);
        }
        
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllUserAsync()
        {
            var result = await sender.Send(new GetAllUsersQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllUserAsync([FromRoute] int id)
        {
            var result = await sender.Send(new GetUserByIdQuery(id));
            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateUserAsync([FromRoute] int id, [FromBody] User user)
        {
            var result = await sender.Send(new UpdateUserCommand(id, user));
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteUserAsync([FromRoute] int id)
        {
            var result = await sender.Send(new DeleteUserCommand(id));
            return Ok(result);
        }
    }
}
