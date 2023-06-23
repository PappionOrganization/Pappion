using FluentValidation;
using MediatR;
using Pappion.Application.Interfaces.Messaging;
using Microsoft.AspNetCore.Http;
using Pappion.Application.Interfaces;
using Pappion.Domain.Entities;

namespace Pappion.Application.Images
{
    public record UploadImageCommand(IFormFile Image) : ICommand<Guid>;
    public class UploadImageCommandValidator : AbstractValidator<UploadImageCommand>
    {
        private readonly string[] allowedExtensions = { ".jpg", ".jpeg", ".png" };
        public UploadImageCommandValidator()
        {
            RuleFor(command => command.Image).NotEmpty();
            RuleFor(command => command.Image).Must(IsVadidExtension).WithMessage("Invalid file extension");
        }
        private bool IsVadidExtension(IFormFile image) => allowedExtensions.Contains(Path.GetExtension(image.FileName).ToLowerInvariant());

    }

    public class UploadImageHandler : ICommandHandler<UploadImageCommand, Guid>
    {
        private readonly IImageService _imageService;

        public UploadImageHandler(IImageService imageService)
        {
            _imageService = imageService;
        }

        async Task<Guid> IRequestHandler<UploadImageCommand, Guid>.Handle(UploadImageCommand request, CancellationToken cancellationToken)
        {
            return await _imageService.UploadAsync(request.Image);
        }
        
    }
}
