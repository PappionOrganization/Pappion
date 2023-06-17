using FluentValidation;
using MediatR;
using Pappion.Application.Interfaces.Messaging;
using Microsoft.AspNetCore.Http;
using Pappion.Application.Interfaces;
using Pappion.Domain.Entities;

namespace Pappion.Application.Images
{
    public record ClearUnusedImagesCommand() : ICommand<Unit>;

    public class ClearUnusedImagesHandler : ICommandHandler<ClearUnusedImagesCommand, Unit>
    {
        private readonly IGenericRepository<Image> _imageRepository;

        public ClearUnusedImagesHandler(IGenericRepository<Image> imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public async Task<Unit> Handle(ClearUnusedImagesCommand request, CancellationToken cancellationToken)
        {
            var images = _imageRepository.Filter(im => im.UserId == null && im.PartyId == null && im.PostId == null && im.FavorId == null).ToList();
            foreach (var image in images)
            {
                if (File.Exists(image.Path))
                {
                    File.Delete(image.Path);
                }
            }
            await _imageRepository.RemoveRangeAsync(images);
            await _imageRepository.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
