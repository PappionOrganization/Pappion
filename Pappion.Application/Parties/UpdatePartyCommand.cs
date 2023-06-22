using FluentValidation;
using MediatR;
using Pappion.Application.Interfaces.Contexts;
using Pappion.Application.Interfaces.Messaging;
using Pappion.Application.Interfaces;
using Pappion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pappion.Application.Common.Exceptions;

namespace Pappion.Application.Parties
{
    public record UpdatePartyCommand(Guid Id, string Title, string Description) : ICommand<Unit>;
    public class UpdatePartyCommandValidator : AbstractValidator<UpdatePartyCommand>
    {
        public UpdatePartyCommandValidator()
        {
            RuleFor(command => command.Title).NotEmpty();
            RuleFor(command => command.Description).NotEmpty();
        }
    }
    public class UpdatePartyHandler : ICommandHandler<UpdatePartyCommand, Unit>
    {
        private readonly IGenericRepository<Party> _partyRepository;
        private readonly IGenericRepository<Image> _imageRepository;
        private readonly IUserContext _userContext;

        public UpdatePartyHandler(IGenericRepository<Party> partyRepository, IUserContext userContext, IGenericRepository<Image> imageRepository)
        {
            _partyRepository = partyRepository;
            _userContext = userContext;
            _imageRepository = imageRepository;
        } 

        public async Task<Unit> Handle(UpdatePartyCommand request, CancellationToken cancellationToken)
        {
            if (!await _partyRepository.ExistsAsync(p => p.Id.Equals(request.Id)))
            {
                throw new EntityNotFoundException(nameof(Party), $"Party '{request.Id}' not found");
            }
            if (!CheckPermission(request.Id))
            {
                throw new AccessDeniedExeption(_userContext.Id);
            }
            var party = await _partyRepository.GetByIdAsync(request.Id);
            party.Title = request.Title;
            party.Description = request.Description;
            await _partyRepository.UpdateAsync(party);
            await _partyRepository.SaveChangesAsync();
            return Unit.Value;
        }
        private bool CheckPermission(Guid partyId)
        {
            if (_partyRepository.GetByIdAsync(partyId).Result.AuthorId.Equals(_userContext.Id))
            {
                return true;
            }
            return false;
        }
    }
}
