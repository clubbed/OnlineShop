using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Application.ViewModels
{
    public class AuthResponseVM
    {
        public AuthResponseVM()
        {
            Errors = new List<string>();
        }
        public string Email { get; set; }
        public string Token { get; set; }
        public List<string> Errors { get; set; }
    }
}
