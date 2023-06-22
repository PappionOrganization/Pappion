using FluentValidation;
using MediatR;
using Pappion.Application.Common.Exceptions;
using Pappion.Application.Interfaces;
using Pappion.Application.Interfaces.Contexts;
using Pappion.Application.Interfaces.Messaging;
using Pappion.Domain.Entities;

namespace Pappion.Application.Partys
{
    public record CommentPartyCommand(Guid partyId, string Text, decimal Grade) : ICommand<Unit>;
    public class CommentPartyCommandValidator : AbstractValidator<CommentPartyCommand>
    {
        public CommentPartyCommandValidator()
        {
            RuleFor(command => command.partyId).NotEmpty();
        }
    }
    public class CommentPartyHandler : ICommandHandler<CommentPartyCommand, Unit>
    {
        private readonly IGenericRepository<Comment> _сommentRepository;
        private readonly IUserContext _userContext;
        private readonly IGenericRepository<Party> _partyRepository;

        public CommentPartyHandler(IGenericRepository<Comment> сommentRepository, IUserContext userContext, IGenericRepository<Party> partyRepository)
        {
            _сommentRepository = сommentRepository;
            _userContext = userContext;
            _partyRepository = partyRepository;
        }

        public async Task<Unit> Handle(CommentPartyCommand request, CancellationToken cancellationToken)
        {
            if (!await _partyRepository.ExistsAsync(p => p.Id.Equals(request.partyId)))
            {
                throw new EntityNotFoundException(nameof(Party), $"Party '{request.partyId}' not found");
            }
            var Comment = new Comment { PartyId = request.partyId, SenderId = _userContext.Id, Text = request.Text, Grade = request.Grade};

            await _сommentRepository.AddAsync(Comment);
            await _сommentRepository.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
