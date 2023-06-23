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
    public record UpdateFavorCommand(Guid Id, string Title, string Description) : ICommand<Unit>;
    public class UpdateFavorCommandValidator : AbstractValidator<UpdateFavorCommand>
    {
        public UpdateFavorCommandValidator()
        {
            RuleFor(command => command.Title).NotEmpty();
            RuleFor(command => command.Description).NotEmpty();
        }
    }
    public class UpdateFavorHandler : ICommandHandler<UpdateFavorCommand, Unit>
    {
        private readonly IGenericRepository<Favor> _favorRepository;
        private readonly IGenericRepository<Image> _imageRepository;
        private readonly IUserContext _userContext;

        public UpdateFavorHandler(IGenericRepository<Favor> favorRepository, IUserContext userContext, IGenericRepository<Image> imageRepository)
        {
            _favorRepository = favorRepository;
            _userContext = userContext;
            _imageRepository = imageRepository;
        } 

        public async Task<Unit> Handle(UpdateFavorCommand request, CancellationToken cancellationToken)
        {
            if (!await _favorRepository.ExistsAsync(p => p.Id.Equals(request.Id)))
            {
                throw new EntityNotFoundException(nameof(Favor), $"Favor '{request.Id}' not found");
            }
            if (!CheckPermission(request.Id))
            {
                throw new AccessDeniedExeption(_userContext.Id);
            }
            var favor = await _favorRepository.GetByIdAsync(request.Id);
            favor.Title = request.Title;
            favor.Description = request.Description;
            await _favorRepository.UpdateAsync(favor);
            await _favorRepository.SaveChangesAsync();
            return Unit.Value;
        }
        private bool CheckPermission(Guid favorId)
        {
            if (_favorRepository.GetByIdAsync(favorId).Result.AuthorId.Equals(_userContext.Id))
            {
                return true;
            }
            return false;
        }
    }
}
