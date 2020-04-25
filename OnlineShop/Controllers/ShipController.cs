using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Commands.Ship;
using OnlineShop.Application.Queries.Ship;
using OnlineShop.Application.Response;

namespace OnlineShop.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipController : BaseController
    {
        [HttpGet("ListShippers")]
        public async Task<IActionResult> GetAllShippers()
        {
            var result = await _mediatr.Send(new GetAllShippersQuery());

            return result.Any() ? (IActionResult)Ok() : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetShipper(GetShipperByIdQuery request)
        {
            var result = await _mediatr.Send(request);

            return result == null ? (IActionResult)NotFound() : Ok(result);
        }

        [HttpPost("Create/")]
        public async Task<IActionResult> CreateShipper([FromBody] CreateShipperCommand command)
        {
            var result = await _mediatr.Send(command);

            return result ? (IActionResult)Ok() : BadRequest();
        }

        [HttpPut("Update/{id:int}")]
        public async Task<IActionResult> UpdateShipper(int id, [FromBody]UpdateShipperCommand command)
        {
            command.Id = id;
            var result = await _mediatr.Send(command);

            if (result is NotFoundResponse)
                return NotFound("There is no shipper with that id");
            else if (result is BadResponse)
                return BadRequest();
            else
                return Ok();
        }

        [HttpDelete("Delete/{id:int}")]
        public async Task<IActionResult> DeleteShipper(DeleteShipperByIdCommand command)
        {
            var result =  await _mediatr.Send(command);

            if (result is NotFoundResponse)
                return NotFound("There is no shipper with that id");
            else if (result is BadResponse)
                return BadRequest();
            else
                return Ok();
        }
    }
}