using Microsoft.AspNetCore.Http;
using Pappion.Application.Interfaces.Messaging;
using Pappion.Domain.Entities;
using Pappion.Infrastructure.Interfaces;
using System.Security.Claims;

namespace Pappion.Application.Users
{
    public record GetCurrentUserInfoQuery : IQuery<User> { }
    public class GetCurrentUserInfoQueryHandler : IQueryHandler<GetCurrentUserInfoQuery, User>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IGenericRepository<User> _genericRepository;

        public GetCurrentUserInfoQueryHandler(IHttpContextAccessor httpContextAccessor, IGenericRepository<User> genericRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _genericRepository = genericRepository;
        }

        public Task<User> Handle(GetCurrentUserInfoQuery request, CancellationToken cancellationToken)
        {
            HttpContext httpContext = _httpContextAccessor.HttpContext;
            Guid userId = Guid.Parse(httpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            User user = _genericRepository.Find(u => u.Id == userId).FirstOrDefault();
            return Task.FromResult(user);
        }
    }
}
