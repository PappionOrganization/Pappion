using Microsoft.AspNetCore.Http;
using Pappion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pappion.Application.Interfaces
{
    public interface IImageService
    {
        Task<Guid> UploadAsync(IFormFile image);
        Task<FileStream> DownloadAsync(Guid imageid);

        Task<IEnumerable<Image>> UploadRangeAsync(IEnumerable<IFormFile> image);
        Task<IEnumerable<FileStream>> DownloadRangeAsync(IEnumerable<Guid> imagesId);

    }
}
