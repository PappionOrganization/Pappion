using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Pappion.Application.Interfaces.Messaging;
using Pappion.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pappion.Domain.Entities;
using Pappion.Application.Interfaces.Contexts;
using Pappion.Application.Common.Exceptions;
using Pappion.Domain.Constants;
using System.Data;

namespace Pappion.Application.Users
{
    public record SetProfileImageCommand(Guid Id) : ICommand<Unit>;
    public class SetProfileImageCommandValidator : AbstractValidator<SetProfileImageCommand>
    {
        public SetProfileImageCommandValidator()
        {
            RuleFor(command => command.Id).NotEmpty();
        }

    }

    public class SetProfileImageHandler : ICommandHandler<SetProfileImageCommand, Unit>
    {
        private readonly IGenericRepository<Image> _imageRepository;
        private readonly IUserContext _userContext;

        public SetProfileImageHandler(IGenericRepository<Image> imageRepository, IUserContext userContext)
        {
            _imageRepository = imageRepository;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(SetProfileImageCommand request, CancellationToken cancellationToken)
        {
            if (!_imageRepository.ExistsAsync(im => im.Id.Equals(request.Id)).Result)
            {
                throw new EntityNotFoundException(nameof(Image), $"Cannot found {nameof(Image)} '{request.Id}'");
            }

            var existingImage = _imageRepository.Filter(im => im.UserId.Equals(_userContext.Id)).FirstOrDefault();
            if (existingImage != null)
            {
                existingImage.UserId = null;
            }

            var image = _imageRepository.GetByIdAsync(request.Id).Result;
            image.UserId = _userContext.Id;
            await _imageRepository.UpdateAsync(image);
            await _imageRepository.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
