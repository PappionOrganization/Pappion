using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pappion.Application.Dto.Favor;
using Pappion.Application.Parties;
using Pappion.Application.Favors;
using Pappion.Domain.Entities;
using Pappion.Domain.Constants;

namespace Pappion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavorsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public FavorsController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<FavorReadDto>> GetAll()
        {
            List<Favor> favors = await _mediator.Send(new GetFavorsQuery());
            return _mapper.Map<List<FavorReadDto>>(favors);
        }

        [HttpGet("{id}")]
        public async Task<FavorReadDto> GetById(Guid id)
        {
            Favor favor = await _mediator.Send(new GetFavorQuery(id));
            return _mapper.Map<FavorReadDto>(favor);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task Remove(Guid id) => await _mediator.Send(new RemoveFavorCommand(id));

        [Authorize(Policy = "Resident")]
        [HttpPost]
        public async Task Add(AddFavorCommand addFavorCommand) => await _mediator.Send(addFavorCommand);

        [Authorize]
        [HttpPut]
        public async Task Update(UpdatePartyCommand updateFavorCommand) => await _mediator.Send(updateFavorCommand);

        [Authorize]
        [HttpPost("like/{id}")]
        public async Task<IActionResult> Like(Guid id) => Ok(await _mediator.Send(new LikeFavorCommand(id)));

        [Authorize]
        [HttpPost("comment")]
        public async Task<IActionResult> Comment(CommentFavorCommand commentFavorCommand) => Ok(await _mediator.Send(commentFavorCommand));

        [HttpGet("likes/{id}")]
        public async Task<IActionResult> GetLikes(Guid id) => Ok(await _mediator.Send(new GetFavorLikesQuery(id)));

        [Authorize]
        [HttpDelete("unlike/{id}")]
        public async Task Unlike(Guid id) => await _mediator.Send(new UnlikeFavorCommand(id));
    }
}
