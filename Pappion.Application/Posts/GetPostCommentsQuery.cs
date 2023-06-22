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

namespace Pappion.Application.Posts
{
    public record GetPostCommentsQuery(Guid Id) : IQuery<List<CommentReadDto>>;

    public class GetPostCommentsHandler : IQueryHandler<GetPostCommentsQuery, List<CommentReadDto>>
    {
        private readonly IGenericRepository<Comment> _commentRepository;
        private readonly IMapper _mapper;

        public GetPostCommentsHandler(IGenericRepository<Comment> commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }
        public async Task<List<CommentReadDto>> Handle(GetPostCommentsQuery request, CancellationToken cancellationToken)
        {
            var postComments = _commentRepository.Filter(l => l.PostId.Equals(request.Id)).ToList();
            return _mapper.Map<List<CommentReadDto>>(postComments);
        }
    }
}
