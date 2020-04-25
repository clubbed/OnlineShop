using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using OnlineShop.Application.Commands.Auth;
using OnlineShop.Application.Options;
using OnlineShop.Application.Utility;
using OnlineShop.Application.ViewModels;
using OnlineShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineShop.Application.Handlers.Auth
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthResponseVM>
    {
        private readonly UserManager<User> userManager;
        private readonly JwtSettings jwtSettings;

        public LoginCommandHandler(UserManager<User> userManager,
            IOptions<JwtSettings> jwtSettings)
        {
            this.userManager = userManager;
            this.jwtSettings = jwtSettings.Value;
        }
        public async Task<AuthResponseVM> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var response = new AuthResponseVM();

            var user = await userManager.FindByEmailAsync(request.Email);

            var result = await userManager.CheckPasswordAsync(user, request.Password);

            if (!result)
            {
                response.Errors = new List<string> { "Wrong Credentials" };
                return response;
            }
            var token = await JwtHelper.GenerateToken(user, jwtSettings.Secret, userManager);

            response.Email = user.Email;
            response.Token = token;

            return response;
        }
    }
}
