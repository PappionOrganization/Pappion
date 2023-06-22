using FluentValidation;
using Pappion.Application.Interfaces.Messaging;
using Pappion.Application.Interfaces;
using Pappion.Domain.Entities;

namespace Pappion.Application.Images
{
    public record DownloadImageCommand(Guid ImageId) : ICommand<FileStream>;
    public class DownloadImageCommandValidator : AbstractValidator<DownloadImageCommand>
    {
        public DownloadImageCommandValidator()
        {
            RuleFor(command => command.ImageId).NotEmpty();
        }

    }

    public class DownloadImageHandler : ICommandHandler<DownloadImageCommand, FileStream>
    {
        private readonly IImageService _imageService;
        public DownloadImageHandler(IImageService imageService)
        {
            _imageService = imageService;
        }

        public async Task<FileStream> Handle(DownloadImageCommand request, CancellationToken cancellationToken)
        {
            return await _imageService.DownloadAsync(request.ImageId);
        }
    }
}
