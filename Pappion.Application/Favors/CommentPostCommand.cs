using FluentValidation;
using MediatR;
using Pappion.Application.Common.Exceptions;
using Pappion.Application.Interfaces;
using Pappion.Application.Interfaces.Contexts;
using Pappion.Application.Interfaces.Messaging;
using Pappion.Domain.Entities;

namespace Pappion.Application.Favors
{
    public record CommentFavorCommand(Guid favorId, string Text, decimal Grade) : ICommand<Unit>;
    public class CommentFavorCommandValidator : AbstractValidator<CommentFavorCommand>
    {
        public CommentFavorCommandValidator()
        {
            RuleFor(command => command.favorId).NotEmpty();
        }
    }
    public class CommentFavorHandler : ICommandHandler<CommentFavorCommand, Unit>
    {
        private readonly IGenericRepository<Comment> _сommentRepository;
        private readonly IUserContext _userContext;
        private readonly IGenericRepository<Favor> _favorRepository;

        public CommentFavorHandler(IGenericRepository<Comment> сommentRepository, IUserContext userContext, IGenericRepository<Favor> favorRepository)
        {
            _сommentRepository = сommentRepository;
            _userContext = userContext;
            _favorRepository = favorRepository;
        }

        public async Task<Unit> Handle(CommentFavorCommand request, CancellationToken cancellationToken)
        {
            if (!await _favorRepository.ExistsAsync(p => p.Id.Equals(request.favorId)))
            {
                throw new EntityNotFoundException(nameof(Favor), $"Favor '{request.favorId}' not found");
            }
            var Comment = new Comment { FavorId = request.favorId, SenderId = _userContext.Id, Text = request.Text, Grade = request.Grade};

            await _сommentRepository.AddAsync(Comment);
            await _сommentRepository.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
