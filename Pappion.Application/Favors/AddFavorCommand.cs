using AutoMapper;
using FluentValidation;
using MediatR;
using Pappion.Application.Interfaces;
using Pappion.Application.Interfaces.Contexts;
using Pappion.Application.Interfaces.Messaging;
using Pappion.Domain.Entities;

namespace Pappion.Application.Favors
{
    public record AddFavorCommand(string Title, string Description, string? Location, ICollection<Guid>? ImagesId, string? TagNames, decimal Price) : ICommand<Unit>;
    public class AddFavorCommandValidator : AbstractValidator<AddFavorCommand>
    {
        public AddFavorCommandValidator()
        {
            RuleFor(command => command.Title).NotEmpty();
            RuleFor(command => command.Description).NotEmpty();
            RuleFor(command => command.Price).NotEmpty();
        }
    }
    public class AddFavorHandler : ICommandHandler<AddFavorCommand, Unit>
    {
        private readonly IGenericRepository<Favor> _favorRepository;
        private readonly IGenericRepository<Image> _imageRepository;
        private readonly IUserContext _userContext;
        private readonly IMapper _mapper;

        public AddFavorHandler(IGenericRepository<Favor> favorRepository, IUserContext userContext, IMapper mapper, IGenericRepository<Image> imageRepository)
        {
            _favorRepository = favorRepository;
            _userContext = userContext;
            _mapper = mapper;
            _imageRepository = imageRepository;
        }

        public async Task<Unit> Handle(AddFavorCommand request, CancellationToken cancellationToken)
        {
            var favorImages = _imageRepository.Filter(im => request.ImagesId.Contains(im.Id)).ToList();
            var favor = new Favor
            {
                Title = request.Title,
                Description = request.Description,
                Price = request.Price,
                Images = favorImages,
                Tags = request.TagNames,
                AuthorId = _userContext.Id
            };
            await _favorRepository.AddAsync(favor);
            await _favorRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
