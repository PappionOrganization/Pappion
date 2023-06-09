using MediatR;
using Pappion.Domain.Entities;
using Pappion.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pappion.Application.Likes
{
    public record RemoveLikeCommand(Guid id) : IRequest;
    public class RemoveLikeHandler : IRequestHandler<RemoveLikeCommand>
    {
        private readonly IGenericRepository<Like> _genericRepository;

        public RemoveLikeHandler(IGenericRepository<Like> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task Handle(RemoveLikeCommand request, CancellationToken cancellationToken)
        {
            await _genericRepository.Remove(request.id);
            _genericRepository.Save();
        }
    }
}
