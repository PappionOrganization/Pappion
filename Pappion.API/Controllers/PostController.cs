using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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

        public PostController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(Guid id)
        {
            return Ok();
        }

        [HttpDelete("Remove/{id}")]
        public IActionResult Remove(Guid id) 
        {
            return Ok();
        }

        [HttpPost("Add")]
        public ActionResult<PostReadDto> Add(PostAddDto post)
        {
            return Ok();
        }
        [HttpPut("Update")]
        public ActionResult Update(PostReadDto post)
        {
            return Ok();
        }
    }
}
