using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pappion.Application.Dto.Post;
using Pappion.Application.Posts;
using Pappion.Application.Users;
using Pappion.Domain.Entities;

namespace Pappion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public PostsController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<PostReadDto>> GetAll()
        {
            List<Post> posts = await _mediator.Send(new GetPostListQuery());
            return _mapper.Map<List<PostReadDto>>(posts);
        }

        [HttpGet("{id}")]
        public async Task<PostReadDto> GetById(Guid id)
        {
            Post post = await _mediator.Send(new GetPostQuery(id));
            return _mapper.Map<PostReadDto>(post);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            await _mediator.Send(new RemovePostCommand(id));
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Add(PostAddDto postAddDto)
        {
            Post post = _mapper.Map<Post>(postAddDto);
            await _mediator.Send(new AddPostCommand(post));
            return Ok();
        }

        [Authorize]
        [HttpPost("Like/{id}")]
        public async Task<IActionResult> Like(Guid id)
        {
            User currentUser = await _mediator.Send(new GetCurrentUserInfoQuery());
            PostLikeDto postLikeDto = new(){ PostId = id, SenderId = currentUser.Id};
            Like like = _mapper.Map<Like>(postLikeDto);
            await _mediator.Send(new LikePostCommand(like));
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(PostReadDto postReadDto)
        {
            Post post = _mapper.Map<Post>(postReadDto);
            await _mediator.Send(new UpdatePostCommand(post));
            return Ok();
        }
    }
}
