using AutoMapper;
using FluentValidation;
using MediatR;
using Pappion.Application.Dto.Images;
using Pappion.Application.Interfaces;
using Pappion.Application.Interfaces.Contexts;
using Pappion.Application.Interfaces.Messaging;
using Pappion.Domain.Entities;

namespace Pappion.Application.Posts
{
    public record AddPostCommand(string Title, string Description, string? Location, ICollection<ImageReadDto> Images) : ICommand<Unit>;
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
        private readonly IUserContext _userContext;
        private readonly IMapper _mapper;

        public AddPostHandler(IGenericRepository<Post> postRepository, IUserContext userContext, IMapper mapper)
        {
            _postRepository = postRepository;
            _userContext = userContext;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(AddPostCommand request, CancellationToken cancellationToken)
        {
            var post = new Post
            {
                Title = request.Title,
                Description = request.Description,
                Location = request.Location,
                Images = _mapper.Map<ICollection<Image>>(request.Images),
                AuthorId = _userContext.Id
            };
            await _postRepository.AddAsync(post);
            await _postRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
