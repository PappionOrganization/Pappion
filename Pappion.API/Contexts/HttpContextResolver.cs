using Pappion.Application.Interfaces.Contexts;
using System.Security.Claims;

namespace Pappion.API.Contexts
{
    public class HttpContextResolver : IHttpContextResolver
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<HttpContextResolver> _logger;

        public HttpContextResolver(IHttpContextAccessor httpContextAccessor, ILogger<HttpContextResolver> logger)
        {
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        public IUserContext? ResolveUserContext()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext is null)
            {
                this._logger.LogWarning($"Cannot resolver user context. missing {nameof(httpContext)}");
                return null;
            }

            var userClaims = httpContext.User;
            var userId = Guid.Parse(userClaims.FindFirstValue(ClaimTypes.NameIdentifier));

            return new UserContext(userId);
        }
    }
}
