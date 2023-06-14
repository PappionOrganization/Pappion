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
    public record UpdatePostCommand(Post post) : ICommand<Unit>;
    public class UpdatePostHandler : ICommandHandler<UpdatePostCommand, Unit>
    {
        private readonly IGenericRepository<Post> _genericRepository;

        public UpdatePostHandler(IGenericRepository<Post> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<Unit> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            await _genericRepository.Update(request.post);
            _genericRepository.Save();
            return Unit.Value;
        }
    }
}
