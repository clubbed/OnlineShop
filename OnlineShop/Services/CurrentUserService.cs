using Microsoft.AspNetCore.Http;
using OnlineShop.Application.Interfaces;
using System.Security.Claims;

namespace OnlineShop.Web.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public int Id { get; }

        public CurrentUserService(IHttpContextAccessor contextAccessor)
        {
            Id = int.Parse(contextAccessor.HttpContext
                .User?.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "0");
        }
    }
}
