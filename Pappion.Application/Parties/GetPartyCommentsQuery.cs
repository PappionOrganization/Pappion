using AutoMapper;
using Pappion.Application.Dto.Comments;
using Pappion.Application.Interfaces;
using Pappion.Application.Interfaces.Messaging;
using Pappion.Domain.Entities;

namespace Pappion.Application.Parties
{
    public record GetPartyCommentsQuery(Guid Id) : IQuery<List<CommentReadDto>>;

    public class GetPartyCommentsHandler : IQueryHandler<GetPartyCommentsQuery, List<CommentReadDto>>
    {
        private readonly IGenericRepository<Comment> _commentRepository;
        private readonly IMapper _mapper;

        public GetPartyCommentsHandler(IGenericRepository<Comment> commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }
        public async Task<List<CommentReadDto>> Handle(GetPartyCommentsQuery request, CancellationToken cancellationToken)
        {
            var partyComments = _commentRepository.Filter(l => l.PartyId.Equals(request.Id)).ToList();
            return _mapper.Map<List<CommentReadDto>>(partyComments);
        }
    }
}
