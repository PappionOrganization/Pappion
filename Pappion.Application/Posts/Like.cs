using MediatR;
using Pappion.Application.Interfaces.Messaging;
using Pappion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pappion.Application.Interfaces;

namespace Pappion.Application.Posts
{
    public record LikePostCommand(Like like) : ICommand<Unit>;
    public class LikePostHandler : ICommandHandler<LikePostCommand, Unit>
    {
        private readonly IGenericRepository<Like> _genericRepository;

        public LikePostHandler(IGenericRepository<Like> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<Unit> Handle(LikePostCommand request, CancellationToken cancellationToken)
        {
            await _genericRepository.Add(request.like);
            _genericRepository.Save();
            return Unit.Value;
        }
    }
}
