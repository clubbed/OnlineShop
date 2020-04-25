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
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineShop.Application.Handlers.Auth
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthResponseVM>
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly JwtSettings jwtSettings;

        public RegisterCommandHandler(UserManager<User> userManager, 
            RoleManager<Role> roleManager,
            IOptions<JwtSettings> jwtSettings)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.jwtSettings = jwtSettings.Value;
        }

        public async Task<AuthResponseVM> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var response = new AuthResponseVM();

            var user = new User
            {
                Email = request.Email,
                UserName = request.Email
            };

            var result = await userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                response.Errors = result.Errors.Select(c => c.Description).ToList();
                return response;
            }

            var role = roleManager.Roles.FirstOrDefault(c => c.Name == "Customer");

            await userManager.AddToRoleAsync(user, role.Name);

            var token = await JwtHelper.GenerateToken(user, jwtSettings.Secret, userManager);

            response.Token = token;
            response.Email = user.Email;

            return response;
        }
    }
}
