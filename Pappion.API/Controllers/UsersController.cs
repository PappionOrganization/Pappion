﻿using AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UsersController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login([FromBody] LoginRequest request)
        {
            return Ok(await _mediator.Send(new LoginCommand(request.Email, request.Password)));
        }

        [Authorize]
        [HttpGet]
        public async Task<List<UserReadDto>> GetAll()
        {
            List<User> users = await _mediator.Send(new GetUserListQuery());
            return _mapper.Map<List<UserReadDto>>(users);
        }

        [Authorize]
        [HttpGet("GetCurrentUser")]
        public async Task<UserReadDto> GetCurrentUser()
        {
            User user = await _mediator.Send(new GetCurrentUserInfoQuery());
            return _mapper.Map<UserReadDto>(user);
        }

        [HttpGet("{id}")]
        public async Task<UserReadDto> GetById(Guid id)
        {
            User user = await _mediator.Send(new GetUserQuery(id));
            return _mapper.Map<UserReadDto>(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            await _mediator.Send(new RemoveUserCommand(id));
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserReadDto userReadDto)
        {
            User user = _mapper.Map<User>(userReadDto);
            await _mediator.Send(new UpdateUserCommand(user));
            return Ok();
        }
        
    }
}
