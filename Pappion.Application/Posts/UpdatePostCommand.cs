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
    public record UpdatePostCommand(Guid Id, string Title, string Description) : ICommand<Unit>;
    public class UpdatePostCommandValidator : AbstractValidator<UpdatePostCommand>
    {
        public UpdatePostCommandValidator()
        {
            RuleFor(command => command.Title).NotEmpty();
            RuleFor(command => command.Description).NotEmpty();
        }
    }
    public class UpdatePostHandler : ICommandHandler<UpdatePostCommand, Unit>
    {
        private readonly IGenericRepository<Post> _postRepository;
        private readonly IGenericRepository<Image> _imageRepository;
        private readonly IUserContext _userContext;

        public UpdatePostHandler(IGenericRepository<Post> postRepository, IUserContext userContext, IGenericRepository<Image> imageRepository)
        {
            _postRepository = postRepository;
            _userContext = userContext;
            _imageRepository = imageRepository;
        } 

        public async Task<Unit> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            if (!await _postRepository.ExistsAsync(p => p.Id.Equals(request.Id)))
            {
                throw new EntityNotFoundException(nameof(Post), $"Post '{request.Id}' not found");
            }
            if (!CheckPermission(request.Id))
            {
                throw new AccessDeniedExeption(_userContext.Id);
            }
            var post = await _postRepository.GetByIdAsync(request.Id);
            post.Title = request.Title;
            post.Description = request.Description;
            await _postRepository.UpdateAsync(post);
            await _postRepository.SaveChangesAsync();
            return Unit.Value;
        }
        private bool CheckPermission(Guid postId)
        {
            if (_postRepository.GetByIdAsync(postId).Result.AuthorId.Equals(_userContext.Id))
            {
                return true;
            }
            return false;
        }
    }
}
