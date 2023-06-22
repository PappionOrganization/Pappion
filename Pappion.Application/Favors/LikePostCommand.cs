using MediatR;
using Pappion.Application.Interfaces.Messaging;
using Pappion.Domain.Entities;
using Pappion.Application.Interfaces;
using Pappion.Application.Interfaces.Contexts;
using AutoMapper;
using Pappion.Application.Dto.Favor;
using FluentValidation;
using Pappion.Application.Common.Exceptions;

namespace Pappion.Application.Favors
{
    public record LikeFavorCommand(Guid favorId) : ICommand<Unit>;
    public class LikeFavorCommandValidator : AbstractValidator<LikeFavorCommand>
    {
        public LikeFavorCommandValidator()
        {
            RuleFor(command => command.favorId).NotEmpty();
        }
    }
    public class LikeFavorHandler : ICommandHandler<LikeFavorCommand, Unit>
    {
        private readonly IGenericRepository<Like> _likeRepository;
        private readonly IUserContext _userContext;
        private readonly IGenericRepository<Favor> _favorRepository;

        public LikeFavorHandler(IGenericRepository<Like> likeRepository, IUserContext userContext, IGenericRepository<Favor> favorRepository)
        {
            _likeRepository = likeRepository;
            _userContext = userContext;
            _favorRepository = favorRepository;
        }

        public async Task<Unit> Handle(LikeFavorCommand request, CancellationToken cancellationToken)
        {
            if (!await _favorRepository.ExistsAsync(p => p.Id.Equals(request.favorId)))
            {
                throw new EntityNotFoundException(nameof(Favor), $"Favor '{request.favorId}' not found");
            }
            var like = new Like { FavorId = request.favorId, SenderId = _userContext.Id };
            if (_likeRepository.ExistsAsync(l => l.SenderId.Equals(like.SenderId) && l.FavorId.Equals(like.FavorId)).Result)
            {
                throw new EntityAlreadyExistsException(nameof(like), $"Like is already " +
                    $"sent by user '{_userContext.Id}'");
            }
            
            await _likeRepository.AddAsync(like);
            await _likeRepository.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
