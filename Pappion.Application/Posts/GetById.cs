﻿using MediatR;
using Pappion.Domain.Entities;
using Pappion.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pappion.Application.Posts
{
    public record GetPostQuery(Guid id) : IRequest<Post>;
    public class GetPostHandler : IRequestHandler<GetPostQuery, Post>
    {
        private readonly IGenericRepository<Post> _genericRepository;

        public GetPostHandler(IGenericRepository<Post> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task<Post> Handle(GetPostQuery request, CancellationToken cancellationToken)
        {
            return await _genericRepository.GetById(request.id);
        }
    }
}