using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Commands.Order;
using OnlineShop.Application.Queries.Order;
using OnlineShop.Application.Response;
using OnlineShop.Application.Utility;

namespace OnlineShop.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : BaseController
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public OrderController(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        [HttpGet("GetMyOrders")]
        public async Task<IActionResult> GetMyOrders()
        {
            var userId = int.Parse(_contextAccessor.HttpContext
                .User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);

            var result = await _mediatr.Send(new GetMyOrdersQuery(userId));

            if (result is NotFoundResponse)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("GetMySingleOrder/:id")]
        public async Task<IActionResult> GetMySingleOrder(int id)
        {
            var userId = int.Parse(_contextAccessor.HttpContext
                .User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);

            var result = await _mediatr.Send(new GetMySingleOrderQuery(id, userId));

            if (result is NotFoundResponse)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        //[Authorize(RolesDeafults.Admin)]
        public async Task<IActionResult> GetAllOrders()
        {
            var result = await _mediatr.Send(new GetAllOrdersQuery());

            if (result is NotFoundResponse)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("id")]
        //[Authorize(RolesDeafults.Admin)]
        public async Task<IActionResult> GetSingleOrder(int id)
        {
            var result = await _mediatr.Send(new GetSingleOrderByIdQuery(id));

            if (result is NotFoundResponse)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderCommand command)
        {
            var result = await _mediatr.Send(command);

            if (result is BadResponse)
            {
                var res = result as BadResponse;
                return BadRequest(res.Message);
            }
            else
            {
                var res = result as OkResponse<string>;
                return Ok(res.Data);
            }
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var result = await _mediatr.Send(new DeleteOrderCommand(id));

            if (result is NotFoundResponse)
                return NotFound();

            return Ok();
        }


    }
}