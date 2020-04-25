using MediatR;
using OnlineShop.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Application.Commands.Auth
{
    public class RegisterCommand : IRequest<AuthResponseVM>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
