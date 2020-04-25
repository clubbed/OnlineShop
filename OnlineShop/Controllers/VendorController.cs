using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Commands.Vendor;
using OnlineShop.Application.Queries.Vendor;

namespace OnlineShop.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllVendors()
        {
            var result = await _mediatr.Send(new GetAllVendorsQuery());

            return result.Any() ? (IActionResult) Ok(result) : NotFound();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetVendor(int id)
        {
            return Ok(await _mediatr.Send(new GetVendorByIdQuery(id)));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateVendor([FromBody]CreateVendorCommand command)
        {
            return Content(await _mediatr.Send(command));
        }

        [HttpPut("Update/{id:int}")]
        public async Task<IActionResult> UpdateVendor(int id, [FromBody]UpdateVendorCommand command)
        {
            command.Id = id;

            return await _mediatr.Send(command) == true ? (IActionResult)Ok() : BadRequest();
        }

        [HttpDelete("Delete/{id:int}")]
        public async Task<IActionResult> DeleteVendor(int id)
        {
            return await _mediatr.Send(new DeleteVendorCommand(id)) == true ? (IActionResult)Ok() : BadRequest();
        }
    }
}