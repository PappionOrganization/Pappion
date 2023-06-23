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
    public record GetProfileImageQuery(Guid Id) : ICommand<Guid>;
    public class GetProfileImageQueryValidator : AbstractValidator<GetProfileImageQuery>
    {
        public GetProfileImageQueryValidator()
        {
            RuleFor(command => command.Id).NotEmpty();
        }

    }

    public class GetProfileImageHandler : ICommandHandler<GetProfileImageQuery, Guid>
    {
        private readonly IGenericRepository<Image> _imageRepository;
        private readonly IUserContext _userContext;

        public GetProfileImageHandler(IGenericRepository<Image> imageRepository, IUserContext userContext)
        {
            _imageRepository = imageRepository;
            _userContext = userContext;
        }

        public async Task<Guid> Handle(GetProfileImageQuery request, CancellationToken cancellationToken)
        {
            if (!_imageRepository.ExistsAsync(im => im.UserId.Equals(request.Id)).Result)
            {
                throw new EntityNotFoundException(nameof(Image), $"Cannot found {nameof(Image)} of user '{request.Id}'");
            }
            return _imageRepository.Filter(im => im.UserId.Equals(request.Id)).FirstOrDefault().Id;
        }
    }
}
