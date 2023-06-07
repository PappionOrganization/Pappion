using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pappion.Application.Queries;
using Pappion.Domain.Entities;
using Pappion.Infrastructure.Dto;
using Pappion.Infrastructure.Interfaces;

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
            var posts = await _mediator.Send(new GetPostListQuery());
            return _mapper.Map<List<PostReadDto>>(posts);
        }

        //[HttpGet("GetById/{id}")]
        //public IActionResult GetById(Guid id)
        //{
        //    return Ok();
        //}

        //[HttpDelete("Remove/{id}")]
        //public IActionResult Remove(Guid id) 
        //{
        //    return Ok();
        //}

        //[HttpPost("Add")]
        //public ActionResult<PostReadDto> Add(PostAddDto post)
        //{
        //    return Ok();
        //}
        //[HttpPut("Update")]
        //public ActionResult Update(PostReadDto post)
        //{
        //    return Ok();
        //}
    }
}
