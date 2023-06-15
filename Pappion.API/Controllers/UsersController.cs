using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pappion.Application.Users;
using Pappion.Domain.Entities;
using Pappion.Application.Dto.User;

namespace Pappion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMapper mapper, IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("login")]
        public async Task<ActionResult<string>> Login([FromBody] LoginRequest request)
        {
            return Ok(await _mediator.Send(new LoginCommand(request.Email, request.Password)));
        }

        [HttpPost("register")]
        public async Task<ActionResult<string>> Register(RegisterCommand registerCommand) => await _mediator.Send(registerCommand);
    }
}
