using MediatR;
using Microsoft.AspNetCore.Http;
using Pappion.Application.Interfaces;
using Pappion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pappion.Infrastructure
{
    public class ImageService : IImageService
    {
        private readonly IGenericRepository<Image> _imageRepository;

        public ImageService(IGenericRepository<Image> imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public async Task<FileStream> DownloadAsync(Guid imageId)
        {
            var image = await _imageRepository.GetByIdAsync(imageId);
            return File.OpenRead(image.Path);
        }

        public async Task<IEnumerable<FileStream>> DownloadRangeAsync(IEnumerable<Guid> imagesId)
        {
            List<FileStream> fileStreams = new List<FileStream>();

            foreach (var imageId in imagesId)
            {
                var image = await _imageRepository.GetByIdAsync(imageId);
                FileStream fileStream = File.OpenRead(image.Path);
                fileStreams.Add(fileStream);
            }
            return fileStreams;
        }

        public async Task<Guid> UploadAsync(IFormFile image)
        {
            var newImage = new Image
            {
                Id = Guid.NewGuid(),
                Path = $"Res\\Images\\{Guid.NewGuid()}.{Path.GetExtension(image.FileName).ToLowerInvariant()}"
            };
            using (var stream = new FileStream(newImage.Path, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }
            await _imageRepository.AddAsync(newImage);
            await _imageRepository.SaveChangesAsync();
            return newImage.Id;
        }

        public async Task<IEnumerable<Image>> UploadRangeAsync(IEnumerable<IFormFile> images)
        {
            var uploadedImages = new List<Image>();

            foreach (var image in images)
            {
                var newImage = new Image
                {
                    Id = Guid.NewGuid(),
                    Path = $"Res\\Images\\{Guid.NewGuid()}.{Path.GetExtension(image.FileName).ToLowerInvariant()}"
                };

                using (var stream = new FileStream(newImage.Path, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }

                uploadedImages.Add(newImage);
            }

            await _imageRepository.AddRangeAsync(uploadedImages);
            await _imageRepository.SaveChangesAsync();

            return uploadedImages;
        }
    }
}
