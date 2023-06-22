using AutoMapper;
using FluentValidation;
using MediatR;
using Pappion.Application.Interfaces;
using Pappion.Application.Interfaces.Contexts;
using Pappion.Application.Interfaces.Messaging;
using Pappion.Domain.Entities;

namespace Pappion.Application.Parties
{
    public record AddPartyCommand(string Title, string Description, ICollection<Guid> ImagesId, string? TagNames) : ICommand<Unit>;
    public class AddPartyCommandValidator : AbstractValidator<AddPartyCommand>
    {
        public AddPartyCommandValidator()
        {
            RuleFor(command => command.Title).NotEmpty();
            RuleFor(command => command.Description).NotEmpty();
        }
    }
    public class AddPartyHandler : ICommandHandler<AddPartyCommand, Unit>
    {
        private readonly IGenericRepository<Party> _partyRepository;
        private readonly IGenericRepository<Image> _imageRepository;
        private readonly IUserContext _userContext;

        public AddPartyHandler(IGenericRepository<Party> partyRepository, IUserContext userContext, IGenericRepository<Image> imageRepository)
        {
            _partyRepository = partyRepository;
            _userContext = userContext;
            _imageRepository = imageRepository;
        }

        public async Task<Unit> Handle(AddPartyCommand request, CancellationToken cancellationToken)
        {
            var partyImages = _imageRepository.Filter(im => request.ImagesId.Contains(im.Id)).ToList();
            var party = new Party
            {
                Title = request.Title,
                Description = request.Description,
                Images = partyImages,
                Tags = request.TagNames,
                AuthorId = _userContext.Id
            };
            await _partyRepository.AddAsync(party);
            await _partyRepository.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
