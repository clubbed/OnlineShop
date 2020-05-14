using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Commands.Product;
using OnlineShop.Application.Queries.Product;
using OnlineShop.Application.Response;
using OnlineShop.Application.Utility;

namespace OnlineShop.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> GetAllProducts([FromQuery] GetAllProductsQuery query)
        {
            var result = await _mediatr.Send(query);

            return Ok(result);
        }

        [HttpGet("featured")]
        public async Task<IActionResult> FeaturedProducts()
        {
            var result = await _mediatr.Send(new GetFeaturedProductsQuery());

            if (result is NotFoundResponse)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var result = await _mediatr.Send(new GetProductByIdQuery(id));

            if (result is NotFoundResponse)
                return NotFound();

            return Ok(result);
        }


        [HttpGet("category")]
        public async Task<IActionResult> GetProductsByCategory([FromQuery]GetProductsByCategoryQuery query)
        {
            var result = await _mediatr.Send(query);

            if (result is NotFoundResponse)
                return NotFound();

            return Ok(result);
        }

        [HttpPost()]
        [Authorize(Roles = RolesDefaults.Admin)]
        public async Task<IActionResult> CreateProduct([FromForm]CreateProductCommand command)
        {
            try
            {
                var result = await _mediatr.Send(command);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut]
        [Authorize(Roles = RolesDefaults.Admin)]
        public async Task<IActionResult> UpdateProduct(int id, UpdateProductCommand command)
        {
            try
            {
                command.Id = id;

                var result = await _mediatr.Send(command);

                if (result is NotFoundResponse)
                    return NotFound($"There is no product with id = {id}");

                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Authorize(Roles = RolesDefaults.Admin)]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var result = await _mediatr.Send(new DeleteProductCommand(id));

                if (result is NotFoundResponse)
                    return NotFound($"There is no product with id = {id}");

                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}