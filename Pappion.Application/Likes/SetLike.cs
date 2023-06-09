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
    public record SetLikeCommand(Like like) : IRequest;
    public class SetLikeHandler : IRequestHandler<SetLikeCommand>
    {
        private readonly IGenericRepository<Like> _genericRepository;

        public SetLikeHandler(IGenericRepository<Like> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        async Task IRequestHandler<SetLikeCommand>.Handle(SetLikeCommand request, CancellationToken cancellationToken)
        {
            await _genericRepository.Add(request.like);
            _genericRepository.Save();
        }
    }
}
