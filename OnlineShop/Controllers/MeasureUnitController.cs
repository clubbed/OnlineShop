﻿using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Commands.MeasureUnit;
using OnlineShop.Application.Queries.MeasureUnit;
using OnlineShop.Application.Utility;

namespace OnlineShop.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = Roles.Admin)]
    [Authorize]
    public class MeasureUnitController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetMeasureUnits()
        {
            return Ok(await _mediatr.Send(new GetMeasureUnitsQuery()));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateMeasureUnit([FromBody]CreateMeasureUnitCommand command)
        {
            return Ok(await _mediatr.Send(command));
        }

        [HttpPut("Update/{id:int}")]
        public async Task<IActionResult> UpdateMeasureUnit(int id, [FromBody]UpdateMeasureUnitCommand command)
        {
            command.Id = id;

            var result = await _mediatr.Send(command);

            return result == true ? (IActionResult)Ok() : NotFound();
        }

        [HttpDelete("Delete/{id:int}")]
        public async Task<IActionResult> DeleteMeasureUnit(int id)
        {
            var result = await _mediatr.Send(new DeleteMeasureUnitCommand(id));

            return result == true ? (IActionResult)Ok() : NotFound();
        }
    }
}