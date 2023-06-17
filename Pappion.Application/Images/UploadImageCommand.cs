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
        private readonly IGenericRepository<Image> _imageRepository;

        public UploadImageHandler(IGenericRepository<Image> imageRepository)
        {
            _imageRepository = imageRepository;
        }

        async Task<Guid> IRequestHandler<UploadImageCommand, Guid>.Handle(UploadImageCommand request, CancellationToken cancellationToken)
        {
            var newImage = new Image
            {
                Id = Guid.NewGuid(),
                Path = $"Res\\Images\\{Guid.NewGuid()}.{Path.GetExtension(request.Image.FileName).ToLowerInvariant()}"
            };
            using (var stream = new FileStream(newImage.Path, FileMode.Create))
            {
                await request.Image.CopyToAsync(stream);
            }
            await _imageRepository.AddAsync(newImage);
            await _imageRepository.SaveChangesAsync();
            return newImage.Id;
        }
        
    }
}
