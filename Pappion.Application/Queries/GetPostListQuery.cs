using MediatR;
using Pappion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pappion.Application.Queries
{
    public record GetPostListQuery() : IRequest<List<Post>>;
}
