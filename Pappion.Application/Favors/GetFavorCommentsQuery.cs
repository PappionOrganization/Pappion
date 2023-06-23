using AutoMapper;
using Pappion.Application.Dto.Comments;
using Pappion.Application.Interfaces.Messaging;
using Pappion.Application.Interfaces;
using Pappion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pappion.Application.Favors
{
    public record GetFavorCommentsQuery(Guid Id) : IQuery<List<CommentReadDto>>;

    public class GetFavorCommentsHandler : IQueryHandler<GetFavorCommentsQuery, List<CommentReadDto>>
    {
        private readonly IGenericRepository<Comment> _commentRepository;
        private readonly IMapper _mapper;

        public GetFavorCommentsHandler(IGenericRepository<Comment> commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }
        public async Task<List<CommentReadDto>> Handle(GetFavorCommentsQuery request, CancellationToken cancellationToken)
        {
            var favorComments = _commentRepository.Filter(l => l.FavorId.Equals(request.Id)).ToList();
            return _mapper.Map<List<CommentReadDto>>(favorComments);
        }
    }
}
