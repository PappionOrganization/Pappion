    using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pappion.Application.Dto.Party;
using Pappion.Application.Parties;
using Pappion.Application.Posts;
using Pappion.Domain.Entities;

namespace Pappion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartiesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public PartiesController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<PartyReadDto>> GetAll()
        {
            List<Party> parties = await _mediator.Send(new GetPartiesQuery());
            return _mapper.Map<List<PartyReadDto>>(parties);
        }

        [HttpGet("{id}")]
        public async Task<PartyReadDto> GetById(Guid id)
        {
            Party party = await _mediator.Send(new GetPartyQuery(id));
            return _mapper.Map<PartyReadDto>(party);
        }

        [HttpGet("images/{id}")]
        public async Task<PartyReadDto> GetImages(Guid id)
        {
            Party party = await _mediator.Send(new GetPartyQuery(id));
            return _mapper.Map<PartyReadDto>(party);
        }

        [HttpGet("subscribers/{id}")]
        public async Task<List<Guid>> GetSubscribers(Guid id) => await _mediator.Send(new GetPartySubscribersQuery(id));

        [Authorize]
        [HttpDelete("{id}")]
        public async Task Remove(Guid id) => await _mediator.Send(new RemovePartyCommand(id));


        [Authorize]
        [HttpPost("comment")]
        public async Task<IActionResult> Comment(CommentPostCommand commentPostCommand) => Ok(await _mediator.Send(commentPostCommand));


        [HttpGet("comments/{id}")]
        public async Task<IActionResult> GetComments(Guid id) => Ok(await _mediator.Send(new GetPartyCommentsQuery(id)));

        [Authorize]
        [HttpPost]
        public async Task Add(AddPartyCommand addPartyCommand) => await _mediator.Send(addPartyCommand);

        [Authorize]
        [HttpPut]
        public async Task Update(UpdatePartyCommand updatePartyCommand) => await _mediator.Send(updatePartyCommand);


        [Authorize]
        [HttpPost("like/{id}")]
        public async Task<IActionResult> Like(Guid id) => Ok(await _mediator.Send(new LikePartyCommand(id)));
        
        [HttpGet("likes/{id}")]
        public async Task<IActionResult> GetLikes(Guid id) => Ok(await _mediator.Send(new GetPartyLikesQuery(id)));

        [Authorize]
        [HttpDelete("like/{id}")]
        public async Task Unlike(Guid id) => await _mediator.Send(new UnlikePartyCommand(id));

        [Authorize]
        [HttpPost("subscribe/{id}")]
        public async Task<IActionResult> Subscribe(Guid id) => Ok(await _mediator.Send(new SubscribePartyCommand(id)));
    }
}
