using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Queries.Category;
using OnlineShop.Application.Response;

namespace OnlineShop.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var result = await _mediatr.Send(new GetAllCategoriesQuery());

            if (result is NotFoundResponse)
                return NotFound();

            return Ok(result);
        }

    }
}