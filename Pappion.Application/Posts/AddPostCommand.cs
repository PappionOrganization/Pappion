using AutoMapper;
using FluentValidation;
using MediatR;
using Pappion.Application.Interfaces;
using Pappion.Application.Interfaces.Contexts;
using Pappion.Application.Interfaces.Messaging;
using Pappion.Domain.Entities;

namespace Pappion.Application.Posts
{
    public record AddPostCommand(string Title, string Description, string? Location, ICollection<Guid> ImagesId, string? TagNames) : ICommand<Unit>;
    public class AddPostCommandValidator : AbstractValidator<AddPostCommand>
    {
        public AddPostCommandValidator()
        {
            RuleFor(command => command.Title).NotEmpty();
            RuleFor(command => command.Description).NotEmpty();
        }
    }
    public class AddPostHandler : ICommandHandler<AddPostCommand, Unit>
    {
        private readonly IGenericRepository<Post> _postRepository;
        private readonly IGenericRepository<Image> _imageRepository;
        private readonly IUserContext _userContext;
        private readonly IMapper _mapper;

        public AddPostHandler(IGenericRepository<Post> postRepository, IUserContext userContext, IMapper mapper, IGenericRepository<Image> imageRepository)
        {
            _postRepository = postRepository;
            _userContext = userContext;
            _mapper = mapper;
            _imageRepository = imageRepository;
        }

        public async Task<Unit> Handle(AddPostCommand request, CancellationToken cancellationToken)
        {
            var postImages = _imageRepository.Filter(im => request.ImagesId.Contains(im.Id)).ToList();
            var post = new Post
            {
                Title = request.Title,
                Description = request.Description,
                Location = request.Location,
                Images = postImages,
                Tags = request.TagNames,
                AuthorId = _userContext.Id
            };
            await _postRepository.AddAsync(post);
            await _postRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
