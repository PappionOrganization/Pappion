using MediatR;
using Pappion.Application.Interfaces.Messaging;
using Pappion.Domain.Entities;
using Pappion.Application.Interfaces;
using Pappion.Application.Interfaces.Contexts;
using Pappion.Application.Common.Exceptions;
using Pappion.Domain.Constants;
using System.Data;

namespace Pappion.Application.Favors
{
    public record RemoveFavorCommand(Guid Id) : ICommand<Unit>;
    public class RemoveFavorHandler : ICommandHandler<RemoveFavorCommand, Unit>
    {
        private readonly IGenericRepository<Favor> _favorRepository;
        private readonly IUserContext _userContext;

        public RemoveFavorHandler(IGenericRepository<Favor> genericRepository, IUserContext userContext)
        {
            _favorRepository = genericRepository;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(RemoveFavorCommand request, CancellationToken cancellationToken)
        {
            if (!CheckPermission(request.Id))
            {
                throw new AccessDeniedExeption(_userContext.Id);
            }
            await _favorRepository.RemoveAsync(p => p.Id.Equals(request.Id));
            await _favorRepository.SaveChangesAsync();
            return Unit.Value;
        }

        private bool CheckPermission(Guid favorId)
        {
            if(_favorRepository.GetByIdAsync(favorId).Result.AuthorId.Equals(_userContext.Id)) 
            {
                return true;
            }
            return false;
        }
    }
}
