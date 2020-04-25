using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Commands.Product;
using OnlineShop.Application.Interfaces;
using OnlineShop.Application.Pagination;
using OnlineShop.Application.Queries.Product;
using OnlineShop.Application.Response;
using OnlineShop.Application.Utility;
using OnlineShop.Application.ViewModels;

namespace OnlineShop.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> GetAllProducts([FromQuery] GetAllProductsQuery query)
        {
            //var result = await _mediatr.Send(new GetAllProductsQuery());
            var result = await _mediatr.Send(query);

            //if(result is Pagination<ProductVM>)
            //{
            //    //var pagination = result as Pagination<ProductVM>;

            //    //var response = new
            //    //{
            //    //    pagination.TotalPages,
            //    //    pagination.PageIndex,
            //    //    pagination.HasNextPage,
            //    //    pagination.HasPreviousPage,
            //    //    data = result
            //    //};

            //    return Ok(result);
            //}

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

            //var result = await _mediatr.Send(new GetProductByIdQuery(id));

            //return result == null ? (IActionResult)NotFound() : Ok(result);
        }


        [HttpGet("category")]
        public async Task<IActionResult> GetProductsByCategory([FromQuery]GetProductsByCategoryQuery query)
        {
            var result = await _mediatr.Send(query);

            if (result is NotFoundResponse)
                return NotFound();

            return Ok(result);
        }

        [HttpPost("create")]
        [Authorize(Roles = RolesDeafults.Admin)]
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
    }
}