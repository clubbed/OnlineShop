using Microsoft.AspNetCore.Http;
using OnlineShop.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OnlineShop.Web.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public int Id { get; }

        public CurrentUserService(IHttpContextAccessor contextAccessor)
        {
            Id = int.Parse(contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
        }
    }
}
