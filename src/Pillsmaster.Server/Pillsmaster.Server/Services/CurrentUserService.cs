using System.Security.Claims;
using Pillsmaster.Application.Interfaces;

namespace Pillsmaster.API.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor) =>
        _httpContextAccessor = httpContextAccessor;

    public Guid UserId
    {
        get
        {
            var id = _httpContextAccessor.HttpContext?.User
                .Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;

            return string.IsNullOrEmpty(id) ? Guid.Empty : Guid.Parse(id);
        }
    }
}