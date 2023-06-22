using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pappion.Application.Images;

namespace Pappion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ImagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<Guid> UploadImage([FromForm] UploadImageCommand uploadImageCommand) => await _mediator.Send(uploadImageCommand);

        [HttpGet]
        public async Task<IActionResult> DownloadImage(Guid id) => new FileStreamResult(await _mediator.Send(new DownloadImageCommand(id)), "image/png");

        [HttpDelete]
        public async Task DeleteImage() => await _mediator.Send(new ClearUnusedImagesCommand());

    }
}
