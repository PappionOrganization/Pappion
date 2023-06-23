using FluentValidation;
using Pappion.Application.Common.Exceptions;
using Pappion.Application.Interfaces.Contexts;
using Pappion.Application.Interfaces.Messaging;
using Pappion.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pappion.Domain.Entities;
using AutoMapper;

namespace Pappion.Application.Parties
{
    public record GetProfileImageQuery(Guid Id) : ICommand<List<Guid>>;
    public class GetProfileImageQueryValidator : AbstractValidator<GetProfileImageQuery>
    {
        public GetProfileImageQueryValidator()
        {
            RuleFor(command => command.Id).NotEmpty();
        }

    }

    public class GetProfileImageHandler : ICommandHandler<GetProfileImageQuery, List<Guid>>
    {
        private readonly IGenericRepository<Image> _imageRepository;
        private readonly IUserContext _userContext;
        private readonly IMapper _mapper;

        public GetProfileImageHandler(IGenericRepository<Image> imageRepository, IUserContext userContext, IMapper mapper)
        {
            _imageRepository = imageRepository;
            _userContext = userContext;
            _mapper = mapper;
        }

        public async Task<List<Guid>> Handle(GetProfileImageQuery request, CancellationToken cancellationToken)
        {
            if (!_imageRepository.ExistsAsync(im => im.PartyId.Equals(request.Id)).Result)
            {
                throw new EntityNotFoundException(nameof(Image), $"Cannot found {nameof(Image)} of post '{request.Id}'");
            }
            var postImages = _imageRepository.Filter(im => im.PartyId.Equals(request.Id)).ToList();
            return _mapper.Map<List<Guid>>(postImages);
        }
    }
}
