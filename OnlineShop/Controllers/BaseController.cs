using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace OnlineShop.Web.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected IMediator _mediatr => HttpContext.RequestServices.GetService<IMediator>();
    }
}