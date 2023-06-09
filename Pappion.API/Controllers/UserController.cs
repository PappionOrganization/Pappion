using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pappion.Application.Likes;
using Pappion.Application.Users;
using Pappion.Domain.Entities;
using Pappion.Infrastructure.Dto.Like;
using Pappion.Infrastructure.Dto.User;

namespace Pappion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UserController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<List<UserReadDto>> GetAll()
        {
            List<User> users = await _mediator.Send(new GetUserListQuery());
            return _mapper.Map<List<UserReadDto>>(users);
        }

        [HttpGet("GetById/{id}")]
        public async Task<UserReadDto> GetById(Guid id)
        {
            User user = await _mediator.Send(new GetUserQuery(id));
            return _mapper.Map<UserReadDto>(user);
        }

        [HttpDelete("Remove/{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            await _mediator.Send(new RemoveUserCommand(id));
            return Ok();
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(UserAddDto userAddDto)
        {
            User user = _mapper.Map<User>(userAddDto);
            await _mediator.Send(new AddUserCommand(user));
            return Ok();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UserReadDto userReadDto)
        {
            User user = _mapper.Map<User>(userReadDto);
            await _mediator.Send(new UpdateUserCommand(user));
            return Ok();
        }
        
    }
}
