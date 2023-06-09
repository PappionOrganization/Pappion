using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pappion.Application.Posts;
using Pappion.Domain.Entities;
using Pappion.Infrastructure.Dto.Post;

namespace Pappion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public PostController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<List<PostReadDto>> GetAll()
        {
            List<Post> posts = await _mediator.Send(new GetPostListQuery());
            return _mapper.Map<List<PostReadDto>>(posts);
        }

        [HttpGet("GetById/{id}")]
        public async Task<PostReadDto> GetById(Guid id)
        {
            Post post = await _mediator.Send(new GetPostQuery(id));
            return _mapper.Map<PostReadDto>(post);
        }

        [HttpDelete("Remove/{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            await _mediator.Send(new RemovePostCommand(id));
            return Ok();
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(PostAddDto postAddDto)
        {
            Post post = _mapper.Map<Post>(postAddDto);
            await _mediator.Send(new AddPostCommand(post));
            return Ok();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(PostReadDto postReadDto)
        {
            Post post = _mapper.Map<Post>(postReadDto);
            await _mediator.Send(new UpdatePostCommand(post));
            return Ok();
        }
    }
}
