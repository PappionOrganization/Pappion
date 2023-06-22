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

namespace Pappion.Application.Users
{
    public record GetUserCommentsQuery(Guid Id) : IQuery<List<CommentReadDto>>;

    public class GetUserCommentsHandler : IQueryHandler<GetUserCommentsQuery, List<CommentReadDto>>
    {
        private readonly IGenericRepository<Comment> _commentRepository;
        private readonly IMapper _mapper;

        public GetUserCommentsHandler(IGenericRepository<Comment> commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }
        public async Task<List<CommentReadDto>> Handle(GetUserCommentsQuery request, CancellationToken cancellationToken)
        {
            var userComments = _commentRepository.Filter(l => l.UserId.Equals(request.Id)).ToList();
            return _mapper.Map<List<CommentReadDto>>(userComments);
        }
    }
}
