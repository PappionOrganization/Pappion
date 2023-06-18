using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pappion.Application.Users;
using Pappion.Domain.Entities;
using Pappion.Application.Dto.User;
using Pappion.Application.Posts;

namespace Pappion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] LoginRequest request) => Ok(await _mediator.Send(new LoginCommand(request.Email, request.Password)));

        [HttpPost("register")]
        public async Task<ActionResult<string>> Register(RegisterCommand registerCommand) => await _mediator.Send(registerCommand);

        [Authorize]
        [HttpPost("like/{id}")]
        public async Task<IActionResult> Like(Guid id) => Ok(await _mediator.Send(new LikeUserCommand(id)));

        [HttpPut("image/{id}")]
        public async Task<IActionResult> SetImage(Guid id) => Ok(await _mediator.Send(new SetProfileImageCommand(id)));

        [Authorize]
        [HttpDelete("unlike/{id}")]
        public async Task Unlike(Guid id) => await _mediator.Send(new UnlikeUserCommand(id));
    }
}
