using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pappion.Application.Likes;
using Pappion.Domain.Entities;
using Pappion.Infrastructure.Dto.Like;

namespace Pappion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public LikeController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        [HttpPost("SetLike")]
        public async Task<IActionResult> Add(SetLikeDto setLikeDto)
        {
            Like like = _mapper.Map<Like>(setLikeDto);
            await _mediator.Send(new SetLikeCommand(like));
            return Ok();
        }

        [HttpDelete("RemoveLike/{id}")]
        public async Task<IActionResult> RemoveLike(Guid id)
        {
            await _mediator.Send(new RemoveLikeCommand(id));
            return Ok();
        }
    }
}
