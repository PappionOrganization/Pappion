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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PostController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<PostReadDto> postsReadDto = _mapper.Map<IEnumerable<PostReadDto>>(_unitOfWork.Post.GetAll());
            return Ok(postsReadDto);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            IEnumerable<PostReadDto> postReadDto = _mapper.Map<IEnumerable<PostReadDto>>(_unitOfWork.Post.GetById(id));
            return Ok(postReadDto);
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(Guid id) 
        {
            _unitOfWork.Post.Remove(id);
            _unitOfWork.Save();
            return Ok(true);
        }

        [HttpPost]
        public ActionResult<PostReadDto> Add(PostAddDto post)
        {
            Post addedPost = _mapper.Map<Post>(post);
            _unitOfWork.Post.Add(addedPost);
            _unitOfWork.Save();
            return Ok(_mapper.Map<PostReadDto>(addedPost));
        }
        [HttpPut]
        public ActionResult Update(PostReadDto post)
        {
            Post updatedPost = _mapper.Map<Post>(post);
            _unitOfWork.Post.Update(updatedPost);
            _unitOfWork.Save();
            return Ok(_mapper.Map<PostReadDto>(updatedPost));
        }
    }
}
