using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Commands.Auth;

namespace OnlineShop.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody]RegisterCommand command)
        {
            var result = await _mediatr.Send(command);

            if (result.Errors.Any())
                return BadRequest(result.Errors);

            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]LoginCommand command)
        {
            try
            {
                var result = await _mediatr.Send(command);

                if (result.Errors.Any())
                    return BadRequest(result.Errors);

                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}