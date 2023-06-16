    using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pappion.Application.Dto.Post;
using Pappion.Application.Posts;
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
            List<Post> posts = await _mediator.Send(new GetPostsQuery());
            return _mapper.Map<List<PostReadDto>>(posts);
        }

        [HttpGet("{id}")]
        public async Task<PostReadDto> GetById(Guid id)
        {
            Post post = await _mediator.Send(new GetPostQuery(id));
            return _mapper.Map<PostReadDto>(post);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task Remove(Guid id) => await _mediator.Send(new RemovePostCommand(id));

        [Authorize]
        [HttpPost]
        public async Task Add(AddPostCommand addPostCommand) => await _mediator.Send(addPostCommand);


        [Authorize]
        [HttpPost("like/{id}")]
        public async Task<IActionResult> Like(Guid id) => Ok(await _mediator.Send(new LikePostCommand(id)));

        [Authorize]
        [HttpDelete("unlike/{id}")]
        public async Task Unlike(Guid id) => await _mediator.Send(new UnlikePostCommand(id));
    }
}
