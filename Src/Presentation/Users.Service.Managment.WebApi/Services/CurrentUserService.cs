using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Users.Service.Managment.Application.Common.Interfaces;

namespace Users.Service.Managment.WebApi.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUserId()
        {
            return _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }

    public class DummyCurrentUserService : ICurrentUserService
    {
        public string GetUserId()
        {
            return "Test";
        }
    }
}
